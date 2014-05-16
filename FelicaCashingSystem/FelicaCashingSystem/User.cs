using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FelicaCashingSystem
{
    public class User
    {
        public string Uid { get; set; }
        public string RealUid { get; set; }
        public string Name { get; set; }
        public int Money { get; set; }
        public bool Admin { get; set; }
        public string Mail { get; set; }
        public bool IsDormitory { get; set; }
        public string PhoneNumber { get; set; }
        public string RoomNo { get; set; }

        public User(
            string uid,
            string realUid,
            string name,
            int money,
            bool admin,
            string mail,
            bool isDormitory,
            string phoneNumber,
            string roomNo
            )
        {
            this.Uid = uid;
            this.RealUid = realUid;
            this.Name = name;
            this.Money = money;
            this.Admin = admin;
            this.Mail = mail;
            this.IsDormitory = isDormitory;
            this.PhoneNumber = phoneNumber;
            this.RoomNo = roomNo;
        }

        public User(
            string uid,
            string realUid,
            string name,
            string money,
            string admin,
            string mail,
            string isDormitory,
            string phoneNumber,
            string roomNo
            )
            : this(
            uid, realUid, name, int.Parse(money), int.Parse(admin) == 1, mail,
            int.Parse(isDormitory) == 1, phoneNumber, roomNo)
        {
        }
        
        public User(string uid, string realUid, string name, int money)
            : this(uid, realUid, name, money, false, null, false, null, null) { }
        
        public User(string uid, string realUid, string name, string money)
            : this(uid, realUid, name, int.Parse(money)) { }
    }
}
