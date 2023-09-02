using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace CMPG223_Group_13
{

    /*
     * USAGE
     * 
     *  if (user.UserType == UserType.Client)
     *  if (user.UserType == UserType.Admin)
     *  if (user.UserType == UserType.Farmer)
     *  
     *  
     *  user.UserType.toString() can be used to get the user type as a string
     *  
     *  
     *  1) string strType = "Farmer";
     *  
     *  //Getting UserType from string can be done by casting string as UserType
     *  2) UserType ut = (UserType)strType;
     *  
     */
    public enum UserType
    {
        Client,
        Admin,
        Farmer
    }

    public class User
    {
        public int User_ID { get; set; }
        public UserType UserType { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Email_Address { get; set; }
        public string Phone_Number { get; set; }
        public string Shipping_Address { get; set; }
        public string User_Password { get; set; }


        public User(int User_ID, UserType User_Type, string First_Name, string Last_Name, string Email_Address, string Phone_Number, string shipping_Address, string User_Password)
        {
            this.User_ID = User_ID;
            this.UserType = User_Type;
            this.User_Password = User_Password;
            this.First_Name = First_Name;
            this.Last_Name = Last_Name;
            this.Email_Address = Email_Address;
            this.Phone_Number = Phone_Number;
            this.Shipping_Address = shipping_Address;
        }

        #region Exists Methods
        public static bool farmerExists(User farmer)
        {
            if (getFarmerByID(farmer.User_ID) == null) return false;
            else return true;
        }

        public static bool clientExists(User client)
        {
            if (getClientByID(client.User_ID) == null) return false;
            else return true;
        }

        public static bool userExists(User User)
        {
            bool exists = false;
            if (clientExists(User)) return true;
            if (farmerExists(User)) return true;
            return exists;
        }
        #endregion Exists Methods

        #region isUserType Methods
        public bool isFarmer()
        {
            if (this.UserType == UserType.Farmer) return true;
            else return false;
        }

        public bool isClient()
        {
            if (this.UserType == UserType.Client) return true;
            else return false;
        }

        public bool isAdmin()
        {
            if (this.UserType == UserType.Admin) return true;
            else return false;
        }
        #endregion isUserType Methods

        #region getUserMethods

        public static User getClientByID(int clientID)
        {
            string sql = $"SELECT * FROM Client WHERE Client_ID = {clientID}";
            DataTable dt = DatabaseHandler.executeSelectToDT(sql);
            if (dt.Rows.Count == 0) return null;
            else return RowToClient(dt.Rows[0]);
        }

        public static User getClientByEmail(string clientEmail)
        {
            string sql = $"SELECT * FROM Client WHERE Email_Address = {clientEmail.ToLower()}";
            DataTable dt = DatabaseHandler.executeSelectToDT(sql);
            if (dt.Rows.Count == 0) return null;
            else return RowToClient(dt.Rows[0]);
        }

        public static User getFarmerByID(int farmerID)
        {
            string sql = $"SELECT * FROM Farmer WHERE Farmer_ID = {farmerID}";
            DataTable dt = DatabaseHandler.executeSelectToDT(sql);
            if (dt.Rows.Count == 0) return null;
            else return RowToFarmer(dt.Rows[0]);
        }

        public static User getFarmerByEmail(string farmerEmail)
        {
            string sql = $"SELECT * FROM Farmer WHERE Email_Address = {farmerEmail.ToLower()}";
            DataTable dt = DatabaseHandler.executeSelectToDT(sql);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            else return RowToClient(dt.Rows[0]);
        }
        #endregion getUserMethods



        /*
         * USAGE
         * 
         * 1) User user = RowToClient(dataTable.Rows[rowIndex])
         * 
         */

        //Returns User object from DataRow
        public static User RowToClient(DataRow Row)
        {
            return new User((int)Row["Client_ID"], (UserType)Row["Client_Type"], Row["First_Name"].ToString(), Row["Last_Name"].ToString(), Row["Email_Address"].ToString(), Row["Phone_Number"].ToString(), Row["Shipping_Address"].ToString(), Row["Password"].ToString());
        }



        /*
         * USAGE
         * 
         * 1) User user = RowToClient(gridView.SelectedRow)
         * 
         */

        //Returns User object from GridViewRow
        public static User RowToClient(GridViewRow Row)
        {
            return RowToClient((Row.DataItem as DataRowView).Row);        
        }



        /*
         * USAGE
         * 
         * 1) User user = RowToFarmer(dataTable.Rows[rowIndex])
         * 
         */

        //Returns User object from DataRow
        public static User RowToFarmer(DataRow Row)
        {
            return new User((int)Row["Farmer_ID"], UserType.Farmer, Row["First_Name"].ToString(), Row["Last_Name"].ToString(), Row["Email_Address"].ToString(), Row["Phone_Number"].ToString(), null, Row["Password"].ToString());
        }



        /*
         * USAGE
         * 
         * 1) User user = RowToFarmer(dataTable.Rows[rowIndex])
         * 
         */

        //Returns User object from DataRow
        public static User RowToFarmer(GridViewRow Row)
        {
            return RowToFarmer((Row.DataItem as DataRowView).Row);
        }



        //These methods can be called directly from the User class e.g User.Insert(userObject)

        #region Client DB Methods
        public static void insertClient(User client)
        {
            if (clientExists(client))
            {
                //Error Handling

            }
            else
            {
                string sql = $"INSERT INTO Client (Client_Type, First_Name, Last_Name, Email_Address, Phone_Number, Shipping_Address, Password) " +
                    $"VALUES ('{client.UserType}', '{client.First_Name}', '{client.Last_Name}', '{client.Email_Address}', '{client.Phone_Number}', '{client.Shipping_Address}', '{client.User_Password}')";
                DatabaseHandler.executeInsert(sql);
            }
        }

        public static void updateClient(User client)
        {
            if (clientExists(client))
            {
                string sql = $"UPDATE Client SET " +
                    $"Client_Type = '{client.UserType}', " +
                    $"First_Name = '{client.First_Name}', " +
                    $"Last_Name = '{client.Last_Name}', " +
                    $"Email_Address = '{client.Email_Address}', " +
                    $"Phone_Number = '{client.Phone_Number}', " +
                    $"Shipping_Address = '{client.Shipping_Address}', " +
                    $"Password = '{client.User_Password}') " +
                    $"WHERE Client_ID = {client.User_ID}";
                DatabaseHandler.executeUpdate(sql);
            }
            else
            {
                //Error Handling
                
            }
        }

        public static void deleteClient(User client)
        {
            if (clientExists(client))
            {
                string sql = $"DELETE FROM Client WHERE Client_ID = {client.User_ID}";
                DatabaseHandler.executeDelete(sql);
            }
            else
            {
                //Error Handling

            }
        }
        #endregion Client DB Methods

        #region Farmer DB Methods
        public static void insertFarmer(User farmer)
        {
            if (farmerExists(farmer))
            {
                //Error Handling

            }
            else
            {
                string sql = $"INSERT INTO Farmer (First_Name, Last_Name, Email_Address, Phone_Number, Password) " +
                    $"VALUES ('{farmer.First_Name}', '{farmer.Last_Name}', '{farmer.Phone_Number}', '{farmer.Shipping_Address}', '{farmer.User_Password}')";
                DatabaseHandler.executeInsert(sql);
            }
        }

        public static void updateFarmer(User farmer)
        {
            if (farmerExists(farmer))
            {
                string sql = $"UPDATE Farmer SET " +
                    $"First_Name = '{farmer.First_Name}', " +
                    $"Last_Name = '{farmer.Last_Name}', " +
                    $"Email_Address = '{farmer.Email_Address}', " +
                    $"Phone_Number = '{farmer.Phone_Number}', " +
                    $"Password = '{farmer.User_Password}')" +
                    $"WHERE Farmer_ID = {farmer.User_ID}";
                DatabaseHandler.executeUpdate(sql);
            }
            else
            {
                //Error Handling
                
            }
        }

        public static void deleteFarmer(User farmer)
        {
            if (farmerExists(farmer))
            {
                string sql = $"DELETE FROM Farmer WHERE Farmer_ID = {farmer.User_ID}";
                DatabaseHandler.executeDelete(sql);
            }
            else
            {
                //Error Handling

            }
        }
        #endregion Farmer DB Methods

    }
}
