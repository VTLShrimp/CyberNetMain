using System;
using System.Data.SqlClient;

namespace CyberNet.GUI
{
    partial class Bao_cao
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
        /// 

        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.txttimkiem = new System.Windows.Forms.TextBox();
            this.btntimkiem = new System.Windows.Forms.Button();
            this.cbtuychon = new System.Windows.Forms.ComboBox();
            this.rbtndoanhthunam = new System.Windows.Forms.RadioButton();
            this.rbtndoanhthuthang = new System.Windows.Forms.RadioButton();
            this.txttong = new System.Windows.Forms.TextBox();
            this.lable1 = new System.Windows.Forms.Label();
            this.lvchitiet = new System.Windows.Forms.ListView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnxem = new System.Windows.Forms.Button();
            this.cbnam = new System.Windows.Forms.ComboBox();
            this.cbthang = new System.Windows.Forms.ComboBox();
            this.rbtndoanhthungay = new System.Windows.Forms.RadioButton();
            this.listViewReport = new System.Windows.Forms.ListView();
            this.chartReport = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartReport)).BeginInit();
            this.SuspendLayout();
            // 
            // txttimkiem
            // 
            this.txttimkiem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txttimkiem.Location = new System.Drawing.Point(449, 16);
            this.txttimkiem.Name = "txttimkiem";
            this.txttimkiem.Size = new System.Drawing.Size(261, 22);
            this.txttimkiem.TabIndex = 26;
            // 
            // btntimkiem
            // 
            this.btntimkiem.Location = new System.Drawing.Point(716, 14);
            this.btntimkiem.Name = "btntimkiem";
            this.btntimkiem.Size = new System.Drawing.Size(91, 26);
            this.btntimkiem.TabIndex = 25;
            this.btntimkiem.Text = "Tìm kiếm";
            this.btntimkiem.UseVisualStyleBackColor = true;
            this.btntimkiem.Click += new System.EventHandler(this.btntimkiem_Click);
            // 
            // cbtuychon
            // 
            this.cbtuychon.FormattingEnabled = true;
            this.cbtuychon.Items.AddRange(new object[] {
            "Danh sách",
            "Biểu đồ"});
            this.cbtuychon.Location = new System.Drawing.Point(14, 14);
            this.cbtuychon.Name = "cbtuychon";
            this.cbtuychon.Size = new System.Drawing.Size(121, 24);
            this.cbtuychon.TabIndex = 23;
            this.cbtuychon.Text = "Tùy chọn";
            // 
            // rbtndoanhthunam
            // 
            this.rbtndoanhthunam.AutoSize = true;
            this.rbtndoanhthunam.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtndoanhthunam.Location = new System.Drawing.Point(16, 116);
            this.rbtndoanhthunam.Name = "rbtndoanhthunam";
            this.rbtndoanhthunam.Size = new System.Drawing.Size(157, 24);
            this.rbtndoanhthunam.TabIndex = 6;
            this.rbtndoanhthunam.Text = "Doanh thu năm\r\n";
            this.rbtndoanhthunam.UseVisualStyleBackColor = true;
            // 
            // rbtndoanhthuthang
            // 
            this.rbtndoanhthuthang.AutoSize = true;
            this.rbtndoanhthuthang.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtndoanhthuthang.Location = new System.Drawing.Point(16, 56);
            this.rbtndoanhthuthang.Name = "rbtndoanhthuthang";
            this.rbtndoanhthuthang.Size = new System.Drawing.Size(168, 24);
            this.rbtndoanhthuthang.TabIndex = 5;
            this.rbtndoanhthuthang.Text = "Doanh thu tháng\r\n";
            this.rbtndoanhthuthang.UseVisualStyleBackColor = true;
            // 
            // txttong
            // 
            this.txttong.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txttong.Enabled = false;
            this.txttong.Location = new System.Drawing.Point(70, 354);
            this.txttong.Name = "txttong";
            this.txttong.Size = new System.Drawing.Size(182, 22);
            this.txttong.TabIndex = 29;
            // 
            // lable1
            // 
            this.lable1.AutoSize = true;
            this.lable1.Location = new System.Drawing.Point(14, 356);
            this.lable1.Name = "lable1";
            this.lable1.Size = new System.Drawing.Size(45, 16);
            this.lable1.TabIndex = 28;
            this.lable1.Text = "Tổng: ";
            // 
            // lvchitiet
            // 
            this.lvchitiet.HideSelection = false;
            this.lvchitiet.Location = new System.Drawing.Point(14, 389);
            this.lvchitiet.Name = "lvchitiet";
            this.lvchitiet.Size = new System.Drawing.Size(1005, 164);
            this.lvchitiet.TabIndex = 27;
            this.lvchitiet.UseCompatibleStateImageBehavior = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnxem);
            this.groupBox1.Controls.Add(this.cbnam);
            this.groupBox1.Controls.Add(this.cbthang);
            this.groupBox1.Controls.Add(this.rbtndoanhthunam);
            this.groupBox1.Controls.Add(this.rbtndoanhthuthang);
            this.groupBox1.Controls.Add(this.rbtndoanhthungay);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(817, 55);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(206, 293);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Yêu cầu báo cáo";
            // 
            // btnxem
            // 
            this.btnxem.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnxem.Location = new System.Drawing.Point(33, 204);
            this.btnxem.Name = "btnxem";
            this.btnxem.Size = new System.Drawing.Size(153, 43);
            this.btnxem.TabIndex = 34;
            this.btnxem.Text = "Xem Báo Cáo";
            this.btnxem.UseVisualStyleBackColor = true;
            // 
            // cbnam
            // 
            this.cbnam.Enabled = false;
            this.cbnam.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbnam.FormattingEnabled = true;
            this.cbnam.Location = new System.Drawing.Point(39, 146);
            this.cbnam.Name = "cbnam";
            this.cbnam.Size = new System.Drawing.Size(161, 28);
            this.cbnam.TabIndex = 37;
            this.cbnam.Text = "Chọn Năm";
            // 
            // cbthang
            // 
            this.cbthang.Enabled = false;
            this.cbthang.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbthang.FormattingEnabled = true;
            this.cbthang.Location = new System.Drawing.Point(39, 82);
            this.cbthang.Name = "cbthang";
            this.cbthang.Size = new System.Drawing.Size(161, 28);
            this.cbthang.TabIndex = 36;
            this.cbthang.Text = "Chọn Tháng";
            // 
            // rbtndoanhthungay
            // 
            this.rbtndoanhthungay.AutoSize = true;
            this.rbtndoanhthungay.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbtndoanhthungay.Location = new System.Drawing.Point(16, 26);
            this.rbtndoanhthungay.Name = "rbtndoanhthungay";
            this.rbtndoanhthungay.Size = new System.Drawing.Size(161, 24);
            this.rbtndoanhthungay.TabIndex = 3;
            this.rbtndoanhthungay.Text = "Doanh thu ngày";
            this.rbtndoanhthungay.UseVisualStyleBackColor = true;
            // 
            // listViewReport
            // 
            this.listViewReport.HideSelection = false;
            this.listViewReport.Location = new System.Drawing.Point(12, 55);
            this.listViewReport.Name = "listViewReport";
            this.listViewReport.Size = new System.Drawing.Size(797, 293);
            this.listViewReport.TabIndex = 22;
            this.listViewReport.UseCompatibleStateImageBehavior = false;
            // 
            // chartReport
            // 
            chartArea2.Name = "ChartArea1";
            this.chartReport.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartReport.Legends.Add(legend2);
            this.chartReport.Location = new System.Drawing.Point(14, 55);
            this.chartReport.Name = "chartReport";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartReport.Series.Add(series2);
            this.chartReport.Size = new System.Drawing.Size(799, 293);
            this.chartReport.TabIndex = 33;
            this.chartReport.Text = "chart1";
            // 
            // Bao_cao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1031, 568);
            this.Controls.Add(this.chartReport);
            this.Controls.Add(this.txttimkiem);
            this.Controls.Add(this.btntimkiem);
            this.Controls.Add(this.cbtuychon);
            this.Controls.Add(this.txttong);
            this.Controls.Add(this.lable1);
            this.Controls.Add(this.lvchitiet);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.listViewReport);
            this.Name = "Bao_cao";
            this.Text = "Bao_cao";
            this.Load += new System.EventHandler(this.Bao_cao_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartReport)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txttimkiem;
        private System.Windows.Forms.Button btntimkiem;
        private System.Windows.Forms.ComboBox cbtuychon;
        private System.Windows.Forms.RadioButton rbtndoanhthunam;
        private System.Windows.Forms.RadioButton rbtndoanhthuthang;
        private System.Windows.Forms.TextBox txttong;
        private System.Windows.Forms.Label lable1;
        private System.Windows.Forms.ListView lvchitiet;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView listViewReport;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartReport;
        private System.Windows.Forms.RadioButton rbtndoanhthungay;
        private System.Windows.Forms.ComboBox cbthang;
        private System.Windows.Forms.ComboBox cbnam;
        private System.Windows.Forms.Button btnxem;
    }
}