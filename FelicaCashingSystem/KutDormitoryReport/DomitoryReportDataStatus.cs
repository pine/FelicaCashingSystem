using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotClub.DormitoryReport
{
    internal class DomitoryReportDataStatus
    {
        public bool IsNameEnabled { get; set; }
        public bool IsRoomNoEnabled { get; set; }
        public bool IsPhoneNumberEnabled { get; set; }
        public bool IsLeaderNameEnabled { get; set; }
        public bool IsLeaderPhoneNumberEnabled { get; set; }
        public bool IsReasonEnabled { get; set; }
        public bool IsDateEnabled { get; set; }
        public bool IsReturnDateBeginEnabled { get; set; }
        public bool IsReturnDateEndEnabled { get; set; }

        internal DomitoryReportDataStatus()
        {
            this.IsNameEnabled = true;
            this.IsRoomNoEnabled = true;
            this.IsPhoneNumberEnabled = true;
            this.IsLeaderNameEnabled = true;
            this.IsLeaderPhoneNumberEnabled = true;
            this.IsReasonEnabled = true;
            this.IsDateEnabled = true;
            this.IsReturnDateBeginEnabled = true;
            this.IsReturnDateEndEnabled = true;
        }
    }
}
