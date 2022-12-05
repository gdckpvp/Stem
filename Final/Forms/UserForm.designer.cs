
namespace Final.Forms
{
    partial class UserForm
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
            this.profilePage = new System.Windows.Forms.TabPage();
            this.saveBTN = new System.Windows.Forms.Button();
            this.editProfileBTN = new System.Windows.Forms.Button();
            this.addfundBTN = new System.Windows.Forms.Button();
            this.userProfileControl1 = new Final.Controls.UserProfileControl();
            this.libPage = new System.Windows.Forms.TabPage();
            this.rightLibpanel = new System.Windows.Forms.FlowLayoutPanel();
            this.gameDetail_Library1 = new Final.Controls.GameDetail_Library();
            this.leftLibPanel = new System.Windows.Forms.Panel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.gameListGV = new System.Windows.Forms.DataGridView();
            this.storePage = new System.Windows.Forms.TabPage();
            this.allgameUserStoreFPN = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.top10UserStoreFPN = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tagUserStorePN = new System.Windows.Forms.Panel();
            this.hidenGame = new System.Windows.Forms.ComboBox();
            this.tagListControls1 = new Final.Controls.TagListControls();
            this.usrtabCntrl = new System.Windows.Forms.TabControl();
            this.profilePage.SuspendLayout();
            this.libPage.SuspendLayout();
            this.rightLibpanel.SuspendLayout();
            this.leftLibPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gameListGV)).BeginInit();
            this.storePage.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tagUserStorePN.SuspendLayout();
            this.usrtabCntrl.SuspendLayout();
            this.SuspendLayout();
            // 
            // profilePage
            // 
            this.profilePage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.profilePage.Controls.Add(this.saveBTN);
            this.profilePage.Controls.Add(this.editProfileBTN);
            this.profilePage.Controls.Add(this.addfundBTN);
            this.profilePage.Controls.Add(this.userProfileControl1);
            this.profilePage.ForeColor = System.Drawing.Color.White;
            this.profilePage.Location = new System.Drawing.Point(4, 25);
            this.profilePage.Name = "profilePage";
            this.profilePage.Padding = new System.Windows.Forms.Padding(3);
            this.profilePage.Size = new System.Drawing.Size(1894, 1004);
            this.profilePage.TabIndex = 2;
            this.profilePage.Text = "Profile";
            // 
            // saveBTN
            // 
            this.saveBTN.Enabled = false;
            this.saveBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveBTN.Location = new System.Drawing.Point(1424, 658);
            this.saveBTN.Margin = new System.Windows.Forms.Padding(4);
            this.saveBTN.Name = "saveBTN";
            this.saveBTN.Size = new System.Drawing.Size(93, 57);
            this.saveBTN.TabIndex = 6;
            this.saveBTN.Text = "Save";
            this.saveBTN.UseVisualStyleBackColor = true;
            this.saveBTN.Click += new System.EventHandler(this.saveBTN_Click);
            // 
            // editProfileBTN
            // 
            this.editProfileBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editProfileBTN.Location = new System.Drawing.Point(1316, 658);
            this.editProfileBTN.Margin = new System.Windows.Forms.Padding(4);
            this.editProfileBTN.Name = "editProfileBTN";
            this.editProfileBTN.Size = new System.Drawing.Size(100, 57);
            this.editProfileBTN.TabIndex = 5;
            this.editProfileBTN.Text = "Edit";
            this.editProfileBTN.UseVisualStyleBackColor = true;
            this.editProfileBTN.Click += new System.EventHandler(this.editProfileBTN_Click);
            // 
            // addfundBTN
            // 
            this.addfundBTN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addfundBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addfundBTN.Location = new System.Drawing.Point(1457, 569);
            this.addfundBTN.Margin = new System.Windows.Forms.Padding(4);
            this.addfundBTN.Name = "addfundBTN";
            this.addfundBTN.Size = new System.Drawing.Size(60, 48);
            this.addfundBTN.TabIndex = 4;
            this.addfundBTN.Text = "+";
            this.addfundBTN.UseVisualStyleBackColor = true;
            this.addfundBTN.Click += new System.EventHandler(this.addfundBTN_Click);
            // 
            // userProfileControl1
            // 
            this.userProfileControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.userProfileControl1.AutoSize = true;
            this.userProfileControl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.userProfileControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.userProfileControl1.ForeColor = System.Drawing.Color.White;
            this.userProfileControl1.Location = new System.Drawing.Point(600, 100);
            this.userProfileControl1.Name = "userProfileControl1";
            this.userProfileControl1.Size = new System.Drawing.Size(921, 599);
            this.userProfileControl1.TabIndex = 0;
            // 
            // libPage
            // 
            this.libPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.libPage.Controls.Add(this.rightLibpanel);
            this.libPage.Controls.Add(this.leftLibPanel);
            this.libPage.Location = new System.Drawing.Point(4, 25);
            this.libPage.Name = "libPage";
            this.libPage.Padding = new System.Windows.Forms.Padding(3);
            this.libPage.Size = new System.Drawing.Size(1894, 1004);
            this.libPage.TabIndex = 1;
            this.libPage.Text = "Library";
            // 
            // rightLibpanel
            // 
            this.rightLibpanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.rightLibpanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rightLibpanel.Controls.Add(this.gameDetail_Library1);
            this.rightLibpanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rightLibpanel.Location = new System.Drawing.Point(436, 3);
            this.rightLibpanel.Name = "rightLibpanel";
            this.rightLibpanel.Size = new System.Drawing.Size(1455, 998);
            this.rightLibpanel.TabIndex = 1;
            // 
            // gameDetail_Library1
            // 
            this.gameDetail_Library1.BackColor = System.Drawing.Color.Transparent;
            this.gameDetail_Library1.Location = new System.Drawing.Point(3, 3);
            this.gameDetail_Library1.Name = "gameDetail_Library1";
            this.gameDetail_Library1.Size = new System.Drawing.Size(983, 770);
            this.gameDetail_Library1.TabIndex = 0;
            // 
            // leftLibPanel
            // 
            this.leftLibPanel.Controls.Add(this.comboBox1);
            this.leftLibPanel.Controls.Add(this.label5);
            this.leftLibPanel.Controls.Add(this.gameListGV);
            this.leftLibPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.leftLibPanel.Location = new System.Drawing.Point(3, 3);
            this.leftLibPanel.Name = "leftLibPanel";
            this.leftLibPanel.Size = new System.Drawing.Size(433, 998);
            this.leftLibPanel.TabIndex = 2;
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 1.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(168, -3);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 12);
            this.comboBox1.TabIndex = 4;
            this.comboBox1.Visible = false;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            this.comboBox1.SelectedValueChanged += new System.EventHandler(this.comboBox1_SelectedValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(384, 4);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 17);
            this.label5.TabIndex = 3;
            this.label5.Text = "label5";
            this.label5.Visible = false;
            // 
            // gameListGV
            // 
            this.gameListGV.AllowUserToAddRows = false;
            this.gameListGV.AllowUserToDeleteRows = false;
            this.gameListGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gameListGV.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.gameListGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gameListGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gameListGV.Location = new System.Drawing.Point(0, 0);
            this.gameListGV.Name = "gameListGV";
            this.gameListGV.ReadOnly = true;
            this.gameListGV.RowHeadersWidth = 51;
            this.gameListGV.RowTemplate.Height = 24;
            this.gameListGV.Size = new System.Drawing.Size(433, 998);
            this.gameListGV.TabIndex = 2;
            this.gameListGV.Enter += new System.EventHandler(this.gameListGV_Enter);
            // 
            // storePage
            // 
            this.storePage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.storePage.Controls.Add(this.allgameUserStoreFPN);
            this.storePage.Controls.Add(this.panel2);
            this.storePage.Controls.Add(this.top10UserStoreFPN);
            this.storePage.Controls.Add(this.panel1);
            this.storePage.Controls.Add(this.tagUserStorePN);
            this.storePage.Location = new System.Drawing.Point(4, 25);
            this.storePage.Name = "storePage";
            this.storePage.Padding = new System.Windows.Forms.Padding(3);
            this.storePage.Size = new System.Drawing.Size(1894, 1004);
            this.storePage.TabIndex = 0;
            this.storePage.Text = "Store";
            // 
            // allgameUserStoreFPN
            // 
            this.allgameUserStoreFPN.AutoScroll = true;
            this.allgameUserStoreFPN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.allgameUserStoreFPN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.allgameUserStoreFPN.Location = new System.Drawing.Point(427, 474);
            this.allgameUserStoreFPN.Name = "allgameUserStoreFPN";
            this.allgameUserStoreFPN.Size = new System.Drawing.Size(1464, 527);
            this.allgameUserStoreFPN.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(427, 423);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1464, 51);
            this.panel2.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(3, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(612, 46);
            this.label2.TabIndex = 1;
            this.label2.Text = "N  E  W  E  S  T    G  A  M  E  S";
            // 
            // top10UserStoreFPN
            // 
            this.top10UserStoreFPN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.top10UserStoreFPN.Dock = System.Windows.Forms.DockStyle.Top;
            this.top10UserStoreFPN.Location = new System.Drawing.Point(427, 56);
            this.top10UserStoreFPN.Name = "top10UserStoreFPN";
            this.top10UserStoreFPN.Size = new System.Drawing.Size(1464, 367);
            this.top10UserStoreFPN.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(427, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1464, 53);
            this.panel1.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label4.Location = new System.Drawing.Point(841, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 32);
            this.label4.TabIndex = 2;
            this.label4.Text = "label4";
            this.label4.Visible = false;
            this.label4.TextChanged += new System.EventHandler(this.label4_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label3.Location = new System.Drawing.Point(742, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 32);
            this.label3.TabIndex = 1;
            this.label3.Text = "label3";
            this.label3.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(719, 46);
            this.label1.TabIndex = 0;
            this.label1.Text = "T  O  P    D  O  W  N  L  O  A  D  E  D";
            // 
            // tagUserStorePN
            // 
            this.tagUserStorePN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tagUserStorePN.Controls.Add(this.hidenGame);
            this.tagUserStorePN.Controls.Add(this.tagListControls1);
            this.tagUserStorePN.Dock = System.Windows.Forms.DockStyle.Left;
            this.tagUserStorePN.Location = new System.Drawing.Point(3, 3);
            this.tagUserStorePN.Name = "tagUserStorePN";
            this.tagUserStorePN.Size = new System.Drawing.Size(424, 998);
            this.tagUserStorePN.TabIndex = 0;
            // 
            // hidenGame
            // 
            this.hidenGame.FormattingEnabled = true;
            this.hidenGame.Location = new System.Drawing.Point(127, 20);
            this.hidenGame.Name = "hidenGame";
            this.hidenGame.Size = new System.Drawing.Size(121, 24);
            this.hidenGame.TabIndex = 1;
            this.hidenGame.Visible = false;
            // 
            // tagListControls1
            // 
            this.tagListControls1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tagListControls1.Location = new System.Drawing.Point(0, 0);
            this.tagListControls1.Name = "tagListControls1";
            this.tagListControls1.Size = new System.Drawing.Size(422, 996);
            this.tagListControls1.TabIndex = 0;
            // 
            // usrtabCntrl
            // 
            this.usrtabCntrl.Controls.Add(this.storePage);
            this.usrtabCntrl.Controls.Add(this.libPage);
            this.usrtabCntrl.Controls.Add(this.profilePage);
            this.usrtabCntrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.usrtabCntrl.Location = new System.Drawing.Point(0, 0);
            this.usrtabCntrl.Name = "usrtabCntrl";
            this.usrtabCntrl.SelectedIndex = 0;
            this.usrtabCntrl.Size = new System.Drawing.Size(1902, 1033);
            this.usrtabCntrl.TabIndex = 0;
            // 
            // UserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.ClientSize = new System.Drawing.Size(1902, 1033);
            this.Controls.Add(this.usrtabCntrl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "UserForm";
            this.Text = "Stem Store";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.profilePage.ResumeLayout(false);
            this.profilePage.PerformLayout();
            this.libPage.ResumeLayout(false);
            this.rightLibpanel.ResumeLayout(false);
            this.leftLibPanel.ResumeLayout(false);
            this.leftLibPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gameListGV)).EndInit();
            this.storePage.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tagUserStorePN.ResumeLayout(false);
            this.usrtabCntrl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage profilePage;
        private Controls.UserProfileControl userProfileControl1;
        private System.Windows.Forms.TabPage libPage;
        private System.Windows.Forms.FlowLayoutPanel rightLibpanel;
        private System.Windows.Forms.Panel leftLibPanel;
        private System.Windows.Forms.DataGridView gameListGV;
        private System.Windows.Forms.TabPage storePage;
        private System.Windows.Forms.FlowLayoutPanel allgameUserStoreFPN;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel top10UserStoreFPN;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel tagUserStorePN;
        private Controls.TagListControls tagListControls1;
        private System.Windows.Forms.TabControl usrtabCntrl;
        private System.Windows.Forms.ComboBox hidenGame;
        private System.Windows.Forms.Label label4;
        private Controls.GameDetail_Library gameDetail_Library1;
        private System.Windows.Forms.Button saveBTN;
        private System.Windows.Forms.Button editProfileBTN;
        private System.Windows.Forms.Button addfundBTN;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}