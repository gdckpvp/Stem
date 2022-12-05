using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final
{
    internal class Tools
    {
        public static byte[] ImageToByteArray(Image img, PictureBox tmp)
        {
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            if (tmp.Image != null)
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            return ms.ToArray();
        }
        public static byte[] DefaultImgBytes()
        {
            string projectDirectory = Directory.GetParent("Final").Parent.Parent.FullName;
            Image img = Image.FromFile(projectDirectory + "\\Resources\\template.jpg");
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }
        public static Image GetDataToImage(byte[] pData)
        {
            try
            {
                ImageConverter imgConverter = new ImageConverter();
                return imgConverter.ConvertFrom(pData) as Image;
            }
            catch
            {
                return null;
            }
        }
        public static Image getImage(byte[] data)
        {
            return Image.FromStream(new MemoryStream(data));
        }
    }
}
