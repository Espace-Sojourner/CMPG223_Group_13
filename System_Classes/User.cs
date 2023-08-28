using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMPG223_Group_13
{
    class User
    {
        public int User_ID { get; set; }
        public string User_Password { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Email_Address { get; set; }
        public string Phone_Number { get; set; }

        public User(int User_ID, string User_Password, string First_Name, string Last_Name, string Email_Address, string Phone_Number)
        {
            this.User_ID = User_ID;
            this.User_Password = User_Password;
            this.First_Name = First_Name;
            this.Last_Name = Last_Name;
            this.Email_Address = Email_Address;
            this.Phone_Number = Phone_Number;
        }
    }
}
