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
	public partial class UserInfo : UserControl
	{
		public UserInfo()
		{
			InitializeComponent();
            SetFontAndColors();

        }

        private void setadminUserBTN_Click(object sender, EventArgs e)
        {

        }
        private void SetFontAndColors()
        {
            DataGridViewCellStyle style = new DataGridViewCellStyle();
            style.BackColor = Color.FromArgb(32, 32, 32);
            style.ForeColor = Color.White;

            libUserGrid.DefaultCellStyle = style;

        }
    }
}
