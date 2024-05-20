using Lap6.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberNet.DAO
{
    internal class FoodDAO
    {
        private DataProvider dataProvider = new DataProvider();
        

        public FoodDAO()
        {
            dataProvider.connect();
        }

        public DataTable loadFood()
        {
            string sql = "select * from Food_List";
            return dataProvider.executeQuery(sql);
        }   

        public DataTable loadfoodstatus(string Food_Status)
        {
            string sql = "select * from Food_List where Food_Status = '" + Food_Status + "'";
            return dataProvider.executeQuery(sql);
        }
        public void UpdateFood(string Food_Name, string Food_Type, int Food_Price, string Food_Status , DateTime date)
        {
            string sql = "update Food_List set Food_Type = '" + Food_Type + "', Food_Price = '" + Food_Price + "', Food_Status = '" + Food_Status + ",Date_add ='"+date+"' ' where Food_Name = '" + Food_Name + "'";
            dataProvider.executeNonQuery(sql);
        }
        public void InsertFood(string Food_Name, string Food_Type, int Food_Price, string Food_Status,DateTime date)
        {
            string sql = "insert into Food_List values('" + Food_Name + "','" + Food_Type + "','" + Food_Price + "','" + Food_Status + "','"+date+"')";
            dataProvider.executeNonQuery(sql);
        }

        public void DeleteFood(string Food_Name)
        {
            string sql = "delete from Food_List where Food_Name = '" + Food_Name + "'";
            dataProvider.executeNonQuery(sql);
        }

        public DataTable SreachFoodwithname(string Food_Name)
        {
            string sql = "select * from Food_List where Food_Name LIKE '%" + Food_Name + "%'";
            return dataProvider.executeQuery(sql);
        }   

        public DataTable SreachFood(string Food_Name , string status)
        {
            string sql = "select * from Food_List where Food_Name LIKE '%" + Food_Name + "%' and  Food_Status = '" + status + "'  ";
            return dataProvider.executeQuery(sql);
        }

        public void updatestatus(string Food_Name, string Food_Status)
        {
            string sql = "update Food_List set Food_Status = '" + Food_Status + "' where Food_Name = '" + Food_Name + "'";
            dataProvider.executeNonQuery(sql);
        }
    }
}
