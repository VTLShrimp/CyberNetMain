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
        public Quanlydichvu()
        {
            InitializeComponent();
            InitializeDataTable();
        }
        private void InitializeDataTable()
        {
            dataTable = new DataTable();
            dataTable.Columns.Add("Name", typeof(string));
            dataTable.Columns.Add("Loai", typeof(int));
            dataTable.Columns.Add("Gia", typeof(int));
            dataTable.Columns.Add("Soluong", typeof(int));
            // Gắn DataTable với dataGridView1
            dataGridView1.DataSource = dataTable;
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            // Thêm một hàng mới với dữ liệu từ các TextBox
            dataTable.Rows.Add(int.Parse(txtFoodName.Text), textBox7.Text, int.Parse(txtPriceUnitOfFood.Text), int.Parse(txtInventoryNumberOfFood.Text));
            // Xóa dữ liệu từ các TextBox sau khi thêm
            txtFoodName.Clear();
            textBox7.Clear();
            txtPriceUnitOfFood.Clear();
            txtInventoryNumberOfFood.Clear();
        }

        private void cboFoodCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            // Hiển thị thông tin của hàng được chọn trong các TextBox
            if (dataGridView1.SelectedCells.Count > 0)
            {
                int selectedRowIndex = dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[selectedRowIndex];
                txtFoodName.Text = selectedRow.Cells["Name"].Value.ToString();
                textBox7.Text = selectedRow.Cells["Loai"].Value.ToString();
                txtPriceUnitOfFood.Text = selectedRow.Cells["Gia"].Value.ToString();
                txtInventoryNumberOfFood.Text = selectedRow.Cells["Soluong"].Value.ToString();
            }
        }

        private void btnsua3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                int selectedRowIndex = dataGridView1.SelectedCells[0].RowIndex;
                dataGridView1.Rows[selectedRowIndex].Cells["Name"].Value = int.Parse(txtFoodName.Text);
                dataGridView1.Rows[selectedRowIndex].Cells["Loai"].Value = textBox7.Text;
                dataGridView1.Rows[selectedRowIndex].Cells["Gia"].Value = int.Parse(txtPriceUnitOfFood.Text);
                dataGridView1.Rows[selectedRowIndex].Cells["Soluong"].Value = int.Parse(txtInventoryNumberOfFood.Text);
            }
        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                if (!row.IsNewRow)
                {
                    dataGridView1.Rows.Remove(row);
                }
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}
