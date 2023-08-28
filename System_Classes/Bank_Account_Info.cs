using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMPG223_Group_13
{
    class Bank_Account_Info
    {
        public int Bank_Account_ID { get; set; }
        public int User_ID { get; set; }
        public string Bank_Name { get; set; }
        public string Account_Number { get; set; }
        public Bank_Account_Info(int Bank_Account_ID, int User_ID, string Bank_Name, string Account_Number)
        {
            this.Bank_Account_ID = Bank_Account_ID;
            this.User_ID = User_ID;
            this.Bank_Name = Bank_Name;
            this.Account_Number = Account_Number;
        }
    }
}
