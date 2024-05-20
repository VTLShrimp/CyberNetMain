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
    public partial class User : Form
    {
        public User()
        {
            InitializeComponent();
        }
        private Form currentFormchill;
        private void openchildform(Form childform)
        {
            if (currentFormchill != null)
            {
                currentFormchill.Close();
            }
            currentFormchill = childform;
            childform.TopLevel = false;
            childform.FormBorderStyle = FormBorderStyle.None;
            childform.Dock = DockStyle.Fill;
            panel_body.Controls.Add(childform);
            panel_body.Tag = childform;
            childform.BringToFront();
            childform.Show();
        }

        private void gbtnmenu_Click(object sender, EventArgs e)
        {
            openchildform(new Menu());
            Label1.Text = gbtnmenu.Text;
        }

        private void gbtnnaptenon_Click(object sender, EventArgs e)
        {
            openchildform(new Naptienuser());
            Label1.Text = gbtnnaptenon.Text;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (currentFormchill != null)
            {
                currentFormchill.Close();
            }
            Label1.Text = "Home";
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void panel_body_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
