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
    public partial class YeuCauNapTien : Form
    {
        public YeuCauNapTien()
        {
            InitializeComponent();
        }
        public string UserName { get; set; }

        private void YeuCauNapTien_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string money = guna2TextBox1.Text;
            DataProvider.connectionString = @"Data Source=LAMLMAO;Initial Catalog=Cyber_Database;Integrated Security=True";
            DataProvider dataProvider = new DataProvider();
            dataProvider.connect();
            ThanhVienListBUS thanhvienListBUS = new ThanhVienListBUS();
            thanhvienListBUS.UpRechargeRequest(UserName, int.Parse(money));
        }
    }
}
