using CyberNet.DAO;
using CyberNet.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberNet.BUS
{
    internal class FoodBUS
    {
        public FoodDTO info { get; set; }
        private FoodDAO foodDAO = new FoodDAO();

        public DataTable loadFood()
        {
            return foodDAO.loadFood();
        }

        public DataTable loadfoodstatus(string Food_Status)
        {
            return foodDAO.loadfoodstatus(Food_Status);
        }

        public void UpdateFood(string Food_Name, string Food_Type, int Food_Price, string Food_Status,DateTime date)
        {
            foodDAO.UpdateFood(Food_Name, Food_Type, Food_Price, Food_Status,date);
        }

        public void InsertFood(string Food_Name, string Food_Type, int Food_Price, string Food_Status, DateTime date)
        {
            foodDAO.InsertFood(Food_Name, Food_Type, Food_Price, Food_Status, date);
        }

        public void DeleteFood(string Food_Name)
        {
            foodDAO.DeleteFood(Food_Name);
        }

        public void updatestatus(string Food_Name, string Food_Status)
        {
            foodDAO.updatestatus(Food_Name, Food_Status);
        }
    }
}
