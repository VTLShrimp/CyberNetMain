using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CyberNet.BUS;
using CyberNet.DTO;
using CyberNet.GUI;
using Lap6.DAO;

namespace CyberNet.GUI
{
    public partial class NapTien : Form
    {
        public event Action FormClosedEvent;

        ThanhVienListBUS thanhVienListBUS = new ThanhVienListBUS();
        LichSuBUS lichSuBUS = new LichSuBUS();
        string username;
        public NapTien()
        {
            InitializeComponent();
        }
        public NapTien(string user_name)
        {
            InitializeComponent();
            username = user_name;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            DataProvider.connectionString = "Data Source=LAMLMAO;Initial Catalog=Cyber_Database;Integrated Security=True";
            DataProvider dataProvider = new DataProvider();
            dataProvider.connect();
            thanhVienListBUS.Recharge(username, Convert.ToInt32(guna2TextBox1.Text));
            lichSuBUS.insertRecharge(username, Convert.ToInt32(guna2TextBox1.Text));
            Close();
        }

        private void NapTien_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormClosedEvent?.Invoke();
        }
    }
}
