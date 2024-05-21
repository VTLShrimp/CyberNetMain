using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace CyberNet.GUI
{
    public partial class Bao_cao : Form
    {
        private const string connectionString = "Data Source=NNVHG\\SQLEXPRESS;Initial Catalog=QLcybernet;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

        public Bao_cao()
        {
            InitializeComponent();
            InitializeListViewReport();
            InitializeListViewChiTiet();

            rbtndoanhthungay.CheckedChanged += RadioButton_CheckedChanged;
            rbtndoanhthuthang.CheckedChanged += RadioButton_CheckedChanged;
            rbtndoanhthunam.CheckedChanged += RadioButton_CheckedChanged;
            btnxem.Click += btnxem_Click;
            cbtuychon.SelectedIndexChanged += cbtuychon_SelectedIndexChanged;
            cbtuychon.SelectedIndex = 0;
        }

        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            cbthang.Enabled = !rbtndoanhthungay.Checked;
            cbnam.Enabled = rbtndoanhthunam.Checked;
        }

        private void btnxem_Click(object sender, EventArgs e)
        {
            listViewReport.Items.Clear();
            double tongGiaTien = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM HoatDong WHERE ";
                    string condition = "";
                    if (rbtndoanhthungay.Checked)
                    {
                        condition = "CONVERT(date, ThoiGianDangNhap) = @CurrentDate";
                    }
                    else if (rbtndoanhthuthang.Checked)
                    {
                        condition = "MONTH(ThoiGianDangNhap) = @Thang";
                    }
                    else if (rbtndoanhthunam.Checked)
                    {
                        condition = "YEAR(ThoiGianDangNhap) = @Nam";
                    }

                    query += condition;

                    SqlCommand command = new SqlCommand(query, connection);
                    if (rbtndoanhthungay.Checked)
                    {
                        command.Parameters.AddWithValue("@CurrentDate", DateTime.Now.ToString("yyyy-MM-dd"));
                    }
                    else if (rbtndoanhthuthang.Checked)
                    {
                        command.Parameters.AddWithValue("@Thang", cbthang.SelectedItem.ToString());
                    }
                    else if (rbtndoanhthunam.Checked)
                    {
                        command.Parameters.AddWithValue("@Nam", cbnam.SelectedItem.ToString());
                    }

                    SqlDataReader reader = command.ExecuteReader();

                    DataTable dataTable = new DataTable();
                    dataTable.Load(reader);
                    foreach (DataRow row in dataTable.Rows)
                    {
                        ListViewItem item = new ListViewItem(row["MaTaiKhoan"].ToString());
                        for (int i = 1; i < dataTable.Columns.Count; i++)
                        {
                            item.SubItems.Add(row[i].ToString());
                        }
                        listViewReport.Items.Add(item);
                        double giaTien;
                        if (double.TryParse(row["GiaTien"].ToString(), out giaTien))
                        {
                            tongGiaTien += giaTien;
                        }
                    }

                    connection.Close();

                    DisplayChart(dataTable);
                    txttong.Text = tongGiaTien.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void InitializeListViewReport()
        {
            listViewReport.View = View.Details;
            listViewReport.FullRowSelect = true;
            listViewReport.GridLines = true;
            listViewReport.Columns.Add("Mã Tài Khoản", 80, HorizontalAlignment.Left);
            listViewReport.Columns.Add("Mã Máy", 50, HorizontalAlignment.Left);
            listViewReport.Columns.Add("Thời Gian Đăng Nhập", 150, HorizontalAlignment.Left);
            listViewReport.Columns.Add("Thời Gian Đăng Xuất", 150, HorizontalAlignment.Left);
            listViewReport.Columns.Add("Tổng Thời Gian", 100, HorizontalAlignment.Left);
            listViewReport.Columns.Add("Gía Tiền", 100, HorizontalAlignment.Left);
            listViewReport.ItemSelectionChanged += ListViewReport_ItemSelectionChanged;
        }

        private void InitializeListViewChiTiet()
        {
            lvchitiet.View = View.Details;
            lvchitiet.FullRowSelect = true;
            lvchitiet.GridLines = true;
            lvchitiet.Columns.Add("Tên Tài Khoản", 100, HorizontalAlignment.Left);
            lvchitiet.Columns.Add("Tên Máy", 100, HorizontalAlignment.Left);
        }

        private void ListViewReport_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected)
            {
                string maTaiKhoan = e.Item.Text;
                LoadDataToListViewChiTiet(maTaiKhoan);
            }
        }

        private void LoadDataToListViewChiTiet(string maTaiKhoan)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT tk.TenTaiKhoan, m.TenMay " +
                                   "FROM HoatDong hd " +
                                   "JOIN May m ON hd.MaMay = m.MaMay " +
                                   "JOIN TaiKhoan tk ON hd.MaTaiKhoan = tk.MaTaiKhoan " +
                                   "WHERE hd.MaTaiKhoan = @MaTaiKhoan";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MaTaiKhoan", maTaiKhoan);
                    SqlDataReader reader = command.ExecuteReader();
                    lvchitiet.Items.Clear();
                    while (reader.Read())
                    {
                        ListViewItem item = new ListViewItem(reader["TenTaiKhoan"].ToString());
                        item.SubItems.Add(reader["TenMay"].ToString());
                        lvchitiet.Items.Add(item);
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void cbtuychon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbtuychon.SelectedItem.ToString() == "Danh sách")
            {
                listViewReport.Visible = true;
                txttimkiem.Visible = true;
                btntimkiem.Visible = true;
                lvchitiet.Visible = true;
                chartReport.Visible = false;
            }
            else if (cbtuychon.SelectedItem.ToString() == "Biểu đồ")
            {
                listViewReport.Visible = false;
                txttimkiem.Visible = false;
                btntimkiem.Visible = false;
                lvchitiet.Visible = false;
                chartReport.Visible = true;
            }
        }
        private void DisplayChart(DataTable dataTable)
        {
            chartReport.Series.Clear();
            chartReport.Series.Add("GiaTien");
            foreach (DataRow row in dataTable.Rows)
            {
                string ngay = row["ThoiGianDangNhap"].ToString();
                double giaTien;
                if (double.TryParse(row["GiaTien"].ToString(), out giaTien))
                {
                    chartReport.Series["GiaTien"].Points.AddXY(ngay, giaTien);
                }
            }
        }

        private int GetOldestLoginYear()
        {
            int oldestYear = DateTime.Now.Year;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT MIN(YEAR(ThoiGianDangNhap)) AS OldestYear FROM HoatDong";
                    SqlCommand command = new SqlCommand(query, connection);
                    object result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        oldestYear = Convert.ToInt32(result);
                    }

                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            return oldestYear;
        }

        private void Bao_cao_Load(object sender, EventArgs e)
        {
            for (int i = 1; i <= 12; i++)
            {
                cbthang.Items.Add(i);
            }

            int oldestYear = GetOldestLoginYear();

            int currentYear = DateTime.Now.Year;
            for (int year = oldestYear; year <= currentYear; year++)
            {
                cbnam.Items.Add(year);
            }

            if (cbtuychon.Items.Count > 0)
            {
                cbtuychon.SelectedIndex = 0;
            }
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            string keyword = txttimkiem.Text.Trim().ToLower();

            foreach (ListViewItem item in listViewReport.Items)
            {
                bool matched = false;

                foreach (ListViewItem.ListViewSubItem subItem in item.SubItems)
                {
                    if (subItem.Text.ToLower().Contains(keyword))
                    {
                        matched = true;
                        break;
                    }
                }

                item.Selected = matched;
                item.EnsureVisible();
            }
        }
    }
}