
namespace Final.Controls
{
    partial class GameSmallDetailControl
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
            this.gamenameGSDetailControlLB = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.gamepriceGSDetailControlLB = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // gamenameGSDetailControlLB
            // 
            this.gamenameGSDetailControlLB.AutoSize = true;
            this.gamenameGSDetailControlLB.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gamenameGSDetailControlLB.ForeColor = System.Drawing.Color.White;
            this.gamenameGSDetailControlLB.Location = new System.Drawing.Point(3, 242);
            this.gamenameGSDetailControlLB.Name = "gamenameGSDetailControlLB";
            this.gamenameGSDetailControlLB.Size = new System.Drawing.Size(85, 24);
            this.gamenameGSDetailControlLB.TabIndex = 1;
            this.gamenameGSDetailControlLB.Text = "destiny 2";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(197, 239);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // gamepriceGSDetailControlLB
            // 
            this.gamepriceGSDetailControlLB.AutoSize = true;
            this.gamepriceGSDetailControlLB.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gamepriceGSDetailControlLB.ForeColor = System.Drawing.Color.White;
            this.gamepriceGSDetailControlLB.Location = new System.Drawing.Point(3, 287);
            this.gamepriceGSDetailControlLB.Name = "gamepriceGSDetailControlLB";
            this.gamepriceGSDetailControlLB.Size = new System.Drawing.Size(121, 24);
            this.gamepriceGSDetailControlLB.TabIndex = 2;
            this.gamepriceGSDetailControlLB.Text = "12000000vnd";
            // 
            // GameSmallDetailControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.gamepriceGSDetailControlLB);
            this.Controls.Add(this.gamenameGSDetailControlLB);
            this.Controls.Add(this.pictureBox1);
            this.Name = "GameSmallDetailControl";
            this.Size = new System.Drawing.Size(197, 317);
            this.Click += new System.EventHandler(this.GameSmallDetailControl_Click);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label gamenameGSDetailControlLB;
        private System.Windows.Forms.Label gamepriceGSDetailControlLB;
    }
}
