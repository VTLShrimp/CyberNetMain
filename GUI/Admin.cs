using CyberNet.BUS;
using CyberNet.DTO;
using CyberNet.GUI;
using Lap6.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Windows.Forms;
namespace CyberNet
{
    public partial class Admin : Form
    {
        ThanhVienBUS ThanhVienBUS;
        ThanhVienListBUS ThanhVienListBUS;
        LichSuBUS lichSuBUS;
        private bool isInitialized = false;
        private readonly List<MayTinh> customControls = new List<MayTinh>();

        public Admin()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        public void countmay()
        {
            int online = 0;
            int offline = 0;
            for(int i = 0; i < customControls.Count; i++)
            {
                if (customControls[i].IsActive)
                {
                    online++;
                }
                else
                {
                    offline++;
                }
            }
            label8.Text = online.ToString();
            label7.Text = offline.ToString();
            label9.Text = customControls.Count.ToString();
        }


        private void KhoiTaoMay()
        {
            if (isInitialized)
            {
                return;
            }
            for (int i = 0; i < 100; i++)
            {
                var item = new MayTinh();
                item.setText($"Máy "+ $"{i + 1:00}");
                customControls.Add(item);
                flowLayoutPanel1.Controls.Add(item);
            }
            isInitialized = true;
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.FlowDirection = FlowDirection.LeftToRight; // Hiển thị từ trái phải
            flowLayoutPanel1.WrapContents = true;
            flowLayoutPanel1.Padding = new Padding(10); // Khoảng cách giữa các custom control
            flowLayoutPanel1.AutoSize = false;
            comboBox1.SelectedIndex = 0;
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


        private void Admin_Load(object sender, EventArgs e)
        {
            DataProvider.connectionString = "Data Source=LAMLMAO;Initial Catalog=Cyber_Database;Integrated Security=True";
            DataProvider provider = new DataProvider();
            provider.connect();
            ThanhVienListBUS = new ThanhVienListBUS();
            dgThanhvien.DataSource = ThanhVienListBUS.LoadThanhVien();
            DinhDangLuoi();
            int tong = dgThanhvien.RowCount; 
            txttong.Text = tong.ToString();
            KhoiTaoMay();
            countmay();
            Console.WriteLine("Admin loaded");
        }
        private void btnthem_Click(object sender, EventArgs e)
        {
            Register register = new Register();
            register.ShowDialog();
        }

        private void dgThanhvien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewSelectedCellCollection cell = dgThanhvien.SelectedCells;
            if(cell.Count > 0)
            {
               DataGridViewRow row = dgThanhvien.Rows[cell[0].RowIndex];
               string TenTaiKhoan = row.Cells["User_Name"].Value.ToString();
               dgLichsu.DataSource = ThanhVienListBUS.RechargeHistory(TenTaiKhoan);
                
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
                    ThanhVienBUS.delete(TenTaiKhoan);
                    ThanhVienListBUS.delete(TenTaiKhoan);
                    dgThanhvien.DataSource = ThanhVienListBUS.LoadThanhVien();
                }
            }
        }

        private void btnsua_Click(object sender, EventArgs e)
        {

        }

        private void cbbtuychinh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbtuychinh.SelectedItem.ToString()== "Offline")
            {
                dgThanhvien.DataSource = ThanhVienListBUS.SreachStatusThanhVien("Offline");
            }
            else if(cbbtuychinh.SelectedItem.ToString() == "Online")
            {
                dgThanhvien.DataSource = ThanhVienListBUS.SreachStatusThanhVien("Online");
            }
            else
            {
                dgThanhvien.DataSource = ThanhVienListBUS.LoadThanhVien();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (customControls.Count() < 1)
            {
                return;
            }

            var selectText = comboBox1.SelectedItem.ToString();
            if (selectText == "Tất cả")
            {
                flowLayoutPanel1.Controls.Clear();
                foreach (var item in customControls)
                {
                    flowLayoutPanel1.Controls.Add(item);
                }
                countmay();
            }
            else if (selectText == "Online")
            {
                flowLayoutPanel1.Controls.Clear();
                foreach (var item in customControls.Where(x => x.IsActive))
                {
                    flowLayoutPanel1.Controls.Add(item);
                }
                countmay();
            }
            else
            {
                flowLayoutPanel1.Controls.Clear();
                foreach (var item in customControls.Where(x => !x.IsActive))
                {
                    flowLayoutPanel1.Controls.Add(item);
                }
                countmay();
            }
        }

        private void dgThanhvien_DoubleClick(object sender, EventArgs e)
        {
           
        }

        private void ReloadData()
        {
            DataProvider.connectionString = "Data Source=LAMLMAO;Initial Catalog=Cyber_Database;Integrated Security=True";
            DataProvider provider = new DataProvider();
            provider.connect();
            ThanhVienListBUS = new ThanhVienListBUS();
            lichSuBUS = new LichSuBUS();
            dgThanhvien.DataSource = ThanhVienListBUS.LoadThanhVien();
            DataGridViewSelectedCellCollection cell = dgThanhvien.SelectedCells;
            if (cell.Count > 0)
            {
                DataGridViewRow row = dgThanhvien.Rows[cell[0].RowIndex];
                string TenTaiKhoan = row.Cells["User_Name"].Value.ToString();
                dgLichsu.DataSource = ThanhVienListBUS.RechargeHistory(TenTaiKhoan);

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

        private void đăngNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
