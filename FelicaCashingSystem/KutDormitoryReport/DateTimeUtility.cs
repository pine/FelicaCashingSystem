using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotClub.DormitoryReport
{
    public class DateTimeUtility
    {
        public static int GetJapaneseYear(DateTime time)
        {
            var calendar = new System.Globalization.JapaneseCalendar();

            return calendar.GetYear(time);
        }
    }
}
