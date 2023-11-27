using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace Final.Forms
{
    public partial class createaccFM : Form
    {
        SqlConnection connection;
        string connectionString;
        public createaccFM()
        {
            InitializeComponent();

            connectionString = ConfigurationManager.ConnectionStrings["Final.Properties.Settings.StemDBConnectionStringAdmin"].ConnectionString;
        }

        private void createaccFM_Load(object sender, EventArgs e)
        {

        }

        private void createaccCreateaccBT_Click(object sender, EventArgs e)
        {
            int result;
            string query = "select dbo.func_CheckAccount(@pass,@usr)";
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                connection.Open();

                cmd.Parameters.Add("@pass", SqlDbType.NVarChar).Value = pass1CreateaccTB.Text;
                cmd.Parameters.Add("@usr", SqlDbType.NVarChar).Value = usernameCreateaccTB.Text;
                result = Convert.ToInt32(cmd.ExecuteScalar());
            }
            if(result == 0)
            {
                if (pass1CreateaccTB.Text == pass2CreateaccTB.Text)
                {
                    query = "sp_AddNewUser";
                    using (connection = new SqlConnection(connectionString))
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        connection.Open();

                        cmd.Parameters.Add("@uname", SqlDbType.NVarChar).Value = usernameCreateaccTB.Text;
                        cmd.Parameters.Add("@password", SqlDbType.NVarChar).Value = pass1CreateaccTB.Text;

                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Account has been successfully created", "- S  T  E  M  -");
                    this.Close();
                }
                else
                {
                    pass1CreateaccTB.Text = "";
                    pass2CreateaccTB.Text = "";
                    MessageBox.Show("Password does not match, please type again", "Warning");
                }
            }
            else if (result == 2)
            {
                pass1CreateaccTB.Text = "";
                pass2CreateaccTB.Text = "";
                MessageBox.Show("Username exist!", "Warning");
            }
            else
            {
                pass1CreateaccTB.Text = "";
                pass2CreateaccTB.Text = "";
                MessageBox.Show("Password must contain at least 1 number and 1 special character, please type again", "Warning");
            }
            connection.Close();
        }
    }
}
