
using System.Drawing;

namespace Final.Forms
{
    partial class loginFM
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
            this.closeLoginBT = new System.Windows.Forms.Button();
            this.loginLoginBT = new System.Windows.Forms.Button();
            this.newaccLoginBT = new System.Windows.Forms.Button();
            this.unameLoginTB = new System.Windows.Forms.TextBox();
            this.passwdLoginTB = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // closeLoginBT
            // 
            this.closeLoginBT.BackColor = System.Drawing.Color.Transparent;
            this.closeLoginBT.Cursor = System.Windows.Forms.Cursors.UpArrow;
            this.closeLoginBT.FlatAppearance.BorderSize = 0;
            this.closeLoginBT.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.closeLoginBT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeLoginBT.ForeColor = System.Drawing.Color.Transparent;
            this.closeLoginBT.Location = new System.Drawing.Point(808, 0);
            this.closeLoginBT.Name = "closeLoginBT";
            this.closeLoginBT.Size = new System.Drawing.Size(40, 40);
            this.closeLoginBT.TabIndex = 0;
            this.closeLoginBT.TabStop = false;
            this.closeLoginBT.UseVisualStyleBackColor = true;
            this.closeLoginBT.Click += new System.EventHandler(this.closeLoginBT_Click);
            // 
            // loginLoginBT
            // 
            this.loginLoginBT.BackColor = System.Drawing.Color.Transparent;
            this.loginLoginBT.Cursor = System.Windows.Forms.Cursors.UpArrow;
            this.loginLoginBT.FlatAppearance.BorderSize = 0;
            this.loginLoginBT.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.loginLoginBT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loginLoginBT.ForeColor = System.Drawing.Color.Transparent;
            this.loginLoginBT.Location = new System.Drawing.Point(479, 382);
            this.loginLoginBT.Name = "loginLoginBT";
            this.loginLoginBT.Size = new System.Drawing.Size(313, 42);
            this.loginLoginBT.TabIndex = 1;
            this.loginLoginBT.TabStop = false;
            this.loginLoginBT.UseVisualStyleBackColor = true;
            this.loginLoginBT.Click += new System.EventHandler(this.login_button_Click);
            // 
            // newaccLoginBT
            // 
            this.newaccLoginBT.BackColor = System.Drawing.Color.Transparent;
            this.newaccLoginBT.Cursor = System.Windows.Forms.Cursors.UpArrow;
            this.newaccLoginBT.FlatAppearance.BorderSize = 0;
            this.newaccLoginBT.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.newaccLoginBT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.newaccLoginBT.ForeColor = System.Drawing.Color.Transparent;
            this.newaccLoginBT.Location = new System.Drawing.Point(503, 430);
            this.newaccLoginBT.Name = "newaccLoginBT";
            this.newaccLoginBT.Size = new System.Drawing.Size(261, 22);
            this.newaccLoginBT.TabIndex = 2;
            this.newaccLoginBT.TabStop = false;
            this.newaccLoginBT.UseVisualStyleBackColor = true;
            this.newaccLoginBT.Click += new System.EventHandler(this.newaccLoginBT_Click);
            // 
            // unameLoginTB
            // 
            this.unameLoginTB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.unameLoginTB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.unameLoginTB.Font = new System.Drawing.Font("Calibri Light", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.unameLoginTB.ForeColor = System.Drawing.Color.White;
            this.unameLoginTB.Location = new System.Drawing.Point(454, 228);
            this.unameLoginTB.Name = "unameLoginTB";
            this.unameLoginTB.Size = new System.Drawing.Size(362, 37);
            this.unameLoginTB.TabIndex = 3;
            this.unameLoginTB.TabStop = false;
            // 
            // passwdLoginTB
            // 
            this.passwdLoginTB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.passwdLoginTB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.passwdLoginTB.Font = new System.Drawing.Font("Calibri Light", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwdLoginTB.ForeColor = System.Drawing.Color.White;
            this.passwdLoginTB.Location = new System.Drawing.Point(454, 310);
            this.passwdLoginTB.Name = "passwdLoginTB";
            this.passwdLoginTB.Size = new System.Drawing.Size(362, 37);
            this.passwdLoginTB.TabIndex = 4;
            this.passwdLoginTB.TabStop = false;
            this.passwdLoginTB.TextChanged += new System.EventHandler(this.passwd_textTyping);
            this.passwdLoginTB.Leave += new System.EventHandler(this.passwd_textLeave);
            // 
            // loginFM
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.BackgroundImage = global::Final.Properties.Resources.Stem_login;
            this.ClientSize = new System.Drawing.Size(848, 480);
            this.Controls.Add(this.passwdLoginTB);
            this.Controls.Add(this.unameLoginTB);
            this.Controls.Add(this.newaccLoginBT);
            this.Controls.Add(this.loginLoginBT);
            this.Controls.Add(this.closeLoginBT);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "loginFM";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LOGIN";
            this.Load += new System.EventHandler(this.loginFM_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button closeLoginBT;
        private System.Windows.Forms.Button loginLoginBT;
        private System.Windows.Forms.Button newaccLoginBT;
        private System.Windows.Forms.TextBox unameLoginTB;
        private System.Windows.Forms.TextBox passwdLoginTB;
    }
}

