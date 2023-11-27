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
using System.Windows.Forms.DataVisualization.Charting;

namespace Final.Forms
{
    public partial class AdminForm : Form
    {
        private int currentid = 1;
        SqlConnection connection;
        string connectionString;
        public DataGridView SaleDGV;
        public Chart SaleChart;
        public ComboBox GameListCB;
        public ComboBox ChartTypeCB;
        public DateTimePicker SaleDateFromTP;
        private ComboBox hiddenusrBox;
        public AdminForm()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["Final.Properties.Settings.StemDBConnectionStringAdmin"].ConnectionString;
            SaleDGV = saleUC1.Controls.Find("SaleDGV", true).FirstOrDefault() as DataGridView;
            SaleChart = saleUC1.Controls.Find("SaleChart", true).FirstOrDefault() as Chart;
            this.GameListCB = saleUC1.Controls.Find("GameListCB", true).FirstOrDefault() as System.Windows.Forms.ComboBox;
            this.ChartTypeCB = saleUC1.Controls.Find("ChartTypeCB", true).FirstOrDefault() as ComboBox;
            SaleDateFromTP = saleUC1.Controls.Find("SaleDateFromTP", true).FirstOrDefault() as DateTimePicker;
        }
        public AdminForm(int currentid)
        {
            InitializeComponent();
            this.currentid = currentid;
            connectionString = ConfigurationManager.ConnectionStrings["Final.Properties.Settings.StemDBConnectionString"].ConnectionString;
            SaleDGV = saleUC1.Controls.Find("SaleDGV", true).FirstOrDefault() as DataGridView;
            SaleChart = saleUC1.Controls.Find("SaleChart", true).FirstOrDefault() as Chart;
            this.GameListCB = saleUC1.Controls.Find("GameListCB", true).FirstOrDefault() as System.Windows.Forms.ComboBox;
            this.ChartTypeCB = saleUC1.Controls.Find("ChartTypeCB", true).FirstOrDefault() as ComboBox;
            SaleDateFromTP = saleUC1.Controls.Find("SaleDateFromTP", true).FirstOrDefault() as DateTimePicker;
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            LoadStudio();
            LoadGame();
            LoadTag();
            LoadCode();
            LoadDiscount();
            LoadUser();
            SetFontAndColors();
            loadComboBox();
        }
        private void SetFontAndColors()
        {
            DataGridViewCellStyle style = new DataGridViewCellStyle();
            style.BackColor = Color.FromArgb(32, 32, 32);
            style.ForeColor = Color.White;
            addtoTagGV.DefaultCellStyle = style;
            gameinTagGV.DefaultCellStyle = style;
            codeRedeemGrib.DefaultCellStyle = style;
            discountGameGrid.DefaultCellStyle = style;
            addGame2DisGV.DefaultCellStyle = style;

        }
        private void gameListControls1_Enter(object sender, EventArgs e)
        {
            gameTabControl.SelectedTab = gameTabControl.TabPages[0];
        }
        private void studioListControls1_Enter(object sender, EventArgs e)
        {
            gameTabControl.SelectedTab = gameTabControl.TabPages[2];
        }
        private void tagListControls1_Enter(object sender, EventArgs e)
        {
            gameTabControl.SelectedTab = gameTabControl.TabPages[3];
        }
        private void redeemListControls_Enter(object sender, EventArgs e)
        {
            gameTabControl.SelectedTab = gameTabControl.TabPages[1];
        }
        private void savetagButton_Click(object sender, EventArgs e)
        {

        }
        private void LoadDiscount()
        {
            removeDiscountCBB.Text = "";
            editDiscountCBB.Text = "";
            using (connection = new SqlConnection(connectionString))
            using (SqlDataAdapter adapter = new SqlDataAdapter("select * from func_DisAllEvent()", connection))
            {
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                removeDiscountCBB.DataSource = dataTable;
                removeDiscountCBB.DisplayMember = "DisName";
                removeDiscountCBB.ValueMember = "DisID";
                editDiscountCBB.DataSource = dataTable;
                editDiscountCBB.DisplayMember = "DisName";
                editDiscountCBB.ValueMember = "DisID";
                DataGridView dataGridView = discountListControl.Controls.Find("discountGV", true).FirstOrDefault() as DataGridView;
                dataGridView.DataSource = dataTable;
                
            }
        }
        private void LoadUser()
        {
            using (connection = new SqlConnection(connectionString))
            using (SqlDataAdapter adapter = new SqlDataAdapter("select * from func_GetAllUser()", connection))
            {
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                if (dataTable.Rows[0] != null)
                {
                    DataGridView dataGridView = userListControls1.Controls.Find("userGV", true).FirstOrDefault() as DataGridView;
                    dataGridView.DataSource = dataTable;
                    hiddenusrBox = userListControls1.Controls.Find("comboBox1", true).FirstOrDefault() as ComboBox;
                    hiddenusrBox.DataSource = dataTable;
                    hiddenusrBox.DisplayMember = "Username";
                    hiddenusrBox.ValueMember = "UserID";
                    hiddenusrBox.SelectedIndexChanged += new EventHandler(ChooseUser_Handler);
                }


            }
        }
        private DataTable LoadUserLibCode(int id)
        {
            using (connection = new SqlConnection(connectionString))
            using (SqlDataAdapter adapter = new SqlDataAdapter("select * from func_ShowLibUser("+id+")", connection))
            {
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                return dataTable;
            }
        }
        public void ChooseUser_Handler(object sender, EventArgs e)
        {
            if (hiddenusrBox.Text != "System.Data.DataRowView")
            {
                usernameLB.Text = hiddenusrBox.Text;
                using (connection = new SqlConnection(connectionString))
                using (SqlDataAdapter adapter = new SqlDataAdapter("select * from func_GetInfoUser("+ hiddenusrBox.SelectedValue.ToString() + ")", connection))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    if (dataTable.Rows[0] != null)
                    {
                        Label namelb = userInfo1.Controls.Find("usernameUserLB", true).FirstOrDefault() as Label;
                        namelb.Text = dataTable.Rows[0][0].ToString();
                        Label dobUserLB = userInfo1.Controls.Find("dobUserLB", true).FirstOrDefault() as Label;
                        dobUserLB.Text = dataTable.Rows[0][1].ToString();
                        Label walletUserLB = userInfo1.Controls.Find("walletUserLB", true).FirstOrDefault() as Label;
                        walletUserLB.Text = dataTable.Rows[0][2].ToString() + " VND";
                        Label spentUserLB = userInfo1.Controls.Find("spentUserLB", true).FirstOrDefault() as Label;
                        spentUserLB.Text = dataTable.Rows[0][3].ToString() + " VND";
                        Label modeUserLB = userInfo1.Controls.Find("modeUserLB", true).FirstOrDefault() as Label;
                        if (dataTable.Rows[0][4].ToString() == "1")
                        {
                            modeUserLB.Text = "Admin";
                            adminBTN.Text = "Set User";
                        }
                        else { modeUserLB.Text = "User"; adminBTN.Text = "Set Admin"; }

                        DataGridView libUserGrid = userInfo1.Controls.Find("libUserGrid", true).FirstOrDefault() as DataGridView;
                        libUserGrid.DataSource = LoadUserLibCode(int.Parse(hiddenusrBox.SelectedValue.ToString()));
                    }


                }
            }

        }
        private void LoadStudio()
        {
            string query = "select * from dbo.func_GetAllStudio()";
            //ComboBox publishercbb = gameInfo1.Controls.Find("publisherGinfoCBB", true).FirstOrDefault() as ComboBox;
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                connection.Open();
                DataTable dtb = new DataTable();
                adapter.Fill(dtb);
                removeStudioCBB.DataSource = dtb;
                removeStudioCBB.DisplayMember = "StudioName";
                removeStudioCBB.ValueMember = "StudioID";
                addGamePubCBB.DataSource = dtb;
                addGamePubCBB.DisplayMember = "StudioName";
                addGamePubCBB.ValueMember = "StudioID";
                editStudioCBB.DataSource = dtb;
                editStudioCBB.DisplayMember = "StudioName";
                editStudioCBB.ValueMember = "StudioID";
                DataGridView studiogridview = studioListControls.Controls.Find("studioGV", true).FirstOrDefault() as DataGridView;
                studiogridview.DataSource = dtb;

            }
        }
        private void LoadCode()
        {
            string query = "select * from dbo.func_GetAllCode()";
            //ComboBox publishercbb = gameInfo1.Controls.Find("publisherGinfoCBB", true).FirstOrDefault() as ComboBox;
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                connection.Open();
                DataTable dtb = new DataTable();
                adapter.Fill(dtb);
                removeCodeCBB.DataSource = dtb;
                removeCodeCBB.DisplayMember = "Code";
                removeCodeCBB.ValueMember = "Code";
                DataGridView codegridview = redeemListControls.Controls.Find("codeGV", true).FirstOrDefault() as DataGridView;
                codegridview.DataSource = dtb;

            }
        }
        private void LoadGame()
        {
            string query = "select * from dbo.func_GetAllGameSingle()";
            //ComboBox publishercbb = gameInfo1.Controls.Find("publisherGinfoCBB", true).FirstOrDefault() as ComboBox;
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                connection.Open();
                DataTable dtb = new DataTable();
                adapter.Fill(dtb);
                removeGameCBB.DataSource = dtb;
                removeGameCBB.DisplayMember = "GameName";
                removeGameCBB.ValueMember = "GameID";
                addtoTagGV.DataSource = dtb;
                editGameCBB.DataSource = dtb;
                editGameCBB.DisplayMember = "GameName";
                editGameCBB.ValueMember = "GameID";
                chooseCodeGameCBB.DataSource = dtb;
                chooseCodeGameCBB.DisplayMember = "GameName";
                chooseCodeGameCBB.ValueMember = "GameID";
                listCode4GameCBB.DataSource = dtb;
                listCode4GameCBB.DisplayMember = "GameName";
                listCode4GameCBB.ValueMember = "GameID";
                DataGridView gamegridview = gameListControl.Controls.Find("gameGV", true).FirstOrDefault() as DataGridView;
                gamegridview.DataSource = dtb;

            }
        }
        private void LoadTag()
        {
            string query = "select * from dbo.func_GetAllTags()";
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                connection.Open();
                DataTable dtb = new DataTable();
                adapter.Fill(dtb);
                removecomboBox.DataSource = dtb;
                removecomboBox.DisplayMember = "TagName";
                removecomboBox.ValueMember = "TagName";
                addtoTagCBB.DataSource = dtb;
                addtoTagCBB.DisplayMember = "TagName";
                addtoTagCBB.ValueMember = "TagName";
                DataGridView taggridview = tagListControls.Controls.Find("tagGV", true).FirstOrDefault() as DataGridView;
                taggridview.DataSource = dtb;

            }
        }
        private void LoadAddTagToGames(string tagname)
        {
            string query = "select * from dbo.func_GetAllGameAdminbyTag('"+ tagname + "')";
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                connection.Open();
                DataTable dtb = new DataTable();
                adapter.Fill(dtb);
                gameinTagGV.DataSource = dtb;

            }
        }
        private void addGameBTN_Click(object sender, EventArgs e)
        {
            string name = "";
            string id = "";
            int price = 0;
            float size = 0;
            string desc = "";
            string language = "";
            string platform = "";
            DateTime release = DateTime.Now;
            if (addGameNameTB.Text != "" && addGameIDTB.Text !="" && addGameIDTB.Text.Length ==5 )
            {
                name = addGameNameTB.Text;
                id = addGameIDTB.Text;
            }
            else
            {
                MessageBox.Show("Missing game name or invalid game id", "Warning");
            }
            int publisherid = int.Parse(addGamePubCBB.SelectedValue.ToString());
            string query = "dbo.sp_AddNewGame";
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                connection.Open();
                cmd.Parameters.Add("@gameid", SqlDbType.NVarChar).Value = id;
                cmd.Parameters.Add("@stuid", SqlDbType.Int).Value = publisherid;
                cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = name;
                cmd.Parameters.Add("@desc", SqlDbType.NVarChar).Value = desc;
                cmd.Parameters.Add("@price", SqlDbType.Int).Value = price;
                cmd.Parameters.Add("@language", SqlDbType.NVarChar).Value = language;
                cmd.Parameters.Add("@release", SqlDbType.DateTime).Value = release;
                cmd.Parameters.Add("@platform", SqlDbType.NVarChar).Value = platform;
                cmd.Parameters.Add("@size", SqlDbType.Float).Value = size;
                cmd.Parameters.Add("@img", SqlDbType.VarBinary).Value = Tools.DefaultImgBytes();

                cmd.ExecuteNonQuery();
                LoadGame();
            }
            MessageBox.Show("This game has been successfully added", "Announcement");
        }
        private void addStudioBTN_Click(object sender, EventArgs e)
        {
            string name = "";
            string country = "";
            if (addStudioNameTB.Text != "" && addStudioCounTB.Text != "")
            {
                name = addStudioNameTB.Text;
                country = addStudioCounTB.Text;
            }
            else
            {
                MessageBox.Show("Missing name or country value information", "Warning");
            }
            string query = "dbo.sp_AddNewStudio";
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                connection.Open();

                cmd.Parameters.Add("@stuname", SqlDbType.NVarChar).Value = name;
                cmd.Parameters.Add("@country", SqlDbType.NVarChar).Value = country;

                cmd.ExecuteNonQuery();
                LoadStudio();
            }
            MessageBox.Show("This studio has been successfully added", "Announcement");
        }
        private void addTagBTN_Click(object sender, EventArgs e)
        {
            string name = "";
            if (addTagNameTB.Text != "")
            {
                name = addTagNameTB.Text;
            }
            else
            {
                MessageBox.Show("Missing name value information", "Warning");
            }
            string query = "dbo.sp_CreateTag";
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                connection.Open();

                cmd.Parameters.Add("@TagName", SqlDbType.NVarChar).Value = name;

                cmd.ExecuteNonQuery();
            }
            MessageBox.Show("This tag has been successfully added", "Announcement");
            LoadTag();
        }
        private void addtoTagCBB_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadAddTagToGames(addtoTagCBB.SelectedValue.ToString());
        }
        private void addtoTagBTN_Click(object sender, EventArgs e)
        {
            if (addtoTagGV.SelectedRows != null)
            {
                int index = addtoTagGV.CurrentCell.RowIndex;
                addtoTagBTN.Text = addtoTagGV.Rows[index].Cells[0].Value.ToString();
                string query = "dbo.sp_LinkGameWithTag";
                using (connection = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    connection.Open();

                    cmd.Parameters.Add("@TagName", SqlDbType.NVarChar).Value = addtoTagCBB.SelectedValue.ToString();
                    cmd.Parameters.Add("@GameID", SqlDbType.NVarChar).Value = addtoTagBTN.Text;
                    cmd.ExecuteNonQuery();
                    LoadAddTagToGames(addtoTagBTN.Text);
                }
                MessageBox.Show("Success", "Announcement");
            }
            else MessageBox.Show("Please select a game", "Error");
        }
        private void GetStudioFromID(int id)
        {
            string query = "select * from dbo.func_GetAllStudio()";
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                connection.Open();
                DataTable dtb = new DataTable();
                adapter.Fill(dtb);
                DataRow[] dr = dtb.Select("StudioID = "+id);
                editStudioNameTB.Text = dr[0]["StudioName"].ToString();
                editStudioCountryTB.Text = dr[0]["Country"].ToString();

            }
        }
        public void setLanguages(string[] langs)
        {
            foreach (string lang in langs)
            {
                switch (lang)
                {
                    case "English":
                        (gameInfo1.Controls.Find("englishGinfoCB", true).FirstOrDefault() as CheckBox).Checked = true;
                        break;
                    case "Vietnamese":
                        (gameInfo1.Controls.Find("vietnameseGinfoCB", true).FirstOrDefault() as CheckBox).Checked = true;
                        break;
                    case "Japanese":
                        (gameInfo1.Controls.Find("japaneseGinfoCB", true).FirstOrDefault() as CheckBox).Checked = true;
                        break;
                    case "Chinese":
                        (gameInfo1.Controls.Find("chineseGinfoCB", true).FirstOrDefault() as CheckBox).Checked = true;
                        break;
                    case "French":
                        (gameInfo1.Controls.Find("frenchGinfoCB", true).FirstOrDefault() as CheckBox).Checked = true;
                        break;
                    case "German":
                        (gameInfo1.Controls.Find("germanGinfoCB", true).FirstOrDefault() as CheckBox).Checked = true;
                        break;
                    case "Rusian":
                        (gameInfo1.Controls.Find("rusianGinfoCB", true).FirstOrDefault() as CheckBox).Checked = true;
                        break;
                    case "Other":
                        (gameInfo1.Controls.Find("otherGinfoCB", true).FirstOrDefault() as CheckBox).Checked = true;
                        break;
                }
            }
        }
        public void setPlatforms(string[] plats)
        {
            foreach (string plat in plats)
            {
                switch (plat)
                {
                    case "Windows":
                        (gameInfo1.Controls.Find("windowsGinfoCB", true).FirstOrDefault() as CheckBox).Checked = true;
                        break;
                    case "XBOX":
                        (gameInfo1.Controls.Find("xboxGinfoCB", true).FirstOrDefault() as CheckBox).Checked = true;
                        break;
                    case "PlayStation":
                        (gameInfo1.Controls.Find("playstationGinfoCB", true).FirstOrDefault() as CheckBox).Checked = true;
                        break;
                    case "Switch":
                        (gameInfo1.Controls.Find("switchGinfoCB", true).FirstOrDefault() as CheckBox).Checked = true;
                        break;
                }
            }
        }
        public List<CheckBox> createLanguagelist()
        {
            List<CheckBox> allLang = new List<CheckBox>();
            allLang.Add(gameInfo1.Controls.Find("englishGinfoCB", true).FirstOrDefault() as CheckBox);
            allLang.Add(gameInfo1.Controls.Find("vietnameseGinfoCB", true).FirstOrDefault() as CheckBox);
            allLang.Add(gameInfo1.Controls.Find("japaneseGinfoCB", true).FirstOrDefault() as CheckBox);
            allLang.Add(gameInfo1.Controls.Find("chineseGinfoCB", true).FirstOrDefault() as CheckBox);
            allLang.Add(gameInfo1.Controls.Find("frenchGinfoCB", true).FirstOrDefault() as CheckBox);
            allLang.Add(gameInfo1.Controls.Find("germanGinfoCB", true).FirstOrDefault() as CheckBox);
            allLang.Add(gameInfo1.Controls.Find("rusianGinfoCB", true).FirstOrDefault() as CheckBox);
            allLang.Add(gameInfo1.Controls.Find("otherGinfoCB", true).FirstOrDefault() as CheckBox);
            return allLang;
        }
        public List<CheckBox> createPlatformlist()
        {
            List<CheckBox> allPlatform = new List<CheckBox>();
            allPlatform.Add(gameInfo1.Controls.Find("windowsGinfoCB", true).FirstOrDefault() as CheckBox);
            allPlatform.Add(gameInfo1.Controls.Find("xboxGinfoCB", true).FirstOrDefault() as CheckBox);
            allPlatform.Add(gameInfo1.Controls.Find("playstationGinfoCB", true).FirstOrDefault() as CheckBox);
            allPlatform.Add(gameInfo1.Controls.Find("switchGinfoCB", true).FirstOrDefault() as CheckBox);
            allPlatform.Add(gameInfo1.Controls.Find("allGinfoCB", true).FirstOrDefault() as CheckBox);
            return allPlatform;
        }
        public string getLanguage()
        {
            List<CheckBox> allLang = createLanguagelist();
            String language = "";
            foreach (CheckBox lang in allLang)
            {
                if (lang.Checked == true)
                {
                    language = language + lang.Text + ",";
                }
            }
            if (language == "")
            {
                return "";
            }
            return language;
        }
        public string getPlatform()
        {
            List<CheckBox> allPlatform = createPlatformlist();
            String platform = "";
            foreach (CheckBox plat in allPlatform)
            {
                if (plat.Checked == true)
                {
                    platform = platform + plat.Text + ",";
                    if (plat.Text == "ALL")
                    {
                        platform = "Windows,XBOX,PlayStation,Switch,";
                    }
                }
            }
            if (platform == "")
            {
                return "";
            }
            return platform;
        }
        public void SaveGame(string gid)
        {
            string name = "";
            int price = 0;
            if (gameInfo1.Controls["gamenameGinfoTB"].Text != "" && gameInfo1.Controls["priceGinfoTB"].Text != "")
            {
                name = gameInfo1.Controls["gamenameGinfoTB"].Text;
                price = int.Parse(gameInfo1.Controls["priceGinfoTB"].Text);
            }

            else
            {
                MessageBox.Show("Missing game name or price value information", "Warning");
            }

            float size;
            if (gameInfo1.Controls["sizeGinfoTB"].Text == "")
            {
                size = 0;
            }
            else
            {
                size = float.Parse(gameInfo1.Controls["sizeGinfoTB"].Text);
            }

            string desc = gameInfo1.Controls["descriptionGinfoTB"].Text;

            DateTimePicker releasedate = gameInfo1.Controls.Find("releaseGinfoDTP", true).FirstOrDefault() as DateTimePicker;
            DateTime release = releasedate.Value;

            string language = getLanguage();

            string platform = getPlatform();

            ComboBox publisher = gameInfo1.Controls.Find("publisherGinfoCBB", true).FirstOrDefault() as ComboBox;
            int publisherid = int.Parse(publisher.SelectedValue.ToString());

            PictureBox picbox = gameInfo1.Controls.Find("gameimgGinfoPTB", true).FirstOrDefault() as PictureBox;
            byte[] byteImg = Tools.ImageToByteArray(picbox.Image, picbox);

            //MessageBox.Show(release.ToString(), "Warning");
            string query = "dbo.sp_UpdateGameInfo";
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                connection.Open();

                cmd.Parameters.Add("@gid", SqlDbType.NVarChar).Value = gid;
                cmd.Parameters.Add("@stuid", SqlDbType.Int).Value = publisherid;
                cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = name;
                cmd.Parameters.Add("@desc", SqlDbType.NVarChar).Value = desc;
                cmd.Parameters.Add("@price", SqlDbType.Int).Value = price;
                cmd.Parameters.Add("@language", SqlDbType.NVarChar).Value = language;
                cmd.Parameters.Add("@release", SqlDbType.DateTime).Value = release;
                cmd.Parameters.Add("@platform", SqlDbType.NVarChar).Value = platform;
                cmd.Parameters.Add("@size", SqlDbType.Float).Value = size;
                cmd.Parameters.Add("@img", SqlDbType.VarBinary).Value = byteImg;

                cmd.ExecuteNonQuery();
            }
            LoadGame();
            MessageBox.Show("This game has been successfully updated", "Announcement");
        }
        public void loadDatatoform(string gameid)
        {
            string query = "select * from func_GetAllGameSingle()";
            byte[] temp = null;
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                connection.Open();
                DataTable dtb = new DataTable();
                adapter.Fill(dtb);

                DataRow[] dr = dtb.Select("GameID = '"+gameid+"'");

                gameInfo1.Controls["gamenameGinfoTB"].Text = dr[0]["GameName"].ToString();
                gameInfo1.Controls["priceGinfoTB"].Text = dr[0]["Price"].ToString();

                string[] langs = (dr[0]["Lang"].ToString()).Split(',');
                setLanguages(langs);

                string[] plats = (dr[0]["Plat"].ToString()).Split(',');
                setPlatforms(plats);

                gameInfo1.Controls["sizeGinfoTB"].Text = dr[0]["Size"].ToString();

                DateTimePicker releasedate = gameInfo1.Controls.Find("releaseGinfoDTP", true).FirstOrDefault() as DateTimePicker;
                releasedate.Value = DateTime.Parse(dr[0]["Release"].ToString());

                getPublisher();
                ComboBox pub = gameInfo1.Controls.Find("publisherGinfoCBB", true).FirstOrDefault() as ComboBox;
                pub.SelectedValue = Int32.Parse(dr[0]["StudioID"].ToString());

                gameInfo1.Controls["descriptionGinfoTB"].Text = dr[0]["Descri"].ToString();
                    temp = (byte[])dr[0]["Image"];
                    PictureBox imgbox = gameInfo1.Controls.Find("gameimgGinfoPTB", true).FirstOrDefault() as PictureBox;
                    imgbox.Image = Tools.getImage(temp);
                    imgbox.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }
        private void getPublisher()
        {
            string query = "select * from func_GetAllStudio()";
            ComboBox publishercbb = gameInfo1.Controls.Find("publisherGinfoCBB", true).FirstOrDefault() as ComboBox;
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                connection.Open();
                DataTable dtb = new DataTable();
                adapter.Fill(dtb);
                publishercbb.DataSource = dtb;
            }
            publishercbb.DisplayMember = "StudioName";
            publishercbb.ValueMember = "StudioID";
            connection.Close();
        }
        private void editStudioCBB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (int.TryParse(editStudioCBB.SelectedValue.ToString(), out int result))
                GetStudioFromID(result);
        }
        private void editStudioBTN_Click(object sender, EventArgs e)
        {
            if (editStudioNameTB.Text != "" && editStudioCountryTB.Text != "")
            {
                string query = "dbo.sp_UpdateStudio";
                using (connection = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    connection.Open();
                    cmd.Parameters.Add("@StudioID", SqlDbType.Int).Value = int.Parse(editStudioCBB.SelectedValue.ToString());
                    cmd.Parameters.Add("@StudioName", SqlDbType.NVarChar).Value = editStudioNameTB.Text.ToString();
                    cmd.Parameters.Add("@Country", SqlDbType.NVarChar).Value = editStudioCountryTB.Text.ToString();
                    cmd.ExecuteNonQuery();
                    LoadStudio();
                }
                MessageBox.Show("Success", "Announcement");
            }
            else MessageBox.Show("Invalid Value!", "Error");
        }
        private void removeStudioBTN_Click(object sender, EventArgs e)
        {
            string query = "dbo.sp_DeleteStudio";
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                connection.Open();
                cmd.Parameters.Add("@StudioID", SqlDbType.Int).Value = int.Parse(editStudioCBB.SelectedValue.ToString());
                cmd.ExecuteNonQuery();
                LoadStudio();
            }
            MessageBox.Show("Success", "Announcement");
        }

        private void editGameBTN_Click(object sender, EventArgs e)
        {
            loadDatatoform(editGameCBB.SelectedValue.ToString());
        }

        private void editGameCBB_SelectionChangeCommitted(object sender, EventArgs e)
        {
            loadDatatoform(editGameCBB.SelectedValue.ToString());
        }

        private void saveGameBTN_Click(object sender, EventArgs e)
        {
            SaveGame(editGameCBB.SelectedValue.ToString());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string gid = removeGameCBB.SelectedValue.ToString();
            string query = "dbo.sp_DeleteGame";
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                connection.Open();

                cmd.Parameters.Add("@gid", SqlDbType.NVarChar).Value = gid;

                cmd.ExecuteNonQuery();
                LoadGame();
            }
        }

        private void listCodeBTN_Click(object sender, EventArgs e)
        {
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("select * from func_AdminSearchCodeGame(@GameID)", connection))
            {
                connection.Open();
                cmd.Parameters.Add("@GameID", SqlDbType.NVarChar).Value = listCode4GameCBB.SelectedValue.ToString() ;
                cmd.ExecuteNonQuery();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                codeRedeemGrib.DataSource = dt;
            }
        }

        private void generateCodeBTN_Click(object sender, EventArgs e)
        {
            string gid = chooseCodeGameCBB.SelectedValue.ToString();
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("sp_CreateRedeemCode", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                connection.Open();
                cmd.Parameters.Add("@GameID", SqlDbType.NVarChar).Value = gid;
                cmd.ExecuteNonQuery();
                LoadCode();
            }
        }

        private void removeCodeBTN_Click(object sender, EventArgs e)
        {
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("select dbo.func_DeleteNonUseCode(@code)", connection))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                connection.Open();

                cmd.Parameters.Add("@code", SqlDbType.NVarChar).Value = removeCodeCBB.SelectedValue.ToString();

                int result = Convert.ToInt32(cmd.ExecuteScalar());
                if (result == 1)
                {
                    MessageBox.Show("Success", "Announcement");
                    using (SqlCommand cmd2 = new SqlCommand("sp_DeleteRedeemCode", connection))
                    {
                        cmd2.CommandType = CommandType.StoredProcedure;
                        cmd2.Parameters.Add("@code", SqlDbType.NVarChar).Value = removeCodeCBB.SelectedValue.ToString();
                        cmd2.ExecuteNonQuery();
                        LoadCode();
                    }
                }
                else 
                {
                    MessageBox.Show("Code is in used! Choose another code.", "Announcement");
                }
            }
        }

        private void removeDiscountBTN_Click(object sender, EventArgs e)
        {
            if (removeDiscountCBB.Text != "")
            {
                int disID = int.Parse(editDiscountCBB.SelectedValue.ToString());
                using (connection = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand("sp_DeleteDisEvent", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    cmd.Parameters.Add("@DisID", SqlDbType.Int).Value = disID;
                    cmd.ExecuteNonQuery();
                    LoadDiscount();
                }
            }
        }

        private void addDiscountBTN_Click(object sender, EventArgs e)
        {
            if (int.TryParse(disIDAddTB.Text, out int result) && disNameAddTB.Text != "" && disIDTypeTB.Text !="")
            {
                try
                {
                    using (connection = new SqlConnection(connectionString))
                    using (SqlCommand cmd = new SqlCommand("sp_CreateDisEvent", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        connection.Open();
                        cmd.Parameters.Add("@DisID", SqlDbType.Int).Value = result;
                        cmd.Parameters.Add("@DisName", SqlDbType.NVarChar).Value = disNameAddTB.Text;
                        cmd.Parameters.Add("@Amount", SqlDbType.Int).Value = int.Parse(amountAddPicker.Value.ToString());
                        cmd.Parameters.Add("@DisType", SqlDbType.NVarChar).Value = disIDTypeTB.Text;
                        cmd.Parameters.Add("@Disbegin", SqlDbType.Date).Value = datebeginDEVPicker.Value;
                        cmd.Parameters.Add("@Disend", SqlDbType.Date).Value = dateendDEVPicker.Value;
                        cmd.ExecuteNonQuery();
                        LoadDiscount();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Error");
                }
            }
            else 
            {
                MessageBox.Show("Invalid input data.","Error");
            }
            
        }
        private void LoadGame2Dis(string id)
        {
            string query = "select * from dbo.func_DisEventGameFromDID(" + id+")";
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dtb = new DataTable();
                adapter.Fill(dtb);
                discountGameGrid.DataSource = dtb;
            }
        }
        private void LoadGame2Add2Dis()
        {
            string query = "select * from dbo.func_GetAllGameSingle()";
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dtb = new DataTable();
                adapter.Fill(dtb);
                addGame2DisGV.DataSource = dtb;
                secretCBB1.DataSource = dtb;
                secretCBB1.DisplayMember = "GameID";
                secretCBB1.ValueMember = "GameID";
            }
        }
        private void loadDiscountBTN_Click(object sender, EventArgs e)
        {
            string query = "select * from dbo.func_DisAllEvent()";
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, connection))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dtb = new DataTable();
                adapter.Fill(dtb);
                DataRow[] dr = dtb.Select("DisID = " + editDiscountCBB.SelectedValue.ToString());
                disNameEditTB.Text = dr[0]["DisName"].ToString();
                disIDEditTB.Text = dr[0]["DisID"].ToString();
                disTypeEditTB.Text = dr[0]["DisType"].ToString();
                datebeginDEVEditPicker.Value = DateTime.Parse(dr[0]["DayBegin"].ToString());
                dateendDEVEditPicker.Value = DateTime.Parse(dr[0]["DayEnd"].ToString());
                amountEditPicker.Value =int.Parse(dr[0]["Amount"].ToString());
                LoadGame2Dis(editDiscountCBB.SelectedValue.ToString());
                LoadGame2Add2Dis();
                addGame2DisBTN.Enabled = true;

            }
        }

        private void saveDiscountBTN_Click(object sender, EventArgs e)
        {
            if (int.TryParse(disIDEditTB.Text, out int result) && disNameEditTB.Text != "" && disTypeEditTB.Text != "")
            {
                try
                {
                    using (connection = new SqlConnection(connectionString))
                    using (SqlCommand cmd = new SqlCommand("sp_UpdateDisEvent", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        connection.Open();
                        cmd.Parameters.Add("@DisID", SqlDbType.Int).Value = result;
                        cmd.Parameters.Add("@DisName", SqlDbType.NVarChar).Value = disNameEditTB.Text;
                        cmd.Parameters.Add("@Amount", SqlDbType.Int).Value = int.Parse(amountEditPicker.Value.ToString());
                        cmd.Parameters.Add("@DisType", SqlDbType.NVarChar).Value = disTypeEditTB.Text;
                        cmd.Parameters.Add("@Disbegin", SqlDbType.Date).Value = datebeginDEVEditPicker.Value;
                        cmd.Parameters.Add("@Disend", SqlDbType.Date).Value = dateendDEVEditPicker.Value;
                        cmd.ExecuteNonQuery();
                        LoadDiscount();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Error");
                }
            }
            else
            {
                MessageBox.Show("Invalid input data.", "Error");
            }
        }

        private void addGame2DisBTN_Click(object sender, EventArgs e)
        {
            if (secretCBB1.Text != "")
            {
                //sp_DiscountGame
                try
                {
                    using (connection = new SqlConnection(connectionString))
                    using (SqlCommand cmd = new SqlCommand("sp_DiscountGame", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        connection.Open();
                        cmd.Parameters.Add("@DisID", SqlDbType.Int).Value = int.Parse(editDiscountCBB.SelectedValue.ToString());
                        cmd.Parameters.Add("@GameID", SqlDbType.NVarChar).Value = secretCBB1.SelectedValue.ToString();
                        cmd.ExecuteNonQuery();
                        addGame2DisBTN.Text = secretCBB1.SelectedValue.ToString();
                        LoadGame2Dis(editDiscountCBB.SelectedValue.ToString());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Error");
                }
            }
        }
        private void LoadTable()
        {
            using (connection = new SqlConnection(connectionString))
            using (SqlDataAdapter adapter = new SqlDataAdapter("select * from func_ShowSaleData()", connection))
            {
                DataTable Data = new DataTable();
                adapter.Fill(Data);
                SaleDGV.DataSource = Data;

                SaleChart.DataSource = Data;
                SaleChart.Series["Amount"].XValueMember = "GameName";
                SaleChart.Series["Amount"].YValueMembers = "Amount";
                SaleChart.Series["Amount"].ChartType = SeriesChartType.Column;

            }
        }

        private void loadComboBox()
        {
            using (connection = new SqlConnection(connectionString))
            using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT Game.GameName From Game", connection))
            {
                DataTable testTable = new DataTable();
                adapter.Fill(testTable);
                GameListCB.DataSource = testTable;
                GameListCB.ValueMember = "GameName";
            }
        }

        private void LoadTableSaleByMonth()
        {
            int yearTemp = Convert.ToInt32(SaleDateFromTP.Value.Year);
            using (connection = new SqlConnection(connectionString))
            using (SqlDataAdapter adapter = new SqlDataAdapter("select * from func_SaleByMonth(@year)", connection))
            {
                adapter.SelectCommand.Parameters.AddWithValue("@year", yearTemp);
                DataTable Data = new DataTable();
                adapter.Fill(Data);
                SaleDGV.DataSource = Data;

                SaleChart.DataSource = Data;
                SaleChart.Series["Amount"].XValueMember = "sale_Month";
                SaleChart.Series["Amount"].YValueMembers = "sale";
                SaleChart.Series["Amount"].ChartType = SeriesChartType.Column;

            }
        }
        private void LoadTableSaleByYear()
        {
            using (connection = new SqlConnection(connectionString))
            using (SqlDataAdapter adapter = new SqlDataAdapter("select * from func_SaleByYear()", connection))
            {
                DataTable Data = new DataTable();
                adapter.Fill(Data);
                SaleDGV.DataSource = Data;

                SaleChart.DataSource = Data;
                SaleChart.Series["Amount"].XValueMember = "sale_Year";
                SaleChart.Series["Amount"].YValueMembers = "sale";
                SaleChart.Series["Amount"].ChartType = SeriesChartType.Column;

            }
        }

        private void LoadTableSaleOfAllGameByMonth()
        {
            int yearTemp = Convert.ToInt32(SaleDateFromTP.Value.Year);
            int monthTemp = Convert.ToInt32(SaleDateFromTP.Value.Month);
            using (connection = new SqlConnection(connectionString))
            using (SqlDataAdapter adapter = new SqlDataAdapter("select * from func_SaleOfAllGameByMonth(@year,@month)", connection))
            {
                adapter.SelectCommand.Parameters.AddWithValue("@year", yearTemp);
                adapter.SelectCommand.Parameters.AddWithValue("@month", monthTemp);
                DataTable Data = new DataTable();
                adapter.Fill(Data);
                SaleDGV.DataSource = Data;

                SaleChart.DataSource = Data;
                SaleChart.Series["Amount"].XValueMember = "GameName";
                SaleChart.Series["Amount"].YValueMembers = "Amount";
                SaleChart.Series["Amount"].ChartType = SeriesChartType.Column;

            }
        }

        private void LoadTableSaleOfAllGameByYear()
        {
            int yearTemp = Convert.ToInt32(SaleDateFromTP.Value.Year);
            using (connection = new SqlConnection(connectionString))
            using (SqlDataAdapter adapter = new SqlDataAdapter("select * from func_SaleOfAllGameByYear(@year)", connection))
            {
                adapter.SelectCommand.Parameters.AddWithValue("@year", yearTemp);
                DataTable Data = new DataTable();
                adapter.Fill(Data);
                SaleDGV.DataSource = Data;

                SaleChart.DataSource = Data;
                SaleChart.Series["Amount"].XValueMember = "GameName";
                SaleChart.Series["Amount"].YValueMembers = "sale";
                SaleChart.Series["Amount"].ChartType = SeriesChartType.Column;

            }
        }

        private void LoadTableSaleOfGameByMonth()
        {
            int yearTemp = Convert.ToInt32(SaleDateFromTP.Value.Year);
            int monthTemp = Convert.ToInt32(SaleDateFromTP.Value.Month);
            string gameTemp = GameListCB.Text;
            using (connection = new SqlConnection(connectionString))
            using (SqlDataAdapter adapter = new SqlDataAdapter("select * from func_SaleOfGameByMonth(@year,@gamename)", connection))
            {
                adapter.SelectCommand.Parameters.AddWithValue("@year", yearTemp);
                adapter.SelectCommand.Parameters.AddWithValue("@gamename", gameTemp);
                DataTable Data = new DataTable();
                adapter.Fill(Data);
                SaleDGV.DataSource = Data;

                SaleChart.DataSource = Data;
                SaleChart.Series["Amount"].XValueMember = "Sale_Month";
                SaleChart.Series["Amount"].YValueMembers = "Amount";
                SaleChart.Series["Amount"].ChartType = SeriesChartType.Column;

            }
        }

        private void LoadTableSaleOfGameByYear()
        {
            string gameTemp = GameListCB.Text;
            using (connection = new SqlConnection(connectionString))
            using (SqlDataAdapter adapter = new SqlDataAdapter("select * from func_SaleOfGameByYear(@gamename)", connection))
            {
                adapter.SelectCommand.Parameters.AddWithValue("@gamename", gameTemp);
                DataTable Data = new DataTable();
                adapter.Fill(Data);
                SaleDGV.DataSource = Data;

                SaleChart.DataSource = Data;
                SaleChart.Series["Amount"].XValueMember = "Sale_Year";
                SaleChart.Series["Amount"].YValueMembers = "Sale";
                SaleChart.Series["Amount"].ChartType = SeriesChartType.Column;

            }
        }

        //----------------------------Select Type Table and Chart-------------------------------------------

        private void LoadInFor_Click(object sender, EventArgs e)
        {
            try
            {
                int yearTemp = Convert.ToInt32(SaleDateFromTP.Value.Year);
                int monthTemp = Convert.ToInt32(SaleDateFromTP.Value.Month);
                switch (ChartTypeCB.Text)
                {
                    case "Full Data":
                        LoadTable();
                        break;
                    case "Sale By Month":
                        LoadTableSaleByMonth();
                        break;
                    case "Sale By Year":
                        LoadTableSaleByYear();
                        break;
                    case "Sale Of All Game By Month":
                        LoadTableSaleOfAllGameByMonth();
                        break;
                    case "Sale Of All Game By Year":
                        LoadTableSaleOfAllGameByYear();
                        break;
                    case "Sale Of Selected Game By Month":
                        LoadTableSaleOfGameByMonth();
                        break;
                    case "Sale Of Selected Game By Year":
                        LoadTableSaleOfGameByYear();
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void userListControls1_Load(object sender, EventArgs e)
        {

        }

        private void adminBTN_Click(object sender, EventArgs e)
        {
            if (int.TryParse(hiddenusrBox.SelectedValue.ToString(),out int result))
            {
                Label lb = userInfo1.Controls.Find("modeUserLB",true).FirstOrDefault() as Label;
                if (lb.Text == "User")
                {

                    using (connection = new SqlConnection(connectionString))
                    using (SqlCommand cmd = new SqlCommand("sp_SetAdminMode", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        connection.Open();
                        cmd.Parameters.Add("@uid", SqlDbType.Int).Value = result;
                        cmd.ExecuteNonQuery();
                        LoadUser();
                    }
                    lb.Text = "Admin";
                    adminBTN.Text = "Set User";
                }
                else {
                    using (connection = new SqlConnection(connectionString))
                    using (SqlCommand cmd = new SqlCommand("sp_SetUserMode", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        connection.Open();
                        cmd.Parameters.Add("@uid", SqlDbType.Int).Value = result;
                        cmd.ExecuteNonQuery();
                        LoadUser();
                    }
                    lb.Text = "User";
                    adminBTN.Text = "Set Admin";
                }
            }
        }
    }
}
