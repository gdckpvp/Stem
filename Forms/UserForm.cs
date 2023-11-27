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
using System.Windows;
using System.Windows.Forms;

namespace Final.Forms
{
    public partial class UserForm : Form
    {
        private int currentid = 1;
        SqlConnection connection;
        string connectionString;
        private ComboBox hiden = new ComboBox();
        Dictionary<int, string> pair = new Dictionary<int, string>();
        public UserForm()
        {
            InitializeComponent();

            connectionString = ConfigurationManager.ConnectionStrings["Final.Properties.Settings.StemDBConnectionStringUser"].ConnectionString;
            LoadTag();
            LoadProfile();
            LoadNewestGameFirst();
            LoadTop10Game();
            LoadGameToLib();
        }
        public UserForm(int currentid)
        {
            InitializeComponent();
            this.currentid = currentid;
            connectionString = ConfigurationManager.ConnectionStrings["Final.Properties.Settings.StemDBConnectionStringUser"].ConnectionString;
            LoadTag();
            LoadProfile();
            LoadNewestGameFirst();
            LoadTop10Game();
            LoadGameToLib();
        }

        public void LoadNewestGameFirst()
        {
            allgameUserStoreFPN.Controls.Clear();
            string query = "select * from dbo.func_GetNewestGame()";
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                connection.Open();
                DataTable dtb = new DataTable();
                adapter.Fill(dtb);
                if (dtb.Rows.Count > 0)
                {
                    for (int i = 0; i < dtb.Rows.Count; i++)
                    {
                        GameSmallDetailControl gsmall = new GameSmallDetailControl(dtb.Rows[i][0].ToString(), Tools.getImage((byte[])dtb.Rows[i][5]), dtb.Rows[i][2].ToString(), int.Parse(dtb.Rows[i][4].ToString()));
                        allgameUserStoreFPN.Controls.Add(gsmall);
                    }
                    foreach (Control cc in allgameUserStoreFPN.Controls)
                    {
                        cc.Margin = new Padding(60, 20, 20, 20);
                    }
                }
            }

        }
        public void LoadTop10Game()
        {
            top10UserStoreFPN.Controls.Clear();
            string query = "select * from dbo.func_GetTopMostDownloaded()";
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                connection.Open();
                DataTable dtb = new DataTable();
                adapter.Fill(dtb);
                if (dtb.Rows.Count > 0)
                {
                    for (int i = 0; i < dtb.Rows.Count; i++)
                    {
                        GameSmallDetailControl gsmall = new GameSmallDetailControl(dtb.Rows[i][0].ToString(), Tools.getImage((byte[])dtb.Rows[i][5]), dtb.Rows[i][2].ToString(), int.Parse(dtb.Rows[i][4].ToString()));
                        PictureBox gametochoseimg = gsmall.Controls.Find("pictureBox1", true).FirstOrDefault() as PictureBox;
                        Label gametochosename = gsmall.Controls.Find("gamenameGSDetailControlLB", true).FirstOrDefault() as Label;
                        top10UserStoreFPN.Controls.Add(gsmall);
                        pair.Add(i, dtb.Rows[i][0].ToString());
                        //gsmall.Enter += new EventHandler(ChooseGameClick_Handler);

                        //hidenGame = tagListControls1.Controls.Find("comboBox1", true).FirstOrDefault() as ComboBox;
                        
                        hidenGame.DataSource = dtb;
                        hidenGame.ValueMember = "GameID";
                        hidenGame.DisplayMember = "GameID";
                    }
                    foreach (Control cc in top10UserStoreFPN.Controls)
                    {
                        cc.Margin = new Padding(60, 20, 20, 20);
                    }
                }
                //top10UserStoreFPN.Controls
            }
        }
        public void LoadTag()
        {
            DataGridView taginhomepage = tagListControls1.Controls.Find("tagGV", true).FirstOrDefault() as DataGridView;
            Button unchosentaginhomepage = tagListControls1.Controls.Find("clearButton", true).FirstOrDefault() as Button;
            unchosentaginhomepage.Visible = true;
            string query = "select * from dbo.func_GetAllTags()";
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                connection.Open();
                DataTable dtb = new DataTable();
                adapter.Fill(dtb);

                taginhomepage.DataSource = dtb;
                
                DataGridView tgv = tagListControls1.Controls.Find("tagGV", true).FirstOrDefault() as DataGridView;
                tgv.DataSource = dtb;
                hiden = tagListControls1.Controls.Find("comboBox1", true).FirstOrDefault() as ComboBox;
                hiden.DataSource = dtb;
                hiden.SelectedValueChanged += new EventHandler(TagClick_Handler);
                unchosentaginhomepage.Click += new EventHandler(UnchosenTagClick_Handler);
                hiden.ValueMember = "TagName";
                hiden.DisplayMember = "TagName";
                
            }
        }
        public void LoadGameToLib()
        {
           //DataGridView taginlibpage = tagListControls1.Controls.Find("gameListGV", true).FirstOrDefault() as DataGridView;
            string query = "select * from dbo.func_GetGameNameOfUser(@uid)";
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                connection.Open();

                cmd.Parameters.Add("@uid", SqlDbType.Int).Value = currentid;
                cmd.ExecuteNonQuery();

                DataTable dtb = new DataTable();
                adapter.Fill(dtb);

                gameListGV.DataSource = dtb;
                comboBox1.DataSource = dtb;
                comboBox1.DisplayMember = "GameID";
                comboBox1.ValueMember = "GameID";
            }
        }

        public void LoadGameDetail(string gameid)
        {
            string query = "select * from dbo.func_GetGameOfUser(@uid, @gid)";
            byte[] temp = null;
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                connection.Open();

                cmd.Parameters.Add("@uid", SqlDbType.Int).Value = currentid;
                cmd.Parameters.Add("@gid", SqlDbType.NVarChar).Value = gameid;

                //cmd.ExecuteNonQuery();

                DataTable dtb = new DataTable();
                adapter.Fill(dtb);

                //DataRow[] dr = dtb.Select("GameID = '" + gameid + "'");
                if (dtb.Rows.Count >0)
                {
                    Label gamename = gameDetail_Library1.Controls.Find("gnameGdettaillibLabel", true).FirstOrDefault() as Label;
                    gamename.Text = dtb.Rows[0][1].ToString();

                    gameDetail_Library1.Controls["sizeGdetaillibLB"].Text = dtb.Rows[0][5].ToString() + " GB";
                    double dl = Double.Parse(dtb.Rows[0][4].ToString());
                    string dlsize = "";
                    if (dl <= 100)
                    {

                    }
                    else if (dl <= 1000)
                    {
                        dl = dl / 100;
                        dlsize = "K";
                    }
                    else if (dl <= 100000000)
                    {
                        dl = dl / 100000;
                        dlsize = "M";
                    }
                    gameDetail_Library1.Controls["redecodeGdetaillibLB"].Text = dtb.Rows[0][6].ToString();
                    gameDetail_Library1.Controls["downloadGdetaillibLB"].Text = dl.ToString() + dlsize + " Downloads";
                    gameDetail_Library1.Controls["descGdetaillibTB"].Text = dtb.Rows[0][7].ToString();
                    gameDetail_Library1.Controls["platGdetaillibLB"].Text = dtb.Rows[0][2].ToString();
                    gameDetail_Library1.Controls["langGdetaillibLB"].Text = dtb.Rows[0][3].ToString();
                    temp = (byte[])dtb.Rows[0][8];
                    PictureBox imgbox = gameDetail_Library1.Controls.Find("pictureBox1", true).FirstOrDefault() as PictureBox;
                    imgbox.Image = Tools.getImage(temp);
                    imgbox.SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
        }

        
        public void TagClick_Handler(object sender, EventArgs e)
        {
            allgameUserStoreFPN.Controls.Clear();
            if (hiden.Text != "System.Data.DataRowView" && hiden.Items.Count != 0) 
            {
                label3.Text = hiden.SelectedValue.ToString();
            }
            string query = "select * from dbo.func_GetGameByTagForHomePage(@TagName)";
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                connection.Open();
                cmd.Parameters.Add("@TagName", SqlDbType.NVarChar).Value = label3.Text;
                cmd.ExecuteNonQuery();

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dtb = new DataTable();
                adapter.Fill(dtb);

                if (dtb.Rows.Count > 0)
                {
                    for (int i = 0; i < dtb.Rows.Count; i++)
                    {
                        GameSmallDetailControl gsmall = new GameSmallDetailControl(dtb.Rows[i][0].ToString(), Tools.getImage((byte[])dtb.Rows[i][1]), dtb.Rows[i][2].ToString(), int.Parse(dtb.Rows[i][3].ToString()));
                        allgameUserStoreFPN.Controls.Add(gsmall);
                    }
                    foreach (Control cc in allgameUserStoreFPN.Controls)
                    {
                        cc.Margin = new Padding(60, 20, 20, 20);
                    }
                }
            }
        }
        public void UnchosenTagClick_Handler(object sender, EventArgs e)
        {
            LoadNewestGameFirst();
        }
        public void BuyGame_Handler(object sender, EventArgs e)
        {
            int check = 0;
            string query = "select dbo.func_BuyGameCheck(@gid,@uid)";
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                connection.Open();
                cmd.Parameters.Add("@gid", SqlDbType.NVarChar).Value = label4.Text;
                cmd.Parameters.Add("@uid", SqlDbType.Int).Value = currentid;
                check = (int)cmd.ExecuteScalar();

                if(check == 1)
                {
                    query = "sp_BuyGame";
                    using (connection = new SqlConnection(connectionString))
                    using (SqlCommand cmd2 = new SqlCommand(query, connection))
                    {

                        connection.Open();
                        cmd2.CommandType = CommandType.StoredProcedure;

                        cmd2.Parameters.Add("@gameid", SqlDbType.NVarChar).Value = label4.Text;
                        cmd2.Parameters.Add("@userid", SqlDbType.Int).Value = currentid;

                        cmd2.ExecuteNonQueryAsync();
                        MessageBox.Show("This game has been successfully add into your library", "");
                        LoadGameToLib();
                    }
                }
                else MessageBox.Show("Unable to purchase", "");
            }
            //LoadGameInfoToNewTab(gameid, gamebuyCTL);
        }
        // TẠM XONG
        public void LoadGameInfoToNewTab(string gameid)
        {
            GameBuyControl gamebuyCTL = new GameBuyControl();
            gamebuyCTL.Dock = DockStyle.Fill;
            TabPage myTabPage = new TabPage();//Create new tabpage
            myTabPage.Controls.Add(gamebuyCTL);
            myTabPage.BackColor = System.Drawing.Color.FromArgb(32, 32, 32);
            usrtabCntrl.TabPages.Add(myTabPage);
            usrtabCntrl.SelectedTab = myTabPage;


            Button closetag = gamebuyCTL.Controls.Find("existBT", true).FirstOrDefault() as Button;
            closetag.Click += new EventHandler(ClosePageClick_Handler);
            string idofgame = gameid;
            string query = "select * from dbo.func_GetFullGameInformation()";
            byte[] temp = null;
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                connection.Open();

                cmd.ExecuteNonQuery();

                DataTable dtb = new DataTable();
                adapter.Fill(dtb);

                DataRow[] dr = dtb.Select("GameID = '"+gameid+"'");

                gamebuyCTL.Controls["nameOfGame"].Text = dr[0]["GameName"].ToString();
                gamebuyCTL.Controls["priceCount"].Text = dr[0]["Price"].ToString() + " VND";
                gamebuyCTL.Controls["dateReleaseTB"].Text = dr[0]["Release"].ToString();
                gamebuyCTL.Controls["label4"].Text = dr[0]["Download"].ToString() + " downloads";

                //string[] langs = (dr[0]["Lang"].ToString()).Split(',');
                //gamebuyCTL(langs);

                //string[] plats = (dr[0]["Plat"].ToString()).Split(',');
                //gamebuyCTL(plats);

                gamebuyCTL.Controls["sizeCount"].Text = dr[0]["Size"].ToString() + " GB";
                gamebuyCTL.Controls["label3"].Text = "by  " + dr[0]["StudioName"].ToString();

                //DateTimePicker releasedate = gamebuyCTL.Controls.Find("releaseGinfoDTP", true).FirstOrDefault() as DateTimePicker;
                //releasedate.Value = DateTime.Parse(dr[0]["Release"].ToString());

                //gamebuyCTL();
                //ComboBox pub = gamebuyCTL.Controls.Find("publisherGinfoCBB", true).FirstOrDefault() as ComboBox;
                //pub.SelectedIndex = Int32.Parse(dr[0]["StudioID"].ToString()) - 1;

                gamebuyCTL.Controls["descTB"].Text = dr[0]["Descri"].ToString();
                gamebuyCTL.Controls["label7"].Text = dr[0]["Plat"].ToString();
                gamebuyCTL.Controls["label6"].Text = dr[0]["Lang"].ToString();
                gamebuyCTL.Controls["buyGameBtn"].Click += new EventHandler(BuyGame_Handler);
                temp = (byte[])dr[0]["Image"];
                PictureBox imgbox = gamebuyCTL.Controls.Find("pictureOfGame", true).FirstOrDefault() as PictureBox;
                imgbox.Image = Tools.getImage(temp);
                imgbox.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            LoadGameToLib();
        }
        private void LoadProfile()
        {
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("select * from func_Get1User(" + this.currentid + ")", connection))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                DataRow[] row = dataTable.Select("UserID =" + currentid);

                TextBox nametb = userProfileControl1.Controls.Find("nameTB", true).FirstOrDefault() as TextBox;
                nametb.Text = row[0]["UserName"].ToString();

                TextBox pwdTB = userProfileControl1.Controls.Find("pwdTB", true).FirstOrDefault() as TextBox;
                pwdTB.Text = row[0]["Pass"].ToString();

                DateTimePicker dob = userProfileControl1.Controls.Find("dobDTP", true).FirstOrDefault() as DateTimePicker;
                dob.Text = row[0]["DOB"].ToString();

                TextBox credit = userProfileControl1.Controls.Find("cardTB", true).FirstOrDefault() as TextBox;
                credit.Text = row[0]["CreditCard"].ToString();

                Label walletlb = userProfileControl1.Controls.Find("walletCount", true).FirstOrDefault() as Label;
                walletlb.Text = row[0]["Wallet"].ToString();

                Label spentlb = userProfileControl1.Controls.Find("spentCount", true).FirstOrDefault() as Label;
                spentlb.Text = row[0]["Spent"].ToString();

            }
        }
        public void ClosePageClick_Handler(object sender, EventArgs e)
        {
            usrtabCntrl.TabPages.RemoveAt(this.usrtabCntrl.SelectedIndex);
        }

        private void label4_TextChanged(object sender, EventArgs e)
        {
            LoadGameInfoToNewTab(label4.Text);
            
        }

        private void addfundBTN_Click(object sender, EventArgs e)
        {
            TextBox CreditTB = userProfileControl1.Controls.Find("cardTB", true).FirstOrDefault() as TextBox;
            Form addfund = new Addfund(currentid, CreditTB.Text);
            addfund.ShowDialog();
            LoadProfile();
        }

        private void editProfileBTN_Click(object sender, EventArgs e)
        {
            DateTimePicker DobDTP = userProfileControl1.Controls.Find("dobDTP", true).FirstOrDefault() as DateTimePicker;
            TextBox NameTB = userProfileControl1.Controls.Find("nameTB", true).FirstOrDefault() as TextBox;
            TextBox CreditTB = userProfileControl1.Controls.Find("cardTB", true).FirstOrDefault() as TextBox;
            TextBox PwdTB = userProfileControl1.Controls.Find("pwdTB", true).FirstOrDefault() as TextBox;
            PwdTB.Enabled = true;
            CreditTB.Enabled = true;
            NameTB.Enabled = true;
            DobDTP.Enabled = true;
            saveBTN.Enabled = true;
        }

        private void saveBTN_Click(object sender, EventArgs e)
        {

            DateTimePicker DobDTP = userProfileControl1.Controls.Find("dobDTP", true).FirstOrDefault() as DateTimePicker;
            TextBox NameTB = userProfileControl1.Controls.Find("nameTB", true).FirstOrDefault() as TextBox;
            TextBox CreditTB = userProfileControl1.Controls.Find("cardTB", true).FirstOrDefault() as TextBox;
            TextBox PwdTB = userProfileControl1.Controls.Find("pwdTB", true).FirstOrDefault() as TextBox;
            DateTime dob = Convert.ToDateTime(DobDTP.Value.Date);
            string cred = CreditTB.Text;
            string usrname = NameTB.Text;
            string pwd = PwdTB.Text;
            int result;
            string query = "select dbo.func_CheckAccount(@pass,@usr)";
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                cmd.Parameters.Add("@pass", SqlDbType.NVarChar).Value = PwdTB.Text;
                cmd.Parameters.Add("@usr", SqlDbType.NVarChar).Value = " ";
                result = Convert.ToInt32(cmd.ExecuteScalar());
            }
            if (result != 1)
            {
                using (connection = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand("sp_UpdateUserProfile", connection))
                {
                    connection.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@uid", SqlDbType.Int).Value = this.currentid;
                    cmd.Parameters.Add("@username", SqlDbType.NVarChar).Value = usrname;
                    cmd.Parameters.Add("@pass", SqlDbType.NVarChar).Value = pwd;
                    cmd.Parameters.Add("@dob", SqlDbType.Date).Value = dob;
                    cmd.Parameters.Add("@credit", SqlDbType.NVarChar).Value = cred;

                    cmd.ExecuteNonQuery();
                    LoadProfile();
                    CreditTB.Enabled = false;
                    NameTB.Enabled = false;
                    DobDTP.Enabled = false;
                    PwdTB.Enabled = false;
                    saveBTN.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("Password must contain at least 1 number and 1 special character, please type again", "Warning");
            }
           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadGameDetail(comboBox1.Text);
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            LoadGameDetail(comboBox1.Text);
        }

        private void gameListGV_Enter(object sender, EventArgs e)
        {
            LoadGameDetail(comboBox1.Text);
        }
    }
}
