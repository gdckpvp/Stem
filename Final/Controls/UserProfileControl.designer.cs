
namespace Final.Controls
{
    partial class UserProfileControl
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
            this.components = new System.ComponentModel.Container();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dobDTP = new System.Windows.Forms.DateTimePicker();
            this.nameTB = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.walletPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.walletCount = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.spentPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.spentCount = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cardTB = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.pwdTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.walletPanel.SuspendLayout();
            this.spentPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei Light", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(40, 33);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(459, 60);
            this.label3.TabIndex = 9;
            this.label3.Text = "Account Information";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft YaHei Light", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(42, 548);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(124, 48);
            this.label7.TabIndex = 22;
            this.label7.Text = "Spent:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft YaHei Light", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(42, 463);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(133, 48);
            this.label6.TabIndex = 21;
            this.label6.Text = "Wallet:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft YaHei Light", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(42, 220);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(247, 48);
            this.label5.TabIndex = 20;
            this.label5.Text = "Date Of Birth:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei Light", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(42, 135);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 48);
            this.label4.TabIndex = 19;
            this.label4.Text = "Name:";
            // 
            // dobDTP
            // 
            this.dobDTP.Enabled = false;
            this.dobDTP.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dobDTP.Location = new System.Drawing.Point(311, 220);
            this.dobDTP.Name = "dobDTP";
            this.dobDTP.Size = new System.Drawing.Size(607, 49);
            this.dobDTP.TabIndex = 24;
            // 
            // nameTB
            // 
            this.nameTB.Enabled = false;
            this.nameTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameTB.Location = new System.Drawing.Point(311, 135);
            this.nameTB.Name = "nameTB";
            this.nameTB.Size = new System.Drawing.Size(607, 49);
            this.nameTB.TabIndex = 25;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // walletPanel
            // 
            this.walletPanel.Controls.Add(this.walletCount);
            this.walletPanel.Controls.Add(this.label8);
            this.walletPanel.Location = new System.Drawing.Point(311, 463);
            this.walletPanel.Name = "walletPanel";
            this.walletPanel.Size = new System.Drawing.Size(607, 48);
            this.walletPanel.TabIndex = 29;
            // 
            // walletCount
            // 
            this.walletCount.AutoSize = true;
            this.walletCount.Font = new System.Drawing.Font("Microsoft YaHei Light", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.walletCount.Location = new System.Drawing.Point(4, 0);
            this.walletCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.walletCount.Name = "walletCount";
            this.walletCount.Size = new System.Drawing.Size(41, 48);
            this.walletCount.TabIndex = 30;
            this.walletCount.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft YaHei Light", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(53, 0);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(99, 48);
            this.label8.TabIndex = 31;
            this.label8.Text = "VND";
            // 
            // spentPanel
            // 
            this.spentPanel.Controls.Add(this.spentCount);
            this.spentPanel.Controls.Add(this.label9);
            this.spentPanel.Location = new System.Drawing.Point(311, 548);
            this.spentPanel.Name = "spentPanel";
            this.spentPanel.Size = new System.Drawing.Size(607, 48);
            this.spentPanel.TabIndex = 32;
            // 
            // spentCount
            // 
            this.spentCount.AutoSize = true;
            this.spentCount.Font = new System.Drawing.Font("Microsoft YaHei Light", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spentCount.Location = new System.Drawing.Point(4, 0);
            this.spentCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.spentCount.Name = "spentCount";
            this.spentCount.Size = new System.Drawing.Size(41, 48);
            this.spentCount.TabIndex = 30;
            this.spentCount.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft YaHei Light", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(53, 0);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(99, 48);
            this.label9.TabIndex = 31;
            this.label9.Text = "VND";
            // 
            // cardTB
            // 
            this.cardTB.Enabled = false;
            this.cardTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cardTB.Location = new System.Drawing.Point(311, 305);
            this.cardTB.MaxLength = 12;
            this.cardTB.Name = "cardTB";
            this.cardTB.Size = new System.Drawing.Size(607, 49);
            this.cardTB.TabIndex = 34;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft YaHei Light", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(42, 305);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(257, 48);
            this.label10.TabIndex = 33;
            this.label10.Text = "Card Number:";
            // 
            // pwdTB
            // 
            this.pwdTB.Enabled = false;
            this.pwdTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pwdTB.Location = new System.Drawing.Point(311, 386);
            this.pwdTB.MaxLength = 12;
            this.pwdTB.Name = "pwdTB";
            this.pwdTB.Size = new System.Drawing.Size(607, 49);
            this.pwdTB.TabIndex = 36;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei Light", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(42, 386);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 48);
            this.label1.TabIndex = 35;
            this.label1.Text = "Password:";
            // 
            // UserProfileControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.Controls.Add(this.pwdTB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cardTB);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.walletPanel);
            this.Controls.Add(this.spentPanel);
            this.Controls.Add(this.nameTB);
            this.Controls.Add(this.dobDTP);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "UserProfileControl";
            this.Size = new System.Drawing.Size(944, 635);
            this.walletPanel.ResumeLayout(false);
            this.walletPanel.PerformLayout();
            this.spentPanel.ResumeLayout(false);
            this.spentPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dobDTP;
        private System.Windows.Forms.TextBox nameTB;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.FlowLayoutPanel walletPanel;
        private System.Windows.Forms.Label walletCount;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.FlowLayoutPanel spentPanel;
        private System.Windows.Forms.Label spentCount;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox cardTB;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox pwdTB;
        private System.Windows.Forms.Label label1;
    }
}
