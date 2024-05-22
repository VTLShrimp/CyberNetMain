using CyberNet.GUI;
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

namespace CyberNet
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        public string Username { get; set; }
        private void Login_Load(object sender, EventArgs e)
        {
           
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            if (UserText.Text == "Enter your name")
            {
                MessageBox.Show("Chua nhap tai khoan", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (PassWordTextBox.Text == "Enter your password")
            {
                MessageBox.Show("Chua nhap mat khau", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    string Connetdata = @"Data Source=LAMLMAO;Initial Catalog=Cyber_Database;Integrated Security=True";
                    string username = UserText.Text;
                    string password = PassWordTextBox.Text;
                    string checkAccout = "select * from Customer_Accout where User_Name = '" + username + "' and Password = '" + password + "'";
                    string checkAdmin = "select * from Customer_Accout where User_Name = '" + username + "' and Password = '" + password + "' and Type = '"+"Admin"+"'";    
                    SqlDataAdapter adapter = new SqlDataAdapter(checkAccout, Connetdata);
                    DataSet data = new DataSet();
                    adapter.Fill(data, "Customer_Accout");
                    DataTable dt = data.Tables["Customer_Accout"];
                    if (dt.Rows.Count > 0)
                    {
                        data.Dispose();
                        adapter.Dispose();
                        adapter = new SqlDataAdapter(checkAdmin, Connetdata);
                        data = new DataSet();
                        adapter.Fill(data, "Admin_Accout");
                        dt = data.Tables["Admin_Accout"];
                        if (dt.Rows.Count > 0)
                        {
                            MessageBox.Show("Dang nhap Admin thanh cong", "Thong bao", MessageBoxButtons.OK);
                            NewAdmin list = new NewAdmin();
                            list.Show();
                            Hide();
                        }
                        else
                        {
                            MessageBox.Show("Dang nhap thanh cong", "Thong bao", MessageBoxButtons.OK);
                            User list = new User();
                            list.UserName = username;
                            list.Show();
                            Hide();
                        }
                   
                    }
                    else
                    {
                        MessageBox.Show("Sai tai khoan hoac mat khau", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch
                {
                    MessageBox.Show("Co loi xay ra", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void UserText_Enter(object sender, EventArgs e)
        {
            if (UserText.Text == "Enter your name")
            {
                UserText.Text = "";
            }
            UserText.ForeColor = Color.Black;
        }

        private void UserText_Leave(object sender, EventArgs e)
        {
            if (UserText.Text == "")
            {
                UserText.Text = "Enter your name";
            }
            UserText.ForeColor = Color.Gray;
        }

        private void PassWordTextBox_Enter(object sender, EventArgs e)
        {
            if (PassWordTextBox.Text == "Enter your password")
            {
                PassWordTextBox.Text = null;
                PassWordTextBox.PasswordChar = '*';
            }
            PassWordTextBox.ForeColor = Color.Black;

            if (ShowPass.Checked == true)
            {
                PassWordTextBox.PasswordChar = '\0';
            }
        }

        private void PassWordTextBox_Leave(object sender, EventArgs e)
        {
            if (PassWordTextBox.Text == "")
            {
                PassWordTextBox.Text = "Enter your password";
                PassWordTextBox.PasswordChar = '\0';
            }
            PassWordTextBox.ForeColor = Color.Gray;
        }

        private void ShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if (ShowPass.Checked)
            {
                PassWordTextBox.PasswordChar = '\0';
            }
            else
            {
                if (PassWordTextBox.Text != "Enter your password")
                {
                    PassWordTextBox.PasswordChar = '*';
                }
            }
        }

        private void UserText_TextChanged(object sender, EventArgs e)
        {

        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
