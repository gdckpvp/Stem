
namespace Final.Forms
{
    partial class createaccFM
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
            this.pass1CreateaccTB = new System.Windows.Forms.TextBox();
            this.usernameCreateaccTB = new System.Windows.Forms.TextBox();
            this.pass2CreateaccTB = new System.Windows.Forms.TextBox();
            this.createaccCreateaccBT = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pass1CreateaccTB
            // 
            this.pass1CreateaccTB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.pass1CreateaccTB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pass1CreateaccTB.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pass1CreateaccTB.ForeColor = System.Drawing.Color.White;
            this.pass1CreateaccTB.Location = new System.Drawing.Point(30, 187);
            this.pass1CreateaccTB.MaxLength = 16;
            this.pass1CreateaccTB.Name = "pass1CreateaccTB";
            this.pass1CreateaccTB.Size = new System.Drawing.Size(568, 40);
            this.pass1CreateaccTB.TabIndex = 35;
            this.pass1CreateaccTB.TabStop = false;
            // 
            // usernameCreateaccTB
            // 
            this.usernameCreateaccTB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.usernameCreateaccTB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.usernameCreateaccTB.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameCreateaccTB.ForeColor = System.Drawing.Color.White;
            this.usernameCreateaccTB.Location = new System.Drawing.Point(30, 112);
            this.usernameCreateaccTB.MaxLength = 15;
            this.usernameCreateaccTB.Name = "usernameCreateaccTB";
            this.usernameCreateaccTB.Size = new System.Drawing.Size(568, 40);
            this.usernameCreateaccTB.TabIndex = 33;
            this.usernameCreateaccTB.TabStop = false;
            // 
            // pass2CreateaccTB
            // 
            this.pass2CreateaccTB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.pass2CreateaccTB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pass2CreateaccTB.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pass2CreateaccTB.ForeColor = System.Drawing.Color.White;
            this.pass2CreateaccTB.Location = new System.Drawing.Point(30, 269);
            this.pass2CreateaccTB.MaxLength = 16;
            this.pass2CreateaccTB.Name = "pass2CreateaccTB";
            this.pass2CreateaccTB.Size = new System.Drawing.Size(568, 40);
            this.pass2CreateaccTB.TabIndex = 37;
            this.pass2CreateaccTB.TabStop = false;
            // 
            // createaccCreateaccBT
            // 
            this.createaccCreateaccBT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(180)))), ((int)(((byte)(222)))));
            this.createaccCreateaccBT.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.createaccCreateaccBT.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Bold);
            this.createaccCreateaccBT.ForeColor = System.Drawing.Color.White;
            this.createaccCreateaccBT.Location = new System.Drawing.Point(30, 335);
            this.createaccCreateaccBT.Name = "createaccCreateaccBT";
            this.createaccCreateaccBT.Size = new System.Drawing.Size(568, 39);
            this.createaccCreateaccBT.TabIndex = 39;
            this.createaccCreateaccBT.Text = "C   R   E   A   T   E         A   C   C   O   U   N   T";
            this.createaccCreateaccBT.UseVisualStyleBackColor = false;
            this.createaccCreateaccBT.Click += new System.EventHandler(this.createaccCreateaccBT_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri Light", 12F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(14, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 24);
            this.label1.TabIndex = 40;
            this.label1.Text = "User name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri Light", 12F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(14, 166);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 24);
            this.label2.TabIndex = 41;
            this.label2.Text = "Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri Light", 12F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(14, 248);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 24);
            this.label3.TabIndex = 42;
            this.label3.Text = "Retype password";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("NEXT ART", 19.8F);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(187, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(257, 34);
            this.label4.TabIndex = 43;
            this.label4.Text = "-   S   T   E   M   -";
            // 
            // createaccFM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(632, 412);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.createaccCreateaccBT);
            this.Controls.Add(this.pass2CreateaccTB);
            this.Controls.Add(this.pass1CreateaccTB);
            this.Controls.Add(this.usernameCreateaccTB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "createaccFM";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create new account";
            this.Load += new System.EventHandler(this.createaccFM_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox pass1CreateaccTB;
        private System.Windows.Forms.TextBox usernameCreateaccTB;
        private System.Windows.Forms.TextBox pass2CreateaccTB;
        private System.Windows.Forms.Button createaccCreateaccBT;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}