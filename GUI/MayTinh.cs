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
        private Admin admin;
        private int counter = 0;

        public MayTinh()
        {
            InitializeComponent();
            BackColor = Color.Aqua;
            timer1.Interval= 1000;
            timer1.Tick += timer1_Tick;
        
        }

        public void setText(string text)
        {
            label1.Text = text;
        }

        public bool IsActive { get; set; }
        public string IDMay { get; set; }

        private void button_Click(object sender, EventArgs e)
        {
            admin = new Admin();

            if (button.Text == "Bật máy")
            {
                button.Text = "Tắt máy";
                BackColor = Color.Green;
                IsActive = true;
                timer1.Start();

            }
            else
            {
                button.Text = "Bật máy";
                BackColor = Color.Aqua;
                IsActive = false;
                timer1.Stop();
                counter = 0;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            counter++;
            int seconds = (counter % 60);
            int minutes = (counter / 60) % 60;
            int hours = (counter / 3600);
            guna2TextBox1.Text = string.Format("        {0:D2}:{1:D2}:{2:D2}", hours, minutes, seconds);
        }
    }
    
}
