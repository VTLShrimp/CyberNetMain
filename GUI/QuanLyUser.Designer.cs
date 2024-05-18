namespace CyberNet.GUI
{
    partial class QuanLyUser
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.online_button = new Guna.UI2.WinForms.Guna2Button();
            this.offline_button = new Guna.UI2.WinForms.Guna2Button();
            this.All_button = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(201)))), ((int)(((byte)(206)))));
            this.guna2Panel1.Controls.Add(this.online_button);
            this.guna2Panel1.Controls.Add(this.offline_button);
            this.guna2Panel1.Controls.Add(this.All_button);
            this.guna2Panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.guna2Panel1.Location = new System.Drawing.Point(0, 0);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(190, 529);
            this.guna2Panel1.TabIndex = 1;
            // 
            // online_button
            // 
            this.online_button.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.online_button.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.online_button.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.online_button.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.online_button.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(241)))), ((int)(((byte)(245)))));
            this.online_button.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.online_button.ForeColor = System.Drawing.Color.Black;
            this.online_button.Location = new System.Drawing.Point(0, 338);
            this.online_button.Name = "online_button";
            this.online_button.Size = new System.Drawing.Size(190, 45);
            this.online_button.TabIndex = 2;
            this.online_button.Text = "XÓA";
            // 
            // offline_button
            // 
            this.offline_button.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.offline_button.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.offline_button.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.offline_button.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.offline_button.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(241)))), ((int)(((byte)(245)))));
            this.offline_button.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.offline_button.ForeColor = System.Drawing.Color.Black;
            this.offline_button.Location = new System.Drawing.Point(0, 255);
            this.offline_button.Name = "offline_button";
            this.offline_button.Size = new System.Drawing.Size(190, 45);
            this.offline_button.TabIndex = 1;
            this.offline_button.Text = "SỬA";
            // 
            // All_button
            // 
            this.All_button.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.All_button.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.All_button.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.All_button.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.All_button.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(241)))), ((int)(((byte)(245)))));
            this.All_button.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.All_button.ForeColor = System.Drawing.Color.Black;
            this.All_button.Location = new System.Drawing.Point(0, 173);
            this.All_button.Name = "All_button";
            this.All_button.Size = new System.Drawing.Size(190, 45);
            this.All_button.TabIndex = 0;
            this.All_button.Text = "THÊM ";
            // 
            // QuanLyUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(970, 529);
            this.Controls.Add(this.guna2Panel1);
            this.Name = "QuanLyUser";
            this.Text = "QuanLyUser";
            this.Load += new System.EventHandler(this.QuanLyUser_Load);
            this.guna2Panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Button online_button;
        private Guna.UI2.WinForms.Guna2Button offline_button;
        private Guna.UI2.WinForms.Guna2Button All_button;
    }
}