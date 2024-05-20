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
    public partial class Quanlydichvu : Form
    {
        private DataTable dataTable;
        FoodBUS foodBUS ;

        public Quanlydichvu()
        {
            InitializeComponent();
            dbFood.CellEndEdit += dbFood_CellEndEdit;
            dbFood.CellBeginEdit += dbFood_CellBeginEdit;

        }
        
        private void Dinhdangluoi()
        {
            dbFood.ColumnHeadersHeight = 40;
            dbFood.Columns[0].HeaderText = "Tên dịch vụ";
            dbFood.Columns[1].HeaderText = "Loại dịch vụ";
            dbFood.Columns[2].HeaderText = "Giá dịch vụ";
            dbFood.Columns[3].HeaderText = "Tình trạng";
            dbFood.Columns[4].HeaderText = "Ngày cập nhật";
            dbFood.Columns[0].Width = 100;
            dbFood.Columns[1].Width = 100;
            dbFood.Columns[2].Width = 150;
            dbFood.Columns[3].Width = 100;
            dbFood.Columns[4].Width = 100;
            
        }


        private void Dinhdangmenu()
        {
            dbMenu.DataSource = foodBUS.loadfoodstatus("On Menu");
            dbMenu.ColumnHeadersHeight = 40;
            dbMenu.AutoGenerateColumns = false;

            dbMenu.Columns.Clear();
            
            var column1 = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Food_Name",
                HeaderText = "Tên dịch vụ",
                Width = 100
            };

            var column2 = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Food_Price",
                HeaderText = "Giá dịch vụ",
                Width = 150
            };

            // Add the columns to the collection
            dbMenu.Columns.Add(column1);
            dbMenu.Columns.Add(column2);

        }


        private void Quanlydichvu_Load(object sender, EventArgs e)
        {
            DataProvider.connectionString = "Data Source=LAMLMAO;Initial Catalog=Cyber_Database;Integrated Security=True";
            DataProvider provider = new DataProvider();
            provider.connect();
            foodBUS = new FoodBUS();
            dbFood.DataSource = foodBUS.loadFood();
            dbFood.ReadOnly = true;
            Dinhdangluoi();
            Dinhdangmenu();
        }
       
        private void dbFood_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
           
            DataGridViewRow row = dbFood.Rows[e.RowIndex];

           
            string foodName = row.Cells["Food_Name"].Value.ToString();
            string foodType = row.Cells["Food_Type"].Value.ToString();
            int foodPrice = int.Parse(row.Cells["Food_Price"].Value.ToString());
            string foodStatus = row.Cells["Food_Status"].Value.ToString();
            DateTime updatedDate = DateTime.Parse(row.Cells["Updated_Date"].Value.ToString());

           
            foodBUS.UpdateFood(foodName, foodType, foodPrice, foodStatus, updatedDate);

            dbFood.DataSource = foodBUS.loadFood();
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            AddFood addFood = new AddFood();
            addFood.ShowDialog();
        }


        private void dbFood_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            DataGridViewRow row = dbFood.Rows[e.RowIndex];


            if (row.ReadOnly)
            {
                
                e.Cancel = true;
            }
        }

        private void btnsua3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Ban co chac chan muon sua khong", "Thong bao", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                return;
            }
            else
            {
                DataGridViewRow selectedRow = dbFood.SelectedRows[0];
                selectedRow.ReadOnly = false;
            }
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            DialogResult a = MessageBox.Show("Ban co chac chan muon xoa khong", "Thong bao", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (a == DialogResult.No)
            {
                return;
            }
            else
            {
                DataGridViewSelectedCellCollection cell = dbFood.SelectedCells;
                if (cell.Count > 0)
                {
                    DataGridViewRow row = dbFood.Rows[cell[0].RowIndex];
                    string TenTaiKhoan = row.Cells["User_Name"].Value.ToString();
                    foodBUS.DeleteFood(TenTaiKhoan);
                    dbFood.DataSource = foodBUS.loadFood();
                }
            }
        }

        private void dbFood_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow selectedRow = dbFood.SelectedRows[0];
            string foodName = selectedRow.Cells["Food_Name"].Value.ToString();
            string status = selectedRow.Cells["Food_Status"].Value.ToString();
            DataProvider.connectionString = "Data Source=LAMLMAO;Initial Catalog=Cyber_Database;Integrated Security=True";
            DataProvider provider = new DataProvider();
            provider.connect();
            if (status == "On Menu")
            {
                DialogResult result = MessageBox.Show("Ban co chac chan muon xoa khoi menu khong", "Thong bao", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    return;
                }
                else
                {

                    foodBUS.updatestatus(foodName, "Off Menu");
                    dbFood.DataSource = foodBUS.loadFood();  
                    Dinhdangmenu();

                }
            }
            else
            {
                DialogResult result = MessageBox.Show("Ban co chac chan muon them vao menu khong", "Thong bao", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    return;
                }
                else
                {


                    foodBUS.updatestatus(foodName, "On Menu");
                    dbFood.DataSource = foodBUS.loadFood();
                    Dinhdangmenu();

                }
            }
        }

        private void Timkiembutton_Click(object sender, EventArgs e)
        {

        }

        private void cboSearch_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
