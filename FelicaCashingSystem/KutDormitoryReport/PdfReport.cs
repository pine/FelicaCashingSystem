using System;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace RobotClub.DormitoryReport
{
    /// <summary>
    /// PDF の書類を表すクラス
    /// </summary>
    internal class PdfReport : IDisposable
    {
        private Document Document { get; set; }
        private PdfImportedPage Page { get; set; }
        private PdfWriter Writer { get; set; }
        private BaseFont BaseFont { get; set; }

        public PdfReport()
        {
            this.Document = null;
            this.Writer = null;
            this.BaseFont = null;
        }

        /// <summary>
        /// PDF ファイルの書き出しを開始する
        /// </summary>
        /// <param name="outputFileName"></param>
        /// <param name="templateFileName"></param>
        /// <param name="fontPath"></param>
        public void Open(string outputFileName, string templateFileName, string fontPath)
        {
            // ドキュメントを生成する
            this.Document = new Document();

            // ファイルを開く
            this.Writer = PdfWriter.GetInstance(this.Document, new FileStream(outputFileName, FileMode.Create));
            this.Document.Open();

            // テンプレートを適応
            this.Page = this.ImportTemplate(templateFileName);

            // フォントを読み込む
           this.BaseFont = this.LoadFont(fontPath);
        }

        /// <summary>
        /// PDF ファイルの書き出しを終了する
        /// </summary>
        public void Close()
        {
            if (this.Document.IsOpen())
            {
                this.Document.Close();
            }
        }

        /// <summary>
        /// <para>座標を指定してテキストを追加します。</para>
        /// <para>PDF では用紙左上が座標基準 (0, 0) である点に注意してください。</para>
        /// </summary>
        /// <param name="text">追加するテキスト</param>
        /// <param name="fontSize">フォントサイズ</param>
        /// <param name="x">X 座標</param>
        /// <param name="y">Y座標</param>
        public void AddText(string text, int fontSize, int x, int y)
        {
            // 左下の座標
            float llx = x;
            float lly = 0f;

            // 右上の座標
            float urx = this.Page.Width;
            float ury = y;

            var pcb = this.Writer.DirectContent;
            var ct = new ColumnText(pcb);
            var font = new Font(this.BaseFont, fontSize, Font.NORMAL);
            
            var phrase = new Phrase(text, font);

            ct.SetSimpleColumn(
                phrase,
                llx,
                lly,
                urx,
                ury,
                0,
                Element.ALIGN_LEFT | Element.ALIGN_TOP
                );

            // 以下を実行して反映する (消さないこと)
            ct.Go();
        }

        /// <summary>
        /// テンプレートを読み込む
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private PdfImportedPage ImportTemplate(string fileName)
        {
            // テンプレートファイルを読み込む
            var pr = new PdfReader(fileName);
            var pcb = this.Writer.DirectContent;

            //  テンプレートを適応
            var page = this.Writer.GetImportedPage(pr, 1);
            pcb.AddTemplate(page, 0, 0);

            // ここで PdfReader を Close しないこと
            // Document#Close で例外発生

            return page;
        }

        /// <summary>
        /// フォントを読み込む
        /// </summary>
        /// <param name="fontPath"></param>
        /// <returns></returns>
        private BaseFont LoadFont(string fontPath)
        {
            return BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
        }
        

        #region Dispose Finalize パターン
        private bool disposed = false;

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            this.Dispose(true);
        }

        ~PdfReport()
        {
            this.Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (this.disposed)
            {
                return;
            }
            this.disposed = true;
            if (disposing)
            {
                // マネージリソースの解放処理
                if (this.Writer != null) { this.Writer.Dispose(); }
                if (this.Document != null) { this.Document.Dispose(); }
            }
            // アンマネージリソースの解放処理
        }

        protected void ThrowExceptionIfDisposed()
        {
            if (this.disposed)
            {
                throw new ObjectDisposedException(this.GetType().ToString());
            }
        }

        #endregion
    }
}
