using Final.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final.Controls
{
    public partial class GameSmallDetailControl : UserControl
    {
        private Image image;
        private string gamename;
        public string gameid;
        private int price;
        public GameSmallDetailControl()
        {
            InitializeComponent();
            
        }
        public GameSmallDetailControl(string gid, Image img, string gamename, int price)
        {
            InitializeComponent();
            this.image = img;
            this.gamename = gamename;
            this.price = price;
            pictureBox1.Name = gid;
            LoadDetail();
        }
        private void LoadDetail()
        {
            pictureBox1.Image = this.image;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            gamenameGSDetailControlLB.Text = this.gamename.ToUpper();
            gamepriceGSDetailControlLB.Text = ((float)this.price / 1000).ToString() + "K VND";
        }

        private void GameSmallDetailControl_Click(object sender, EventArgs e)
        {
            //var label = UserForm.ActiveForm.Controls.Find("label4", true);
            //label[0].Text = gameid;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            var label = UserForm.ActiveForm.Controls.Find("label4", true);
            label[0].Text = pictureBox1.Name;
        }
    }
}
