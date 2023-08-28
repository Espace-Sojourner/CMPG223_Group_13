using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMPG223_Group_13
{
    class User
    {
        int User_ID;
        string User_Password;
        string First_Name;
        string Last_Name;
        string Email_Address;
        string Phone_Number;

        public User(int User_ID, string User_Password, string First_Name, string Last_Name, string Email_Address, string Phone_Number)
        {
            this.User_ID = User_ID;
            this.User_Password = User_Password;
            this.First_Name = First_Name;
            this.Last_Name = Last_Name;
            this.Email_Address = Email_Address;
            this.Phone_Number = Phone_Number;
        }

        public void setUserID(int userID)
        {
            User_ID = userID;
        }

        public void SetPassword(string password)
        {
            User_Password = password;
        }

        public void SetFirstName(string firstName)
        {
            First_Name = firstName;
        }

        public void SetLastName(string lastName) 
        {
            Last_Name = lastName;
        }

        public void setEmailAddress(string emailAddress) 
        {
            Email_Address = emailAddress;
        }

        public void setPhoneNumber(string phoneNumber)
        {
            Phone_Number = phoneNumber;
        }

        public int getID()
        {
            return User_ID;
        }

        public string getPassword()
        {
            return User_Password;
        }

        public string getFirstName()
        {
            return First_Name;
        }

        public string getEmailAddress()
        {
            return Email_Address;
        }

        public string getPhoneNumber()
        {
            return Phone_Number;
        }
    }
}
