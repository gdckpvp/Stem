using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using Final.Forms;

namespace Final.Forms
{
    public partial class loginFM : Form
    {
        SqlConnection connection;
        string connectionString;
        int id = 1;
        public loginFM()
        {
            InitializeComponent();

            connectionString = ConfigurationManager.ConnectionStrings["Final.Properties.Settings.StemDBConnectionStringUser"].ConnectionString;
        }

        private void login_button_Click(object sender, EventArgs e)
        {
            int result;
            string query = "select dbo.func_loginaccount(@username, @pass)";
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                connection.Open();

                cmd.Parameters.Add("@username", SqlDbType.NVarChar).Value = unameLoginTB.Text;
                cmd.Parameters.Add("@pass", SqlDbType.NVarChar).Value = passwdLoginTB.Text;

                result = Convert.ToInt32(cmd.ExecuteScalar());

                if (result == 1)
                {
                    string newquery = "select dbo.func_FindUserID(@username, @password)";
                    using (SqlCommand cmd2 = new SqlCommand(newquery, connection))
                    {
                        cmd2.Parameters.Add("@username", SqlDbType.NVarChar).Value = unameLoginTB.Text;
                        cmd2.Parameters.Add("@password", SqlDbType.NVarChar).Value = passwdLoginTB.Text;

                        this.id = Convert.ToInt32(cmd2.ExecuteScalar());

                    }
                    Form lamo2 = new UserForm(this.id);
                    this.Hide();
                    lamo2.ShowDialog();
                    this.Show();
                }
                else if (result == 2)
                {
                    string newquery = "select dbo.func_FindUserID(@username, @password)";
                    using (SqlCommand cmd2 = new SqlCommand(newquery, connection))
                    {
                        cmd2.Parameters.Add("@username", SqlDbType.NVarChar).Value = unameLoginTB.Text;
                        cmd2.Parameters.Add("@password", SqlDbType.NVarChar).Value = passwdLoginTB.Text;

                        this.id = Convert.ToInt32(cmd2.ExecuteScalar());

                    }
                    Form lamo2 = new AdminForm(this.id);
                    this.Hide();
                    lamo2.ShowDialog();
                    this.Show();
                }
                else
                {
                    MessageBox.Show("Wrong username or password", "Announcement");
                }
            }
        }

        private void passwd_textTyping(object sender, EventArgs e)
        {
            //passwordlogin_textBox.Text = "";
            passwdLoginTB.UseSystemPasswordChar = true;
        }

        private void passwd_textLeave(object sender, EventArgs e)
        {
            //passwordlogin_textBox.UseSystemPasswordChar = false;
            SelectNextControl(passwdLoginTB, true, true, false, true);
        }

        private void closeLoginBT_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void newaccLoginBT_Click(object sender, EventArgs e)
        {
            Form lamo2 = new createaccFM();
            this.Hide();
            lamo2.ShowDialog();
            this.Show();

        }

        private void loginFM_Load(object sender, EventArgs e)
        {
    
        }
    }
}
