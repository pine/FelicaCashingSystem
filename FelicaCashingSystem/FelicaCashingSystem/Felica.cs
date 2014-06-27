using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Threading;

namespace FelicaCashingSystem
{
    public delegate void FelicaGetUidDelegate(string uid);

    class Felica : IDisposable
    {
        #region Win32API

        private const int INFINITE = -1;
        private const int SCARD_SCOPE_USER     = 0;
        private const int SCARD_SCOPE_TERMINAL = 1;
        private const int SCARD_SCOPE_SYSTEM   = 2;

        private const int SCARD_PROTOCOL_T0 = 0x0001;
        private const int SCARD_PROTOCOL_T1 = 0x0002;
        private const int SCARD_PROTOCOL_RAW = 0x0004;
        private const int SCARD_PROTOCOL_T15 = 0x0008;
        private const int SCARD_PROTOCOL_UNDEFINED = 0x0000;

        private const int SCARD_SHARE_SHARED = 0x0002;

        private const int SCARD_STATE_UNAWARE = unchecked(0x0000);
        private const int SCARD_STATE_EMPTY   = unchecked(0x0010);
        private const int SCARD_STATE_PRESENT = unchecked(0x0020);
        private const int SCARD_STATE_UNAVAILABLE = unchecked(0x0008);
        private const int SCARD_STATE_INUSE = unchecked(0x0100); 

        private const int SCARD_S_SUCCESS = unchecked((int)0x00000000);

