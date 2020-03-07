using Cafeteria_Management_Application.DTO;
using QuanLyQuanCafe.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Cafeteria_Management_Application.DAO
{
    public class AccountDAO
    {
        private static AccountDAO instance;

        public static AccountDAO Instance 
        {
            get 
            { 
                if (instance == null) instance = new AccountDAO(); 
                return instance; 
            }
            private set => instance = value; 
        }
        private AccountDAO() { }
        public string GetHashData(string str)
        {
            byte[] temp = ASCIIEncoding.ASCII.GetBytes(str);
            byte[] hashData = new MD5CryptoServiceProvider().ComputeHash(temp);
            string hashPass = "";

            foreach (byte item in hashData)
            {
                hashPass += item;
            }
            return hashPass;
        }
        public bool Login(string username, string password)
        {
            string query = @"EXEC dbo.USP_Login @username , @password";
            string hashPass = GetHashData(password);
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] {username,hashPass });

            return data.Rows.Count > 0;
        }
        public Account GetAccountByUserName(string userName)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM dbo.Account WHERE UserName = N'" + userName + "'");
            foreach (DataRow item in data.Rows)
            {
                return new Account(item);
            }
            return null;
        }
        public bool UpdateAccount(string userName, string displayName, string password, string newPassword)
        {
            string query = "EXEC dbo.USP_UpdateAccount @userName , @displayName , @password , @newPassword ";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { userName, displayName, password, newPassword });
            return result > 0;
        }
        public DataTable GetAccountList()
        {
            return DataProvider.Instance.ExecuteQuery("SELECT UserName, DisplayName, Type FROM dbo.Account");
        }
        public bool AddNewAcount(string userName,string displayName , int type)
        {
            string query = string.Format("INSERT dbo.Account (UserName, DisplayName, Password, Type) VALUES (N'{0}', N'{1}', N'{2}', {3})", userName, displayName, "1962026656160185351301320480154111117132155", type);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool EditAccount(string userName, string displayName, int type)
        {
            string query = string.Format("UPDATE dbo.Account SET DisplayName = N'{0}', Type = {1} WHERE UserName = N'{2}'", displayName, type, userName);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteAccount(string name)
        {
            string query = String.Format("DELETE dbo.Account WHERE UserName = N'{0}' ",name);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool ResetPassword(string name)
        {
            string query = String.Format("UPDATE dbo.Account SET Password = N'1962026656160185351301320480154111117132155' WHERE UserName = N'{0}' ", name);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
    }
}
