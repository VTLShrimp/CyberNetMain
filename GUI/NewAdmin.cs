using CyberNet.GUI.Control;
using Guna.UI2.WinForms;
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
    public partial class NewAdmin : Form
    {
        private QuanLyMay quanLyMayForm = new QuanLyMay();
        private QuanLyUser quanLyUserForm = new QuanLyUser();
        private StaticView staticView = new StaticView();   
        private Quanlydichvu chatView = new Quanlydichvu(); 
        public NewAdmin()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            guna2PictureBox6.Click += new EventHandler(Computer_button_Click);
        }

        private Form currentChildForm;

        private void OpenChildForm(Form childForm)
        {
            if (currentChildForm != null)
            {
                currentChildForm.Hide();
            }
            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            guna2Panel3.Controls.Add(childForm);
            guna2Panel3.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void ResetButtonBorder()
        {
            Computer_button.BorderThickness = 0;
            User_button.BorderThickness = 0;
            Static_button.BorderThickness = 0;
            Chat_button.BorderThickness = 0;
        }
        private void HighlightButton(Guna2Button button)
        {
            ResetButtonBorder();
            button.BorderThickness = 2;
            button.BorderColor = Color.Black;
        }

        private void Computer_button_Click(object sender, EventArgs e)
        {
            OpenChildForm(quanLyMayForm);
            HighlightButton(Computer_button);

        }

        private void User_button_Click(object sender, EventArgs e)
        {
            OpenChildForm(quanLyUserForm);
            HighlightButton(User_button);
        }

        private void Chat_button_Click(object sender, EventArgs e)
        {
            OpenChildForm(chatView);
            HighlightButton(Chat_button);
        }

        private void Static_button_Click(object sender, EventArgs e)
        {
            
            OpenChildForm(staticView);
        }

        private void Log_out_Button_Click(object sender, EventArgs e)
        {
            DialogResult a = MessageBox.Show("Bạn có muốn đăng xuất không?", "Thông báo", MessageBoxButtons.YesNo);
            if (a == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                return;
            }
        }

        private void NewAdmin_Load(object sender, EventArgs e)
        {
            OpenChildForm(quanLyMayForm);
            HighlightButton(Computer_button);
        }
    }
}
