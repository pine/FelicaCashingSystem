using System;
using System.IO;

namespace RobotClub.DormitoryReport
{
    public class DomitoryReport : IDisposable
    {
        public DomitoryReportData Data { get; private set; }
        private string TemporaryFileName { get; set; }

        public static MainForm CreateWindow()
        {
            var window = new MainForm();

            return window;
        }

        internal DomitoryReport(DomitoryReportData data)
        {
            this.Data = data;
            this.TemporaryFileName = null;
        }

        /// <summary>
        /// PDF を書き出し、書きだした PDF のパスを返します
        /// </summary>
        /// <returns></returns>
        internal string Write(DomitoryReportDataStatus status)
        {
            this.TemporaryFileDelete();
            this.TemporaryFileName = Path.GetTempFileName();

            return this.Write(
                this.TemporaryFileName, // 一時ファイル名
                Properties.Settings.Default.TemplatePath,
                Properties.Settings.Default.FontPath,
                status
                );
        }

        /// <summary>
        /// PDF を書き出し、書きだした PDF のパスを返します
        /// </summary>
        /// <param name="outputPath"></param>
        /// <param name="templatePath"></param>
        /// <param name="fontPath"></param>
        /// <returns></returns>
        internal string Write(string outputPath, string templatePath, string fontPath, DomitoryReportDataStatus status){
            
            // PDF 書き出し処理
            using (var report = new PdfReport())
            {
                report.Open(outputPath, templatePath, fontPath);
                this.AddText(report, status);
                report.Close();
            }

            return outputPath;
        }

        /// <summary>
        /// テキストを追加します
        /// </summary>
        /// <param name="report"></param>
        /// <param name="status"></param>
        private void AddText(PdfReport report, DomitoryReportDataStatus status)
        {
            if (status.IsNameEnabled)
            {
                report.AddText(
                    this.Data.Name,
                    Properties.Settings.Default.NameFontSize,
                    Properties.Settings.Default.NameX,
                    Properties.Settings.Default.NameY
                    );
            }

            if (status.IsRoomNoEnabled)
            {
                report.AddText(
                    this.Data.RoomNo,
                    Properties.Settings.Default.RoomNoFontSize,
                    Properties.Settings.Default.RoomNoX,
                    Properties.Settings.Default.RoomNoY
                    );
            }

            if (status.IsPhoneNumberEnabled)
            {
                report.AddText(
                    this.Data.PhoneNumber,
                    Properties.Settings.Default.PhoneNumberFontSize,
                    Properties.Settings.Default.PhoneNumberX,
                    Properties.Settings.Default.PhoneNumberY
                    );
            }

            if (status.IsLeaderNameEnabled)
            {
                report.AddText(
                    this.Data.LeaderName,
                    Properties.Settings.Default.LeaderNameFontSize,
                    Properties.Settings.Default.LeaderNameX,
                    Properties.Settings.Default.LeaderNameY
                    );
            }

            if (status.IsLeaderPhoneNumberEnabled)
            {
                report.AddText(
                    this.Data.LeaderPhoneNumber,
                    Properties.Settings.Default.LeaderPhoneNumberFontSize,
                    Properties.Settings.Default.LeaderPhoneNumberX,
                    Properties.Settings.Default.LeaderPhoneNumberY
                    );
            }

            if (status.IsReasonEnabled)
            {
                report.AddText(
                    this.Data.Reason,
                    Properties.Settings.Default.ReasonFontSize,
                    Properties.Settings.Default.ReasonX,
                    Properties.Settings.Default.ReasonY
                    );
            }

            if (status.IsDateEnabled)
            {
                report.AddText(
                    DateTimeUtility.GetJapaneseYear(DateTime.Now).ToString(),
                    Properties.Settings.Default.TimeFontSize,
                    Properties.Settings.Default.TimeYearX,
                    Properties.Settings.Default.TimeYearY
                    );

                report.AddText(
                    string.Format("{0, 2}", DateTime.Now.Month),
                    Properties.Settings.Default.TimeFontSize,
                    Properties.Settings.Default.TimeMonthX,
                    Properties.Settings.Default.TimeMonthY
                    );

                report.AddText(
                    string.Format("{0, 2}", DateTime.Now.Day),
                    Properties.Settings.Default.TimeFontSize,
                    Properties.Settings.Default.TimeDateX,
                    Properties.Settings.Default.TimeDateY
                    );
            }

            if (status.IsReturnDateBeginEnabled)
            {
                report.AddText(
                    DateTimeUtility.GetJapaneseYear(DateTime.Now).ToString(),
                    Properties.Settings.Default.ReturnDateBeginFontSize,
                    Properties.Settings.Default.ReturnDateBeginYearX,
                    Properties.Settings.Default.ReturnDateBeginYearY
                    );

                report.AddText(
                    string.Format("{0, 2}", DateTime.Now.Month),
                    Properties.Settings.Default.ReturnDateBeginFontSize,
                    Properties.Settings.Default.ReturnDateBeginMonthX,
                    Properties.Settings.Default.ReturnDateBeginMonthY
                    );

                report.AddText(
                    string.Format("{0, 2}", DateTime.Now.Day),
                    Properties.Settings.Default.ReturnDateBeginFontSize,
                    Properties.Settings.Default.ReturnDateBeginDateX,
                    Properties.Settings.Default.ReturnDateBeginDateY
                    );
            }

            if (status.IsReturnDateEndEnabled)
            {
                report.AddText(
                    string.Format("{0, 2}", this.Data.ReturnDateEnd.Month.ToString()),
                    Properties.Settings.Default.ReturnDateEndFontSize,
                    Properties.Settings.Default.ReturnDateEndMonthX,
                    Properties.Settings.Default.ReturnDateEndMonthY
                    );

                report.AddText(
                    string.Format("{0, 2}", this.Data.ReturnDateEnd.Day.ToString()),
                    Properties.Settings.Default.ReturnDateEndFontSize,
                    Properties.Settings.Default.ReturnDateEndDateX,
                    Properties.Settings.Default.ReturnDateEndDateY
                    );

                report.AddText(
                    string.Format("{0, 2}", this.Data.ReturnDateEnd.Hour.ToString()),
                    Properties.Settings.Default.ReturnDateEndFontSize,
                    Properties.Settings.Default.ReturnDateEndHourX,
                    Properties.Settings.Default.ReturnDateEndHourY
                    );

                report.AddText(
                    string.Format("{0, 2}", this.Data.ReturnDateEnd.Minute.ToString()),
                    Properties.Settings.Default.ReturnDateEndFontSize,
                    Properties.Settings.Default.ReturnDateEndMinuteX,
                    Properties.Settings.Default.ReturnDateEndMinuteY
                    );
            }
        }
        
        #region Dispose Finalize パターン
        private bool disposed = false;

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            this.Dispose(true);
        }

        ~DomitoryReport()
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
            }
            // アンマネージリソースの解放処理
            this.TemporaryFileDelete();
        }

        protected void ThrowExceptionIfDisposed()
        {
            if (this.disposed)
            {
                throw new ObjectDisposedException(this.GetType().ToString());
            }
        }

        private void TemporaryFileDelete()
        {
            if (this.TemporaryFileName != null && File.Exists(this.TemporaryFileName))
            {
                try
                {
                    File.Delete(this.TemporaryFileName);
                }
                catch (Exception) { }
            }
        }

        #endregion
    }
}
