namespace Final.Forms
{
    partial class SaleUC
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.SaleChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.SaleDGV = new System.Windows.Forms.DataGridView();
            this.SaleDateFromTP = new System.Windows.Forms.DateTimePicker();
            this.ChartTypeCB = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker = new System.Windows.Forms.Label();
            this.GameListCB = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.SaleChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SaleDGV)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // SaleChart
            // 
            this.SaleChart.BorderlineColor = System.Drawing.Color.Transparent;
            this.SaleChart.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            chartArea1.Name = "ChartArea1";
            this.SaleChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.SaleChart.Legends.Add(legend1);
            this.SaleChart.Location = new System.Drawing.Point(550, 118);
            this.SaleChart.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SaleChart.Name = "SaleChart";
            this.SaleChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Excel;
            series1.BackSecondaryColor = System.Drawing.Color.White;
            series1.BorderColor = System.Drawing.Color.White;
            series1.ChartArea = "ChartArea1";
            series1.Color = System.Drawing.Color.LightSteelBlue;
            series1.EmptyPointStyle.Color = System.Drawing.Color.White;
            series1.LabelForeColor = System.Drawing.Color.White;
            series1.Legend = "Legend1";
            series1.MarkerColor = System.Drawing.Color.White;
            series1.Name = "Amount";
            this.SaleChart.Series.Add(series1);
            this.SaleChart.Size = new System.Drawing.Size(737, 570);
            this.SaleChart.TabIndex = 0;
            this.SaleChart.Text = "chart1";
            // 
            // SaleDGV
            // 
            this.SaleDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.SaleDGV.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.SaleDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft YaHei Light", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.SaleDGV.DefaultCellStyle = dataGridViewCellStyle1;
            this.SaleDGV.Dock = System.Windows.Forms.DockStyle.Left;
            this.SaleDGV.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.SaleDGV.Location = new System.Drawing.Point(0, 0);
            this.SaleDGV.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SaleDGV.Name = "SaleDGV";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft YaHei Light", 11.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.SaleDGV.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.SaleDGV.RowHeadersWidth = 51;
            this.SaleDGV.Size = new System.Drawing.Size(516, 998);
            this.SaleDGV.TabIndex = 1;
            // 
            // SaleDateFromTP
            // 
            this.SaleDateFromTP.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.SaleDateFromTP.Location = new System.Drawing.Point(32, 313);
            this.SaleDateFromTP.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SaleDateFromTP.Name = "SaleDateFromTP";
            this.SaleDateFromTP.Size = new System.Drawing.Size(431, 34);
            this.SaleDateFromTP.TabIndex = 3;
            // 
            // ChartTypeCB
            // 
            this.ChartTypeCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.ChartTypeCB.FormattingEnabled = true;
            this.ChartTypeCB.Items.AddRange(new object[] {
            "Full Data",
            "Sale By Month",
            "Sale By Year",
            "Sale Of All Game By Month",
            "Sale Of All Game By Year",
            "Sale Of Selected Game By Month",
            "Sale Of Selected Game By Year"});
            this.ChartTypeCB.Location = new System.Drawing.Point(32, 222);
            this.ChartTypeCB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ChartTypeCB.Name = "ChartTypeCB";
            this.ChartTypeCB.Size = new System.Drawing.Size(431, 37);
            this.ChartTypeCB.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei Light", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(25, 184);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 35);
            this.label1.TabIndex = 5;
            this.label1.Text = "Chart List";
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.AutoSize = true;
            this.dateTimePicker.Font = new System.Drawing.Font("Microsoft YaHei Light", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimePicker.ForeColor = System.Drawing.Color.White;
            this.dateTimePicker.Location = new System.Drawing.Point(25, 275);
            this.dateTimePicker.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(260, 35);
            this.dateTimePicker.TabIndex = 6;
            this.dateTimePicker.Text = "Month - Year Picker";
            // 
            // GameListCB
            // 
            this.GameListCB.Font = new System.Drawing.Font("Microsoft YaHei Light", 14.25F);
            this.GameListCB.FormattingEnabled = true;
            this.GameListCB.Location = new System.Drawing.Point(32, 414);
            this.GameListCB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GameListCB.Name = "GameListCB";
            this.GameListCB.Size = new System.Drawing.Size(431, 39);
            this.GameListCB.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei Light", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(25, 364);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 35);
            this.label2.TabIndex = 17;
            this.label2.Text = "Game List";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.SaleChart);
            this.panel1.Controls.Add(this.SaleDateFromTP);
            this.panel1.Controls.Add(this.GameListCB);
            this.panel1.Controls.Add(this.ChartTypeCB);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dateTimePicker);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(516, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1372, 998);
            this.panel1.TabIndex = 19;
            // 
            // SaleUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.SaleDGV);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "SaleUC";
            this.Size = new System.Drawing.Size(1888, 998);
            ((System.ComponentModel.ISupportInitialize)(this.SaleChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SaleDGV)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart SaleChart;
        private System.Windows.Forms.DataGridView SaleDGV;
        private System.Windows.Forms.DateTimePicker SaleDateFromTP;
        private System.Windows.Forms.ComboBox ChartTypeCB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label dateTimePicker;
        private System.Windows.Forms.ComboBox GameListCB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
    }
}
