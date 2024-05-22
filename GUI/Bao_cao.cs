using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace CyberNet.GUI
{
    public partial class Bao_cao : Form
    {
        private const string connectionString = "Data Source=LAMLMAO;Initial Catalog=Cyber_Database;Integrated Security=True";

        public Bao_cao()
        {
            InitializeComponent();
            InitializeListViewReport();
            InitializeListViewChiTiet();

            // Gán sự kiện CheckedChanged cho các RadioButton
            rbtndoanhthungay.CheckedChanged += RadioButton_CheckedChanged;
            rbtndoanhthuthang.CheckedChanged += RadioButton_CheckedChanged;
            rbtndoanhthunam.CheckedChanged += RadioButton_CheckedChanged;

            // Mặc định chọn radiobutton ngày
            rbtndoanhthungay.Checked = true;

            // Gán sự kiện Click cho nút btnxem
            btnxem.Click += btnxem_Click;

            // Gán sự kiện SelectedIndexChanged cho cbtuychon
            cbtuychon.SelectedIndexChanged += cbtuychon_SelectedIndexChanged;

            // Đặt tùy chọn mặc định là "Danh sách"
            cbtuychon.SelectedIndex = 0;
        }

        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            cbthang.Enabled = !rbtndoanhthungay.Checked;
            cbnam.Enabled = rbtndoanhthunam.Checked;
        }

        private void btnxem_Click(object sender, EventArgs e)
        {
            // Xóa các mục hiện tại trong listViewReport để chuẩn bị cho việc cập nhật dữ liệu mới
            listViewReport.Items.Clear();

            // Khởi tạo biến tổng
            double tongGiaTien = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Mở kết nối
                    connection.Open();

                    // Tạo câu truy vấn dựa trên RadioButton được chọn và giá trị từ ComboBox
                    string query = "SELECT * FROM HoatDong WHERE ";
                    if (rbtndoanhthungay.Checked)
                    {
                        // Lấy thời gian hiện tại
                        DateTime currentTime = DateTime.Now;
                        string currentDate = currentTime.ToString("yyyy-MM-dd");

                        // Thêm điều kiện vào câu truy vấn
                        query += $"CONVERT(date, ThoiGianDangNhap) = '{currentDate}'";
                    }
                    else if (rbtndoanhthuthang.Checked)
                    {
                        // Lấy giá trị tháng từ ComboBox
                        int thang = int.Parse(cbthang.SelectedItem.ToString());

                        // Thêm điều kiện vào câu truy vấn
                        query += $"MONTH(ThoiGianDangNhap) = {thang}";
                    }
                    else if (rbtndoanhthunam.Checked)
                    {
                        // Lấy giá trị năm từ ComboBox
                        int nam = int.Parse(cbnam.SelectedItem.ToString());

                        // Thêm điều kiện vào câu truy vấn
                        query += $"YEAR(ThoiGianDangNhap) = {nam}";
                    }

                    // Thực hiện truy vấn SQL
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    // Đọc dữ liệu và thêm vào listViewReport
                    while (reader.Read())
                    {
                        ListViewItem item = new ListViewItem(reader["MaTaiKhoan"].ToString());
                        item.SubItems.Add(reader["MaMay"].ToString());
                        item.SubItems.Add(reader["ThoiGianDangNhap"].ToString());
                        item.SubItems.Add(reader["ThoiGianDangXuat"].ToString());
                        item.SubItems.Add(reader["TongThoiGianChoi"].ToString());
                        string giaTienStr = reader["GiaTien"].ToString();
                        item.SubItems.Add(giaTienStr);
                        listViewReport.Items.Add(item);

                        // Tính tổng giá trị GiaTien
                        double giaTien = double.Parse(giaTienStr);
                        tongGiaTien += giaTien;
                    }

                    // Đóng kết nối
                    connection.Close();

                    // Hiển thị biểu đồ dựa trên dữ liệu từ listViewReport
                    DisplayChart();

                    // Hiển thị tổng giá trị GiaTien lên txttong
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
            // Thiết lập các thuộc tính cơ bản cho listViewReport
            listViewReport.View = View.Details;
            listViewReport.FullRowSelect = true;
            listViewReport.GridLines = true;

            // Thêm các cột vào listViewReport
            listViewReport.Columns.Add("Mã Tài Khoản", 80, HorizontalAlignment.Left);
            listViewReport.Columns.Add("Mã Máy", 50, HorizontalAlignment.Left);
            listViewReport.Columns.Add("Thời Gian Đăng Nhập", 150, HorizontalAlignment.Left);
            listViewReport.Columns.Add("Thời Gian Đăng Xuất", 150, HorizontalAlignment.Left);
            listViewReport.Columns.Add("Tổng Thời Gian", 100, HorizontalAlignment.Left);
            listViewReport.Columns.Add("Gía Tiền", 100, HorizontalAlignment.Left);

            // Thêm sự kiện ItemSelectionChanged cho listViewReport
            listViewReport.ItemSelectionChanged += ListViewReport_ItemSelectionChanged;
        }

        private void InitializeListViewChiTiet()
        {
            // Thiết lập các thuộc tính cơ bản cho lvchitiet
            lvchitiet.View = View.Details;
            lvchitiet.FullRowSelect = true;
            lvchitiet.GridLines = true;

            // Thêm các cột vào lvchitiet
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
                    // Mở kết nối
                    connection.Open();

                    // Thực hiện truy vấn SQL với tham số maTaiKhoan
                    string query = "SELECT tk.TenTaiKhoan, m.TenMay " +
                                   "FROM HoatDong hd " +
                                   "JOIN May m ON hd.MaMay = m.MaMay " +
                                   "JOIN TaiKhoan tk ON hd.MaTaiKhoan = tk.MaTaiKhoan " +
                                   "WHERE hd.MaTaiKhoan = @MaTaiKhoan";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MaTaiKhoan", maTaiKhoan);
                    SqlDataReader reader = command.ExecuteReader();

                    // Xóa các mục hiện tại trong lvchitiet
                    lvchitiet.Items.Clear();

                    // Đọc dữ liệu và thêm vào lvchitiet
                    while (reader.Read())
                    {
                        ListViewItem item = new ListViewItem(reader["TenTaiKhoan"].ToString());
                        item.SubItems.Add(reader["TenMay"].ToString());
                        lvchitiet.Items.Add(item);
                    }

                    // Đóng kết nối
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
                // Hiển thị listViewReport, btntimkiem, txttimkiem và lvchitiet
                listViewReport.Visible = true;
                txttimkiem.Visible = true;
                btntimkiem.Visible = true;
                lvchitiet.Visible = true;
                chartReport.Visible = false;
            }
            else if (cbtuychon.SelectedItem.ToString() == "Biểu đồ")
            {
                // Ẩn listViewReport, btntimkiem, txttimkiem và lvchitiet
                listViewReport.Visible = false;
                txttimkiem.Visible = false;
                btntimkiem.Visible = false;
                lvchitiet.Visible = false;
                chartReport.Visible = true;

                // Hiển thị biểu đồ dựa trên dữ liệu từ listViewReport
                DisplayChart();
            }
        }

        private void DisplayChart()
        {
            // Xóa dữ liệu cũ của biểu đồ
            chartReport.Series.Clear();

            // Thêm series mới cho biểu đồ
            chartReport.Series.Add("GiaTien");

            // Lặp qua các mục trong listViewReport và thêm dữ liệu vào biểu đồ
            foreach (ListViewItem item in listViewReport.Items)
            {
                string ngay = item.SubItems[2].Text; // Thời gian đăng nhập là cột thứ 3 trong listViewReport
                double giaTien = double.Parse(item.SubItems[5].Text); // GiaTien là cột thứ 6 trong listViewReport

                chartReport.Series["GiaTien"].Points.AddXY(ngay, giaTien);
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
            // Thêm các tháng từ 1 đến 12 vào ComboBox tháng
            for (int i = 1; i <= 12; i++)
            {
                cbthang.Items.Add(i);
            }

            // Xác định năm của lần đăng nhập cũ nhất
            int oldestYear = GetOldestLoginYear();

            // Thêm các năm từ năm cũ nhất đến năm hiện tại vào ComboBox năm
            int currentYear = DateTime.Now.Year;
            for (int year = oldestYear; year <= currentYear; year++)
            {
                cbnam.Items.Add(year);
            }

            // Đặt tùy chọn mặc định là "Danh sách" nếu có ít nhất một mục trong ComboBox
            if (cbtuychon.Items.Count > 0)
            {
                cbtuychon.SelectedIndex = 0;
            }
        }

        private void btntimkiem_Click(object sender, EventArgs e)
        {
            string keyword = txttimkiem.Text.Trim().ToLower(); // Lấy nội dung từ txttimkiem và chuẩn hóa về chữ thường

            // Duyệt qua các mục trong listViewReport và tìm kiếm các mục phù hợp với từ khóa
            foreach (ListViewItem item in listViewReport.Items)
            {
                bool matched = false;

                // Duyệt qua từng cột trong mỗi mục
                foreach (ListViewItem.ListViewSubItem subItem in item.SubItems)
                {
                    // Kiểm tra nội dung của cột có chứa từ khóa không
                    if (subItem.Text.ToLower().Contains(keyword))
                    {
                        matched = true;
                        break;
                    }
                }

                // Nếu một mục được tìm thấy khớp với từ khóa, hiển thị nó, ngược lại ẩn đi
                item.Selected = matched;
                item.EnsureVisible(); // Đảm bảo mục được hiển thị trên ListView
            }
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnxem_Click_1(object sender, EventArgs e)
        {

        }
    }
}