        private const int SCARD_LEAVE_CARD = unchecked((int)0x0000); 

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct SCARD_READERSTATE
        {
            public string szReader;
            public IntPtr pvUserData;
            public UInt32 dwCurrentState;
            public UInt32 dwEventState;
            public UInt32 cbAtr;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 36)]
            public byte[] rgbAtr;
        }

        [DllImport("winscard.dll", CharSet = CharSet.Unicode)]
        private static extern int SCardEstablishContext(
            uint dwScope,
            IntPtr pvReserved1,
            IntPtr pvReserved2,
            ref IntPtr phContext
            );

        [DllImport("winscard.dll", CharSet = CharSet.Unicode)]
        private static extern int SCardListReaders(
            IntPtr context,
            string groups,
            string readers,
            ref int size
            );
        
        [DllImport("winscard.dll")]
        private static extern int SCardReleaseContext(
            IntPtr hContext
            );

        [DllImport("winscard.dll", CharSet = CharSet.Unicode)]
        private static extern int SCardConnect(
             IntPtr hContext,
             [MarshalAs(UnmanagedType.LPWStr)] string szReader,
             UInt32 dwShareMode,
             UInt32 dwPreferredProtocols,
             out IntPtr phCard,
             out int pdwActiveProtocol
            );

        [DllImport("winscard.dll", CharSet = CharSet.Unicode)]
        private static extern int SCardTransmit(
            IntPtr hCard,
            IntPtr pioSendPci,
            byte[] pbSendBuffer,
            int cbSendLength,
            IntPtr pioRecvPci,
            ref byte pbRecvBuffer,
            ref int pcbRecvLength
            );

        [DllImport("winscard.dll", CharSet = CharSet.Unicode)]
        private static extern int SCardGetStatusChange(
            IntPtr hContext,
            int dwTimeout,
            [In, Out] SCARD_READERSTATE[] rgReaderStates,
            int cReaders
            );

        [DllImport("winscard.dll", EntryPoint = "SCardDisconnect")]
        private static extern int SCardDisconnect(
            IntPtr hCard,
            int dwDisposition
            );
    
        [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        private extern static IntPtr LoadLibrary(string fileName);

        [DllImport("kernel32.dll", EntryPoint = "FreeLibrary")]
        private extern static void FreeLibrary(IntPtr handle);

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        private extern static IntPtr GetProcAddress(
            IntPtr handle,
            string procName
            );

       
        #endregion

        private const string ExtectedReaderName = "Sony FeliCa Port/PaSoRi 3.0";
        private const int    FeliCaUIDLength    = 29; // UID の長さ (16進数表記)
        


        private FelicaGetUidDelegate Callback      { get; set; }
        private IntPtr               Context       { get; set; }
        private string               ReaderName    { get; set; }
        private IntPtr               Card          { get; set; }

        private Thread pollingThread = null;
        private int protocol = 0;
        
        private static readonly IntPtr SCARD_PCI_T0;
        private static readonly IntPtr SCARD_PCI_T1;
        private static readonly IntPtr SCARD_PCI_RAW;
        
        static Felica()
        {
            IntPtr handle = LoadLibrary("Winscard.dll");

            Felica.SCARD_PCI_T0  = GetProcAddress(handle, "g_rgSCardT0Pci");
            Felica.SCARD_PCI_T1  = GetProcAddress(handle, "g_rgSCardT1Pci");
            Felica.SCARD_PCI_RAW = GetProcAddress(handle, "g_rgSCardRawPci");

            FreeLibrary(handle);
        }

        public Felica()
        {
            this.Callback      = null;
            this.Context       = IntPtr.Zero;
        }

        #region Dispose Finalize パターン

        private bool disposed = false; // 解放されたかどうか

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            this.Dispose(true);
        }

        ~Felica()
        {
            this.Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (this.disposed)
            {
                return;
            }

            // アンマネージリソースの解放処理
            this.EndPolling();
            this.ReleaseContext();
            
            if (disposing)
            {
                // マネージリソースの解放処理
            }
            
            this.disposed = true;
        }

        protected void ThrowExceptionIfDisposed()
        {
            if (this.disposed)
            {
                throw new ObjectDisposedException(this.GetType().ToString());
            }
        }

        #endregion

        public void SetCallback(FelicaGetUidDelegate callback)
        {
            this.ThrowExceptionIfDisposed();

            this.Callback = callback;
        }

        public void BeginPolling()
        {
            this.ThrowExceptionIfDisposed();

            // 既にスレッドが起動している場合は終了させる
            this.EndPolling();

            // 新規にスレッドを開始
            this.pollingThread = new Thread(new ThreadStart(this.Polling));
            this.pollingThread.Start();
        }

        public void EndPolling()
        {
            this.ThrowExceptionIfDisposed();

            // スレッドが起動している場合
            if (this.pollingThread != null)
            {
                // 強制終了
                this.pollingThread.Abort();
                this.pollingThread.Join();
                
                // 解放
                this.pollingThread = null;
            }
        }

        private bool EstablishContext()
        {
            IntPtr ptr = IntPtr.Zero;

            this.ReleaseContext();

            int result = SCardEstablishContext(
                SCARD_SCOPE_USER,
                IntPtr.Zero,
                IntPtr.Zero,
                ref ptr
                );

            this.Context = ptr;

            return result == SCARD_S_SUCCESS;
        }

        private void ReleaseContext()
        {
            if (this.Context != IntPtr.Zero)
            {
                SCardReleaseContext(this.Context);
                this.Context = IntPtr.Zero;
            }
        }
        
        private List<String> ListReaders()
        {
            int bufsize = 0;
            int result;

            result = SCardListReaders(this.Context, null, null, ref bufsize);

            if (result != SCARD_S_SUCCESS)
            {
                return null;
            }

            string buffer = new string((char)0, bufsize);
            
            result = SCardListReaders(
                this.Context,
                null, 
                buffer,
                ref bufsize
                );

            if (result != SCARD_S_SUCCESS)
            {
                return null;
            }

            string[] readers = buffer.Split(new char[] { (char)0 }, 
                StringSplitOptions.RemoveEmptyEntries);

            return new List<string>(readers);
        }

        public bool ConnectReader()
        {
            if (!EstablishContext())
            {
                return false;
            }

            var readers = this.ListReaders();

            if (readers == null)
            {
                return false;
            }

            foreach (var reader in readers)
            {
                if (reader.StartsWith(ExtectedReaderName))
                {
                    this.ReaderName = reader;
                    return true;
                }
            }

            return false;
        }

        public bool ConnectCard()
        {
            IntPtr card;

            int result = SCardConnect(
                Context,
                this.ReaderName,
                SCARD_SHARE_SHARED,
                SCARD_PROTOCOL_T0 | SCARD_PROTOCOL_T1,
                out card,
                out this.protocol
                );

            this.Card = card;

            if (result != SCARD_S_SUCCESS)
            {
                return false;
            }

            return true;
        }

        public string GetUID()
        {
            const int PCSC_RECV_BUFF_LEN = 262;

            byte [] send_command        = new byte[] {0xFF, 0xCA, 0x00, 0x00, 0x00};
            byte [] receive_buff        = new byte[PCSC_RECV_BUFF_LEN];
	        int     receive_buff_length = receive_buff.Length;
            IntPtr  pci                 = this.CardProtocol2PCI(this.protocol);
            
            receive_buff[0] = 0x00;

            if (pci == null)
            {
                return null;
            }

            int result = SCardTransmit(
                this.Card,
                pci,
                send_command,
                send_command.Length,
                IntPtr.Zero,
                ref receive_buff[0],
                ref receive_buff_length
                );

            if (result != SCARD_S_SUCCESS)
            {
                return null;
            }

            byte [] uid     = receive_buff.Take(receive_buff_length).ToArray();
            string  uid_str = BitConverter.ToString(uid);

            return uid_str.Length == FeliCaUIDLength ? uid_str : null;
        }

        private string ConnectCardAndGetUid()
        {
            // カードに接続する
            if (!this.ConnectCard())
            {
                return null;
            }

            // ユーザー ID を取得する
            string uid = this.GetUID();

            // カードから切断する。
            this.SCardDisconnect();

            return uid;
        }

        private bool SCardGetStatusChange(
            SCARD_READERSTATE[] readerState,
            int timeout = INFINITE
            )
        {
            return SCardGetStatusChange(
                this.Context, timeout,
                readerState, readerState.Length
                ) == SCARD_S_SUCCESS;
        }

        private void Polling()
        {
            // リーダーの状態を保存する構造体
            var readerState = new SCARD_READERSTATE[1];

            // UID
            string uid = null;

            // 現在の状態を取得
            // 取得した状態は dwEventState に入っている
            while (true)
            {
                readerState[0].szReader = this.ReaderName;
                readerState[0].dwCurrentState = SCARD_STATE_UNAWARE;

                // 取得成功
                if (SCardGetStatusChange(readerState, 0))
                {
                    // 既にカードが載せられている場合
                    if ((readerState[0].dwEventState & SCARD_STATE_EMPTY) == 0)
                    {
                        // 待機する必要は無し
                        uid = this.ConnectCardAndGetUid();

                        // UID の取得に成功
                        if (uid != null)
                        {
                            if (this.Callback != null)
                            {
                                this.Callback(uid);
                            }

                            break;
                        }
                    }

                    // カードが載せられていない場合
                    else
                    {
                        break;
                    }
                }

            }

            // カードが載せられるのを待機
            while (true)
            {
                // 以前に取得した状態を設定
                readerState[0].dwCurrentState = readerState[0].dwEventState;

                // 状態が変化した場合
                if (SCardGetStatusChange(readerState, 100))
                {
                    // リーダーが取り外された場合
                    if ((readerState[0].dwEventState & SCARD_STATE_UNAVAILABLE) != 0)
                    {
                        MessageBox.Show("リーダーが取り外されました。プログラムを終了します。");
                        Program.Exit();
                    }

                    // カードが載せられた場合
                    else if ((readerState[0].dwEventState & SCARD_STATE_PRESENT) != 0)
                    {
                        if (uid == null)
                        {
                            // 待機する必要は無し
                            uid = this.ConnectCardAndGetUid();

                            // UID の取得に成功
                            if (uid != null)
                            {
                                if (this.Callback != null)
                                {
                                    this.Callback(uid);
                                }

                                continue;
                            }
                        }
                    }

                    // カードが外された場合
                    else if ((readerState[0].dwEventState & SCARD_STATE_EMPTY) != 0)
                    {
                        uid = null;
                    }
                }
            }
        }

        private bool SCardDisconnect()
        {
            return SCardDisconnect(this.Card, SCARD_LEAVE_CARD) == SCARD_S_SUCCESS;
        }

        IntPtr CardProtocol2PCI(int dwProtocol)
        {
            if (dwProtocol == SCARD_PROTOCOL_T0)
            {
                return SCARD_PCI_T0;
            }
            else if (dwProtocol == SCARD_PROTOCOL_T1)
            {
                return SCARD_PCI_T1;
            }
            else if (dwProtocol == SCARD_PROTOCOL_RAW)
            {
                return SCARD_PCI_RAW;
            }
            else if (dwProtocol == SCARD_PROTOCOL_UNDEFINED)
            {
                return IntPtr.Zero;
            }

            return SCARD_PCI_T1;
        }

    }
}
