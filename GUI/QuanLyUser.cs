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
    public partial class QuanLyUser : Form
    {

        
        ThanhVienListBUS ThanhVienListBUS;
       
        public QuanLyUser()
        {
            InitializeComponent();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
        }

        private void DinhDangLuoi()
        {
            dgThanhvien.ColumnHeadersHeight = 40;
            dgThanhvien.Columns[0].HeaderText = "Tên tài khoản";
            dgThanhvien.Columns[0].Width = 130;
            dgThanhvien.Columns[1].HeaderText = "Số tiền";
            dgThanhvien.Columns[1].Width = 100;
            dgThanhvien.Columns[2].HeaderText = "Tình trạng";
            dgThanhvien.Columns[2].Width = 90;
            dgThanhvien.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgThanhvien.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgThanhvien.Columns[3].HeaderText = "Máy đang dùng";
            dgThanhvien.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgThanhvien.Columns[3].Width = 130;
            dgThanhvien.Columns[4].HeaderText = "Ngày đăng nhập cuối";
            dgThanhvien.Columns[4].Width = 150;
        }

        private void DinhangLichsu()
        {
            dgLichsu.ColumnHeadersHeight = 40;
            dgLichsu.Columns[0].HeaderText = "Tên tài khoản";
            dgLichsu.Columns[0].Width = 130;
            dgLichsu.Columns[1].HeaderText = "Số tiền";
            dgLichsu.Columns[1].Width = 100;
            dgLichsu.Columns[2].HeaderText = "Ngày nạp";
            dgLichsu.Columns[2].Width = 150;
        }

        private void DinhDangYeucau()
        {
            dgYeuCau.ColumnHeadersHeight = 40;
            dgYeuCau.Columns[0].HeaderText = "Tên tài khoản";
            dgYeuCau.Columns[0].Width = 130;
            dgYeuCau.Columns[1].HeaderText = "Số tiền";
            dgYeuCau.Columns[1].Width = 100;
            dgYeuCau.Columns[2].HeaderText = "Ngày yêu cầu";
            dgYeuCau.Columns[2].Width = 150;
        }


        private void QuanLyUser_Load(object sender, EventArgs e)
        {
            DataProvider.connectionString = "Data Source=LAMLMAO;Initial Catalog=Cyber_Database;Integrated Security=True";
            DataProvider provider = new DataProvider();
            provider.connect();
            ThanhVienListBUS = new ThanhVienListBUS();
            dgThanhvien.DataSource = ThanhVienListBUS.LoadThanhVien();
            DinhDangLuoi();
            int tong = dgThanhvien.RowCount;
            txttong.Text = tong.ToString();
            dgYeuCau.DataSource = ThanhVienListBUS.LoadRequest();
            DinhDangYeucau();
        }

        private void dgThanhvien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewSelectedCellCollection cell = dgThanhvien.SelectedCells;
            if (cell.Count > 0)
            {
                DataGridViewRow row = dgThanhvien.Rows[cell[0].RowIndex];
                string TenTaiKhoan = row.Cells["User_Name"].Value.ToString();
                dgLichsu.DataSource = ThanhVienListBUS.RechargeHistory(TenTaiKhoan);
                DinhangLichsu();

            }
        }

        private void dgThanhvien_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow selectedRow = dgThanhvien.CurrentRow;
            if (selectedRow != null)
            {

                string userName = selectedRow.Cells["User_Name"].Value.ToString();
                NapTien napTien = new NapTien(userName);
                napTien.FormClosedEvent += ReloadData;
                napTien.ShowDialog();
            }
        }

     
        private void ReloadData()
        {
            DataProvider.connectionString = "Data Source=LAMLMAO;Initial Catalog=Cyber_Database;Integrated Security=True";
            DataProvider provider = new DataProvider();
            provider.connect();
            ThanhVienListBUS = new ThanhVienListBUS();
          
            dgThanhvien.DataSource = ThanhVienListBUS.LoadThanhVien();
            DataGridViewSelectedCellCollection cell = dgThanhvien.SelectedCells;
            if (cell.Count > 0)
            {
                DataGridViewRow row = dgThanhvien.Rows[cell[0].RowIndex];
                string TenTaiKhoan = row.Cells["User_Name"].Value.ToString();
                dgLichsu.DataSource = ThanhVienListBUS.RechargeHistory(TenTaiKhoan);

            }
            dgYeuCau.DataSource = ThanhVienListBUS.LoadRequest();
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
                DataGridViewSelectedCellCollection cell = dgThanhvien.SelectedCells;
                if (cell.Count > 0)
                {
                    DataGridViewRow row = dgThanhvien.Rows[cell[0].RowIndex];
                    string TenTaiKhoan = row.Cells["User_Name"].Value.ToString();
                    ThanhVienListBUS.delete(TenTaiKhoan);
                    dgThanhvien.DataSource = ThanhVienListBUS.LoadThanhVien();
                }
            }
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            Register register = new Register();
            register.FormClosedEvent += ReloadData;
            register.ShowDialog();
        }

        private void cbbtuychinh_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cbbtuychinh.SelectedItem.ToString() == "Offline")
            {
                dgThanhvien.DataSource = ThanhVienListBUS.SreachStatusThanhVien("Offline");
            }
            else if (cbbtuychinh.SelectedItem.ToString() == "Online")
            {
                dgThanhvien.DataSource = ThanhVienListBUS.SreachStatusThanhVien("Online");
            }
            else
            {
                dgThanhvien.DataSource = ThanhVienListBUS.LoadThanhVien();
            }
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txttimkiem.Text))
            {
                dgThanhvien.DataSource = ThanhVienListBUS.LoadThanhVien();
            }
            else
            {
                string username = txttimkiem.Text;
                dgThanhvien.DataSource = ThanhVienListBUS.SreachThanhVien(username);
            }
            int tong = dgThanhvien.RowCount;
            txttong.Text = tong.ToString();
        }

        private void guna2DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string money = dgYeuCau.CurrentRow.Cells["Money"].Value.ToString();
            decimal tempMoney = Convert.ToDecimal(money);
            int finalMoney = Convert.ToInt32(tempMoney);
            DataGridViewRow selectedRow = dgYeuCau.CurrentRow;
            if (selectedRow != null)
            {
                string userName = selectedRow.Cells["User_Name"].Value.ToString();
                NapTien napTien = new NapTien(userName)
                {
                    money = Convert.ToInt32(finalMoney)
                };
                napTien.FormClosedEvent += ReloadData;
                napTien.ShowDialog();
            }
        }
    }
}
