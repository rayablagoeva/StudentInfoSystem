using System;
using System.Collections.Generic;
using System.Text;

namespace UserLogin
{
    public class User
    {
        public string name { get; set; }
        public string password { get; set; }
        public string facNumber { get; set; }
        public Int32 role { get; set; }
        public DateTime created { get; set; }
        public DateTime? validDate { get; set; }
        public System.Int32 UserId { get; set; }
        public User(string name, string password, string facNum, Int32 role, DateTime created, DateTime validDate)
        {
            this.name = name;
            this.password = password;
            this.facNumber = facNum;
            this.role = role;
            this.created = created;
            this.validDate = validDate;

        }

        public User()
        {
            this.name = String.Empty;
            this.password = String.Empty;
            this.facNumber = String.Empty;
        }

        public override string ToString()
        {
            return name + " " + password + " " + facNumber;
        }

    }


}
