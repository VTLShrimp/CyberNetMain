namespace CyberNet.GUI
{
    partial class Form1
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.listView1 = new System.Windows.Forms.ListView();
            this.listView2 = new System.Windows.Forms.ListView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnxem = new System.Windows.Forms.Button();
            this.cbnam = new System.Windows.Forms.ComboBox();
            this.cbthang = new System.Windows.Forms.ComboBox();
            this.rbtndoanhthunam = new System.Windows.Forms.RadioButton();
            this.rbtndoanhthuthang = new System.Windows.Forms.RadioButton();
            this.rbtndoanhthungay = new System.Windows.Forms.RadioButton();
            this.cbtuychon = new System.Windows.Forms.ComboBox();
            this.btntimkiem = new System.Windows.Forms.Button();
            this.txttimkiem = new System.Windows.Forms.TextBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(12, 43);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(834, 288);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // listView2
            // 
            this.listView2.HideSelection = false;
            this.listView2.Location = new System.Drawing.Point(12, 349);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(622, 293);
            this.listView2.TabIndex = 1;
            this.listView2.UseCompatibleStateImageBehavior = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnxem);
            this.groupBox1.Controls.Add(this.cbnam);
            this.groupBox1.Controls.Add(this.cbthang);
            this.groupBox1.Controls.Add(this.rbtndoanhthunam);
            this.groupBox1.Controls.Add(this.rbtndoanhthuthang);
            this.groupBox1.Controls.Add(this.rbtndoanhthungay);
            this.groupBox1.Location = new System.Drawing.Point(640, 349);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(206, 239);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Yêu cầu báo cáo";
            // 
            // btnxem
            // 
            this.btnxem.Location = new System.Drawing.Point(28, 176);
            this.btnxem.Name = "btnxem";
            this.btnxem.Size = new System.Drawing.Size(153, 43);
            this.btnxem.TabIndex = 34;
            this.btnxem.Text = "Xem Báo Cáo";
            this.btnxem.UseVisualStyleBackColor = true;
            this.btnxem.Click += new System.EventHandler(this.btnxem_Click);
            // 
            // cbnam
            // 
            this.cbnam.FormattingEnabled = true;
            this.cbnam.Location = new System.Drawing.Point(51, 135);
            this.cbnam.Name = "cbnam";
            this.cbnam.Size = new System.Drawing.Size(121, 24);
            this.cbnam.TabIndex = 37;
            this.cbnam.Text = "Chọn Năm";
            // 
            // cbthang
            // 
            this.cbthang.FormattingEnabled = true;
            this.cbthang.Location = new System.Drawing.Point(51, 79);
            this.cbthang.Name = "cbthang";
            this.cbthang.Size = new System.Drawing.Size(121, 24);
            this.cbthang.TabIndex = 36;
            this.cbthang.Text = "Chọn Tháng";
            // 
            // rbtndoanhthunam
            // 
            this.rbtndoanhthunam.AutoSize = true;
            this.rbtndoanhthunam.Location = new System.Drawing.Point(28, 109);
            this.rbtndoanhthunam.Name = "rbtndoanhthunam";
            this.rbtndoanhthunam.Size = new System.Drawing.Size(117, 20);
            this.rbtndoanhthunam.TabIndex = 6;
            this.rbtndoanhthunam.Text = "Doanh thu năm\r\n";
            this.rbtndoanhthunam.UseVisualStyleBackColor = true;
            // 
            // rbtndoanhthuthang
            // 
            this.rbtndoanhthuthang.AutoSize = true;
            this.rbtndoanhthuthang.Location = new System.Drawing.Point(28, 53);
            this.rbtndoanhthuthang.Name = "rbtndoanhthuthang";
            this.rbtndoanhthuthang.Size = new System.Drawing.Size(124, 20);
            this.rbtndoanhthuthang.TabIndex = 5;
            this.rbtndoanhthuthang.Text = "Doanh thu tháng\r\n";
            this.rbtndoanhthuthang.UseVisualStyleBackColor = true;
            // 
            // rbtndoanhthungay
            // 
            this.rbtndoanhthungay.AutoSize = true;
            this.rbtndoanhthungay.Location = new System.Drawing.Point(28, 25);
            this.rbtndoanhthungay.Name = "rbtndoanhthungay";
            this.rbtndoanhthungay.Size = new System.Drawing.Size(121, 20);
            this.rbtndoanhthungay.TabIndex = 3;
            this.rbtndoanhthungay.Text = "Doanh thu ngày";
            this.rbtndoanhthungay.UseVisualStyleBackColor = true;
            // 
            // cbtuychon
            // 
            this.cbtuychon.FormattingEnabled = true;
            this.cbtuychon.Items.AddRange(new object[] {
            "Danh sách",
            "Biểu đồ"});
            this.cbtuychon.Location = new System.Drawing.Point(12, 12);
            this.cbtuychon.Name = "cbtuychon";
            this.cbtuychon.Size = new System.Drawing.Size(121, 24);
            this.cbtuychon.TabIndex = 38;
            this.cbtuychon.Text = "Tùy Chọn";
            // 
            // btntimkiem
            // 
            this.btntimkiem.Location = new System.Drawing.Point(771, 14);
            this.btntimkiem.Name = "btntimkiem";
            this.btntimkiem.Size = new System.Drawing.Size(75, 23);
            this.btntimkiem.TabIndex = 39;
            this.btntimkiem.Text = "Tìm Kiếm";
            this.btntimkiem.UseVisualStyleBackColor = true;
            // 
            // txttimkiem
            // 
            this.txttimkiem.Location = new System.Drawing.Point(571, 15);
            this.txttimkiem.Name = "txttimkiem";
            this.txttimkiem.Size = new System.Drawing.Size(194, 22);
            this.txttimkiem.TabIndex = 40;
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(12, 42);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(834, 289);
            this.chart1.TabIndex = 41;
            this.chart1.Text = "chart1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 657);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.txttimkiem);
            this.Controls.Add(this.btntimkiem);
            this.Controls.Add(this.cbtuychon);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.listView2);
            this.Controls.Add(this.listView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnxem;
        private System.Windows.Forms.ComboBox cbnam;
        private System.Windows.Forms.ComboBox cbthang;
        private System.Windows.Forms.RadioButton rbtndoanhthunam;
        private System.Windows.Forms.RadioButton rbtndoanhthuthang;
        private System.Windows.Forms.RadioButton rbtndoanhthungay;
        private System.Windows.Forms.ComboBox cbtuychon;
        private System.Windows.Forms.Button btntimkiem;
        private System.Windows.Forms.TextBox txttimkiem;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    }
}