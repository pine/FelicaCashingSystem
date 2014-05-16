using System;

namespace RobotClub.DormitoryReport
{
    public class DomitoryReportData
    {
        public static DomitoryReportData Empty = new DomitoryReportData();

        public string Name { get; set; }
        public string RoomNo { get; set; }
        public string PhoneNumber { get; set; }
        public string LeaderName { get; set; }
        public string LeaderPhoneNumber { get; set; }
        public string Reason { get; set; }
        public DateTime ReturnDateEnd { get; set; }

        public void ReturnDateEndToday()
        {
            this.ReturnDateEnd = new DateTime(
                DateTime.Now.Year,
                DateTime.Now.Month,
                DateTime.Now.Day,
                Properties.Settings.Default.ReturnDateEndTodayHour,
                Properties.Settings.Default.ReturnDateEndTodayMinutes,
                0
                );
        }

        public void ReturnDateEndTomorrow()
        {
            this.ReturnDateEnd = new DateTime(
                DateTime.Now.AddDays(1).Year,
                DateTime.Now.AddDays(1).Month,
                DateTime.Now.AddDays(1).Day,
                Properties.Settings.Default.ReturnDateEndTomorrowHour,
                Properties.Settings.Default.ReturnDateEndTomorrowMinutes,
                0
                );
        }

        public void ReturnDateEndOther(int month, int date, int hour, int minutes)
        {
            var time = new DateTime(
               DateTime.Now.Year,
               month,
               date,
               hour,
               minutes,
               0
               );

            if (DateTime.Now > time) // 日付が今より後にあるか
            {
                this.ReturnDateEnd = time;
            }

            else // 年をまたいでいる場合
            {
                this.ReturnDateEnd = new DateTime(
                    DateTime.Now.Year + 1,
                    month,
                    date,
                    hour,
                    minutes,
                    0
                    );
            }
        }
    }
}
