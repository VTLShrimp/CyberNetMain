using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CyberNet.GUI
{
    public partial class QuanLyMay : Form
    {
        public QuanLyMay()
        {
            InitializeComponent();
        }
        private bool isInitialized = false;
        private readonly List<MayTinh> customControls = new List<MayTinh>();

        private void CountMay()
        {
            int online = 0;
            int offline = 0;
            for (int i = 0; i < customControls.Count; i++)
            {
                if (customControls[i].IsActive)
                {
                    online++;
                }
                else
                {
                    offline++;
                }
            }
            guna2HtmlLabel5.Text = online.ToString();
            guna2HtmlLabel6.Text = offline.ToString();
            guna2HtmlLabel2.Text = customControls.Count.ToString();
        }

        private void KhoiTaoMay()
        {
            if (isInitialized)
            {
                return;
            }
            for (int i = 0; i < 100; i++)
            {
                var item = new MayTinh();
                item.setText($"Máy " + $"{i + 1:00}");
                customControls.Add(item);
                flowLayoutPanel1.Controls.Add(item);
            }
            isInitialized = true;
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.FlowDirection = FlowDirection.LeftToRight;
            flowLayoutPanel1.WrapContents = true;
            flowLayoutPanel1.Padding = new Padding(10);
            flowLayoutPanel1.AutoSize = false;
            flowLayoutPanel1.Dock = DockStyle.Fill; // Add this line to center the content
        }
        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void QuanLyMay_Load(object sender, EventArgs e)
        {
            KhoiTaoMay();
            CountMay();
        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void All_button_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            foreach (var item in customControls)
            {
                flowLayoutPanel1.Controls.Add(item);
            }
            CountMay();
            All_button.FillColor = Color.FromArgb(255, 128, 0);
            offline_button.FillColor = Color.FromArgb(203, 241, 245);
            online_button.FillColor = Color.FromArgb(203, 241, 245);
        }

        private void offline_button_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            foreach (var item in customControls.Where(x => !x.IsActive))
            {
                flowLayoutPanel1.Controls.Add(item);
            }
            CountMay();
            offline_button.FillColor = Color.FromArgb(255, 128, 0);
            All_button.FillColor = Color.FromArgb(203, 241, 245);
            online_button.FillColor = Color.FromArgb(203, 241, 245);
        }

        private void online_button_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            foreach (var item in customControls.Where(x => x.IsActive))
            {
                flowLayoutPanel1.Controls.Add(item);
            }
            CountMay();
            offline_button.FillColor = Color.FromArgb(203, 241, 245);
            All_button.FillColor = Color.FromArgb(203, 241, 245);
            online_button.FillColor = Color.FromArgb(255, 128, 0);
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

       
    }
}
