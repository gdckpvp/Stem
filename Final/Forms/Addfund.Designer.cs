namespace Final.Forms
{
	partial class Addfund
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numberTB = new System.Windows.Forms.TextBox();
            this.addfundBTN = new System.Windows.Forms.Button();
            this.clearBTN = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 57);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Card Number:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 111);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Amount:";
            // 
            // numberTB
            // 
            this.numberTB.Location = new System.Drawing.Point(167, 57);
            this.numberTB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numberTB.MaxLength = 12;
            this.numberTB.Name = "numberTB";
            this.numberTB.Size = new System.Drawing.Size(351, 22);
            this.numberTB.TabIndex = 2;
            // 
            // addfundBTN
            // 
            this.addfundBTN.Location = new System.Drawing.Point(167, 177);
            this.addfundBTN.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.addfundBTN.Name = "addfundBTN";
            this.addfundBTN.Size = new System.Drawing.Size(171, 43);
            this.addfundBTN.TabIndex = 4;
            this.addfundBTN.Text = "Add";
            this.addfundBTN.UseVisualStyleBackColor = true;
            this.addfundBTN.Click += new System.EventHandler(this.addfundBTN_Click);
            // 
            // clearBTN
            // 
            this.clearBTN.Location = new System.Drawing.Point(372, 177);
            this.clearBTN.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.clearBTN.Name = "clearBTN";
            this.clearBTN.Size = new System.Drawing.Size(147, 43);
            this.clearBTN.TabIndex = 5;
            this.clearBTN.Text = "Clear";
            this.clearBTN.UseVisualStyleBackColor = true;
            this.clearBTN.Click += new System.EventHandler(this.clearBTN_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(167, 111);
            this.numericUpDown1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(352, 22);
            this.numericUpDown1.TabIndex = 6;
            this.numericUpDown1.ThousandsSeparator = true;
            // 
            // Addfund
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 247);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.clearBTN);
            this.Controls.Add(this.addfundBTN);
            this.Controls.Add(this.numberTB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Addfund";
            this.Text = "Addfund";
            this.Load += new System.EventHandler(this.Addfund_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox numberTB;
		private System.Windows.Forms.Button addfundBTN;
		private System.Windows.Forms.Button clearBTN;
		private System.Windows.Forms.NumericUpDown numericUpDown1;
	}
}