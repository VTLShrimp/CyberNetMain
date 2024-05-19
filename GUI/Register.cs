using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CyberNet.GUI
{
    public partial class Register : Form
    {
        public Action FormClosedEvent { get; internal set; }

        public Register()
        {
            InitializeComponent();
        }

        private void Register_Load(object sender, EventArgs e)
        {
           StartPosition = FormStartPosition.CenterScreen;
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(UsernameText.Text))
            {
                MessageBox.Show("Chua co ten tai khoan", "thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (String.IsNullOrEmpty(EmailText.Text))
            {
                MessageBox.Show("Chua nhap mat khau", "thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string Connetdata = @"Data Source=LAMLMAO;Initial Catalog=Cyber_Database;Integrated Security=True";
                string username = UsernameText.Text;
                string password = EmailText.Text;
                string email = EmailText.Text;
                string money = MoneyBox.Text;
                string phone = SDTtxt.Text;
                DateTime date = DateTime.Now;
                string checkaccout = "select * from Customer_List where User_Name = '" + username + "'";
                SqlDataAdapter da = new SqlDataAdapter(checkaccout, Connetdata);
                DataSet data = new DataSet();
                da.Fill(data, "Customer_List");
                DataTable dt = data.Tables["Customer_List"];
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Tai khoan da co trong he thong", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                        string NewRegister = "insert into Customer_List (User_name, money, status, COM_using) values ('" + username + "','" + money + "','Offline','none')";
                        string list_register = "insert into Customer_Accout values ('" + username + "','" + password + "','"+email+"','"+phone+"','"+date+"')";
                        SqlConnection connection = new SqlConnection(Connetdata);
                        connection.Open();
                        SqlCommand UpNewUser = new SqlCommand(NewRegister, connection);
                        SqlCommand uptolist = new SqlCommand(list_register, connection);
                        UpNewUser.ExecuteNonQuery();
                        uptolist.ExecuteNonQuery();
                        connection.Close();
                        MessageBox.Show("Dang ky thanh cong", "Thong bao");
                        Close();
                }
            }
        }
    }
}
