using CyberNet.BUS;
using Lap6.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CyberNet.GUI
{
    public partial class AddFood : Form
    {
        private FoodBUS FoodBUS;
        public AddFood()
        {
            InitializeComponent();
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            if(guna2ComboBox1.Text == "Yes")
            {
                DataProvider.connectionString = "Data Source=LAMLMAO;Initial Catalog=Cyber_Database;Integrated Security=True";
                DataProvider dataProvider = new DataProvider();
                dataProvider.connect();
                string name = FoodNameTxt.Text;
                string type = FoodType.Text;
                int money = int.Parse(PriceTxt.Text);
                string onmenu = "On Menu";
                DateTime now = DateTime.Now;
                FoodBUS = new FoodBUS();
                FoodBUS.InsertFood(name, type, money, onmenu, now);
                Close();
            }
            else
            {
                DataProvider.connectionString = "Data Source=LAMLMAO;Initial Catalog=Cyber_Database;Integrated Security=True";
                DataProvider dataProvider = new DataProvider();
                dataProvider.connect();
                string name = FoodNameTxt.Text;
                string type = FoodType.Text;
                int money = int.Parse(PriceTxt.Text);
                string onmenu = "Off Menu";
                DateTime now = DateTime.Now;
                FoodBUS = new FoodBUS();
                FoodBUS.InsertFood(name, type, money, onmenu, now);
                Close();
            }
        }
    }
}
