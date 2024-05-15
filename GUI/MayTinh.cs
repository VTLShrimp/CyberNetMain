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
    public partial class MayTinh : UserControl
    {
        Admin admin;
        public MayTinh()
        {
            InitializeComponent();
            BackColor = Color.Aqua;
        }
        public void setText(string text)
        {
            label1.Text = text;
        }
        public bool IsActive { get; set; }
        private void button_Click(object sender, EventArgs e)
        {
            admin = new Admin();

            if (button.Text == "Bật máy")
            {
                button.Text = "Tắt máy";
                BackColor = Color.Green;
                IsActive = true;
                
            }
            else
            {
                button.Text = "Bật máy";
                BackColor = Color.Aqua;
                IsActive = false;
                
            }
        }
    }
}
