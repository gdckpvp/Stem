using Final.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final.Forms
{
	public partial class Addfund : Form
	{
		private int id;
		private string credit;
		SqlConnection connection;
		string connectionString;
		public Addfund(int id,string credit)
		{
			InitializeComponent();
			connectionString = ConfigurationManager.ConnectionStrings["Final.Properties.Settings.StemDBConnectionStringUser"].ConnectionString;
			this.id = id;
			this.credit = credit;
		}

		private void LoadAddFund()
		{
			if (this.credit != "")
			{
				numberTB.Text = this.credit;
				numberTB.Enabled = false;
			}
			else
				numberTB.Enabled = true;
		}

		private void clearBTN_Click(object sender, EventArgs e)
		{
			if (this.credit != "")
				numericUpDown1.Value = 0;
			else
			{
				numberTB.ResetText();
				numericUpDown1.Value=0;
			}
		}

		private void addfundBTN_Click(object sender, EventArgs e)
		{
			if (numericUpDown1.Value != 0 && numberTB.Text != "")
			{
				using (connection = new SqlConnection(connectionString))
				using (SqlCommand cmd = new SqlCommand("sp_UpdateUserWallet @amount,@uid", connection))
				{
					SqlDataAdapter adapter = new SqlDataAdapter(cmd);
					connection.Open();
					adapter.SelectCommand.Parameters.AddWithValue("@amount", (int)numericUpDown1.Value);
					adapter.SelectCommand.Parameters.AddWithValue("@uid", id);
					cmd.ExecuteNonQuery();

					this.Close();
				}
			}
			else MessageBox.Show("Error");
		}

		private void Addfund_Load(object sender, EventArgs e)
		{
			
			LoadAddFund();
		}
	}
}
