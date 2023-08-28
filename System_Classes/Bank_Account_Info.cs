using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System_Classes
{
    class Bank_Account_Info
    {
        int Bank_Account_ID;
        int User_ID;
        string Bank_Name;
        string Account_Number;
        public Bank_Account_Info(int Bank_Account_ID, int User_ID, string Bank_Name, string Account_Number)
        {
            this.Bank_Account_ID = Bank_Account_ID;
            this.User_ID = User_ID;
            this.Bank_Name = Bank_Name;
            this.Account_Number = Account_Number;
        }

        public void setUserID(int newUser_ID)
        {
            User_ID = newUser_ID;
        }

        public void setBankName(string newBankName)
        {
            Bank_Name = newBankName;
        }

        public void setAccountNumber(string newAccountNumber)
        {
            Account_Number = newAccountNumber;
        }

        public int getID()
        {
            return Bank_Account_ID;
        }

        public int getUserID()
        {
            return User_ID;
        }

        public string getBankName()
        {
            return Bank_Name;
        }

        public string getAccountNumber()
        {
            return Account_Number;
        }


    }
}
