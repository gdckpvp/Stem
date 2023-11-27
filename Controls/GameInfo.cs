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
    public partial class GameInfo : UserControl
    {
        public GameInfo()
        {
            InitializeComponent();
        }

        private void GameInfo_Load(object sender, EventArgs e)
        {

        }

        private void gameimgGinfoPTB_Click(object sender, EventArgs e)
        {
            OpenFileDialog opnfd = new OpenFileDialog
            {
                Filter = "Images (.JPEG;.BMP;.JPG;.GIF;.PNG;.)|.JPEG;.BMP;.JPG;.GIF;*.PNG"
            };
            if (opnfd.ShowDialog() == DialogResult.OK)
            {
                Image img = new Bitmap(opnfd.FileName);
                gameimgGinfoPTB.Image = img;// resizeImage(img);
                gameimgGinfoPTB.SizeMode = PictureBoxSizeMode.StretchImage;
                //picturePreviewPanel.Visible = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
