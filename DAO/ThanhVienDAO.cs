using Lap6.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberNet.DTO
{
    internal class ThanhVienDAO
    {
        private DataProvider dataProvider = new DataProvider();

        public ThanhVienDAO()
        {
            dataProvider.connect();
        }

        public DataTable LoadThanhVien()
        {
            string sql = "select * from Customer_Accout"; // Changed table name to Customer_Accout
            return dataProvider.executeQuery(sql);
        }

        public DataTable LoadThanhVien(string User_Name)
        {
            string sql = "select * from Customer_Accout where User_Name = '" + User_Name + "'"; // Changed table name to Customer_Accout
            return dataProvider.executeQuery(sql);
        }

        public DataTable RechargeHistory(string User_Name)
        {
            string sql = "select * from RechargeHistory where User_Name = '" + User_Name + "'";
            return dataProvider.executeQuery(sql);
        }

        public void InsertThanhVien(string User_Name, string Password, string Email, string Phone, DateTime date)
        {
            string sql = "insert into Customer_Accout values('" + User_Name + "','" + Password + "','" + Email + "','" + Phone + "',DateCreate = '"+date+"'  where User_Name = '"; // Changed table name to Customer_Accout
            dataProvider.executeQuery(sql);
        }

        public void UpdateThanhVien(string User_Name, string Password, string Email, string Phone)
        {
            string sql = "update Customer_Accout set Password = '" + Password + "', Email = '" + Email + "', PhoneNumber = '" + Phone + "' where User_Name = '" + User_Name + "'"; // Changed table name to Customer_Accout
            dataProvider.executeQuery(sql);
        }

        public void DeleteThanhVien(string User_Name)
        {
            string sql = "delete from Customer_Accout where User_Name = '" + User_Name + "'"; // Changed table name to Customer_Accout
            dataProvider.executeNonQuery(sql);
        }

        public bool CheckThanhVien(string User_Name)
        {
            string sql = "select * from Customer_Accout where User_Name = '" + User_Name + "'"; // Changed table name to Customer_Accout
            if (dataProvider.executeQuery(sql).Rows.Count > 0)
            {
                return true;
            }
            return false;
        }

        public void SearchThanhVien(string User_Name)
        {
            string sql = "select * from Customer_Accout where User_Name = '" + User_Name + "'"; // Changed table name to Customer_Accout
            dataProvider.executeQuery(sql);
        }
    }
}
