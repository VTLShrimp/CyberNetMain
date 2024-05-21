using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CyberNet.GUI
{
    public partial class Form1 : Form
    {
        private const string connectionString = "Data Source=NNVHG\\SQLEXPRESS;Initial Catalog=QLcybernet;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

        public Form1()
        {
            InitializeComponent();
            InitializeListView1();
            InitializeListView2();

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
            // Xóa các mục hiện tại trong ListView1 để chuẩn bị cho việc cập nhật dữ liệu mới
            listView1.Items.Clear();

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

                    // Đọc dữ liệu và thêm vào ListView1
                    while (reader.Read())
                    {
                        ListViewItem item = new ListViewItem(reader["MaTaiKhoan"].ToString());
                        item.SubItems.Add(reader["MaMay"].ToString());
                        item.SubItems.Add(reader["ThoiGianDangNhap"].ToString());
                        item.SubItems.Add(reader["ThoiGianDangXuat"].ToString());
                        item.SubItems.Add(reader["TongThoiGianChoi"].ToString());
                        item.SubItems.Add(reader["GiaTien"].ToString());
                        listView1.Items.Add(item);
                    }

                    // Đóng kết nối
                    connection.Close();

                    // Hiển thị biểu đồ dựa trên dữ liệu từ ListView1
                    DisplayChart();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void InitializeListView1()
        {
            // Thiết lập các thuộc tính cơ bản cho ListView1
            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.GridLines = true;

            // Thêm các cột vào ListView1
            listView1.Columns.Add("Mã Tài Khoản", 80, HorizontalAlignment.Left);
            listView1.Columns.Add("Mã Máy", 50, HorizontalAlignment.Left);
            listView1.Columns.Add("Thời Gian Đăng Nhập", 150, HorizontalAlignment.Left);
            listView1.Columns.Add("Thời Gian Đăng Xuất", 150, HorizontalAlignment.Left);
            listView1.Columns.Add("Tổng Thời Gian", 100, HorizontalAlignment.Left);
            listView1.Columns.Add("Gía Tiền", 100, HorizontalAlignment.Left);

            // Thêm sự kiện ItemSelectionChanged cho ListView1
            listView1.ItemSelectionChanged += ListView1_ItemSelectionChanged;
        }

        private void InitializeListView2()
        {
            // Thiết lập các thuộc tính cơ bản cho ListView2
            listView2.View = View.Details;
            listView2.FullRowSelect = true;
            listView2.GridLines = true;

            // Thêm các cột vào ListView2
            listView2.Columns.Add("Tên Tài Khoản", 100, HorizontalAlignment.Left);
            listView2.Columns.Add("Tên Máy", 100, HorizontalAlignment.Left);
        }

        private void ListView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected)
            {
                string maTaiKhoan = e.Item.Text;
                LoadDataToListView2(maTaiKhoan);
            }
        }

        private void LoadDataToListView2(string maTaiKhoan)
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
                                   "JOIN TaiKhoan tk ON hd.MaTaiKhoan = tk.MaTaiKhoan " + // Thêm khoảng trắng trước WHERE
                                   "WHERE hd.MaTaiKhoan = @MaTaiKhoan";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MaTaiKhoan", maTaiKhoan);
                    SqlDataReader reader = command.ExecuteReader();
                    // Xóa các mục hiện tại trong ListView2
                    listView2.Items.Clear();

                    // Đọc dữ liệu và thêm vào ListView2
                    while (reader.Read())
                    {
                        ListViewItem item = new ListViewItem(reader["TenTaiKhoan"].ToString());
                        item.SubItems.Add(reader["TenMay"].ToString());
                        listView2.Items.Add(item);
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
                // Hiển thị listview1, btntimkiem, txttimkiem và ẩn biểu đồ
                listView1.Visible = true;
                listView2.Visible = true;
                txttimkiem.Visible = true;
                btntimkiem.Visible = true;
                chart1.Visible = false;
            }
            else if (cbtuychon.SelectedItem.ToString() == "Biểu đồ")
            {
                // Ẩn listview1, btntimkiem, txttimkiem và hiển thị biểu đồ
                listView1.Visible = false;
                listView2.Visible = false;
                txttimkiem.Visible = false;
                btntimkiem.Visible = false;
                chart1.Visible = true;

                // Hiển thị biểu đồ dựa trên dữ liệu từ ListView1
                DisplayChart();
            }
        }

        private void DisplayChart()
        {
            // Xóa dữ liệu cũ của biểu đồ
            chart1.Series.Clear();

            // Thêm series mới cho biểu đồ
            chart1.Series.Add("GiaTien");

            // Lặp qua các mục trong ListView1 và thêm dữ liệu vào biểu đồ
            foreach (ListViewItem item in listView1.Items)
            {
                string ngay = item.SubItems[2].Text; // Thời gian đăng nhập là cột thứ 3 trong ListView1
                double giaTien = double.Parse(item.SubItems[5].Text); // GiaTien là cột thứ 6 trong ListView1

                chart1.Series["GiaTien"].Points.AddXY(ngay, giaTien);
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


        private void Form1_Load(object sender, EventArgs e)
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

    }
}
