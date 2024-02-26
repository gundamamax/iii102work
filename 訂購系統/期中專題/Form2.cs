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

namespace 期中專題
{
    public partial class Form2 : Form
    {
        SqlConnectionStringBuilder scsb;
        int checkchange=0;
        List<int> iD = new List<int>();
        string TNAME = "";    //以下都為確認變更用
        string TNICK = "";    //
        string TPHONE = "";   //
        string TCELL = "";    //
        string TADRESS = "";  //
        int sELECT = -1;  //儲存選擇的選項
        bool cancelch;  //選擇取消的確認
        bool searchselect;

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
            scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = @".";
            scsb.InitialCatalog = "GOODFOOD";
            scsb.IntegratedSecurity = true;
            //scsb.UserID = "";
            //scsb.Password = "";

            //runsearch();
            TBNameSearch.Text = " ";
            TBNameSearch.Text = "";

        }

        private void TBNameSearch_TextChanged(object sender, EventArgs e)
        {
            NameSearch();
            searchselect = true;
        }

        private void TBnicksearch_TextChanged(object sender, EventArgs e)
        {
            NICKNameSearch();
            searchselect = false;
        }

        private void LbResult_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cancelch)
            {
                cancelch = false;
            }
            else
            {
                LBRESUT();
            }
            

        }

        private void BTN1_Click(object sender, EventArgs e)
        {

            NewCustormer();

        }

        private void BTN2_Click(object sender, EventArgs e)
        {
            
            SAVEcustormer();
            if (searchselect)
            {
                NameSearch();
            }
            else { NICKNameSearch(); }
            


        }

        private void BTN3_Click(object sender, EventArgs e)
        {
            DialogResult R;
            R=MessageBox.Show
                ("您確認要刪除這個客戶的資料嗎?", "刪除確認", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);

            if (R == DialogResult.Yes)
            {
                Deletecustormer();
                checkchange = 0;

                if (searchselect)
                {
                    NameSearch();
                }
                else { NICKNameSearch(); }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TBNameSearch.Text = "";
            TBnicksearch.Text = "";

        }

        /*void runsearch()
        {

            LbResult.Items.Clear();
            iD.Clear();

            SqlConnection con = new SqlConnection(scsb.ToString());
            con.Open();
            string strSQL = "select * from custormer where _name like @SearchName";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            cmd.Parameters.AddWithValue("@SearchName", "%");
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                LbResult.Items.Add(reader["_name"]);
                iD.Add(Convert.ToInt32(reader["custormer_ID"]));
            }
            reader.Close();
            con.Close();

        }*/

        void NameSearch()
        {
            LbResult.Items.Clear();
            iD.Clear();

            SqlConnection con = new SqlConnection(scsb.ToString());
            con.Open();
            string strSQL = "select * from custormer where _name like @SearchName";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            cmd.Parameters.AddWithValue("@SearchName", "%" + TBNameSearch.Text + "%");
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                LbResult.Items.Add(reader["_name"]);
                iD.Add(Convert.ToInt32(reader["custormer_ID"]));
            }
            reader.Close();
            con.Close();
        }

        void NICKNameSearch()
        {
            LbResult.Items.Clear();
            iD.Clear();


            SqlConnection con = new SqlConnection(scsb.ToString());
            con.Open();
            string strSQL = "select * from custormer where nickname like @SearchName";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            cmd.Parameters.AddWithValue("@SearchName", "%" + TBnicksearch.Text + "%");
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                LbResult.Items.Add(reader["_name"]);
                iD.Add(Convert.ToInt32(reader["custormer_ID"]));
            }
            reader.Close();
            con.Close();

        }

        void LBRESUT()
        {

            if (checkchange == 0)
            {
                if (LbResult.SelectedItem != null)
                {
                    int strID = LbResult.SelectedIndex;
                    sELECT = LbResult.SelectedIndex;

                    SqlConnection con = new SqlConnection(scsb.ToString());
                    con.Open();
                    string strSQL = "select * from custormer where custormer_ID= @SearchName";
                    SqlCommand cmd = new SqlCommand(strSQL, con);
                    cmd.Parameters.AddWithValue("@SearchName", iD[strID]);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read() == true)
                    {
                        TBNUM.Text = string.Format("{0}", reader["custormer_ID"]);

                        TNAME = string.Format("{0}", reader["_name"]);
                        TBNAME.Text = string.Format("{0}", reader["_name"]);

                        TNICK= string.Format("{0}", reader["nickname"]);
                        TBNICKNAME.Text = string.Format("{0}", reader["nickname"]);

                        TPHONE = string.Format("{0}", reader["phone_number"]);
                        TBPHONE.Text = string.Format("{0}", reader["phone_number"]);

                        TCELL = string.Format("{0}", reader["phone_number"]);
                        TBCELL.Text = string.Format("{0}", reader["phone_number"]);

                        TADRESS = string.Format("{0}", reader["custormer_address"]);
                        TBADRESS.Text = string.Format("{0}", reader["custormer_address"]);
                    }
                    reader.Close();
                    con.Close();
                }
            }
            else if (checkchange == 1)
            {
                DialogResult R;
                R = MessageBox.Show
                    ("您尚未儲存，是否要儲存後選擇其他人?\n" +
                    "說明:\n否，為不儲存，選其他人\n" +
                    "取消，為取消選其他人的動作",
                    "變更確認",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Asterisk);
                if(R == DialogResult.Yes)
                {
                    SAVEcustormer();
                    LBRESUT();

                }
                else if(R == DialogResult.No)
                {
                    checkchange = 0;
                    Deletecustormer();
                    LBRESUT();
                }
                else
                {
                    cancelch = true;
                    LbResult.SelectedIndex = sELECT;

                }

            }
            else
            {
                DialogResult R;
                R = MessageBox.Show
                    ("您尚未儲存，是否要儲存後選擇其他人?\n" +
                    "說明:\n否，為不儲存，選其他人\n" +
                    "取消，為取消選其他人的動作",
                    "變更確認",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Asterisk);
                if (R == DialogResult.Yes)
                {
                    SAVEcustormer();
                    LBRESUT();

                }
                else if (R == DialogResult.No)
                {
                    checkchange = 0;
                    LBRESUT();
                }
                else
                {
                    cancelch = true;
                    LbResult.SelectedIndex = sELECT;
                }

            }
        }

        void Deletecustormer()
        {
            int intID = 0;
            Int32.TryParse(TBNUM.Text, out intID);

            SqlConnection con = new SqlConnection(scsb.ToString());
            con.Open();
            string strSQL = "delete from custormer where custormer_ID = @SearchID";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            cmd.Parameters.AddWithValue("@SearchID", intID);
            cmd.ExecuteNonQuery();
            con.Close();


            TBNUM.Text = "";
            TBADRESS.Text = "";
            TBCELL.Text = "";
            TBNAME.Text = "";
            TBPHONE.Text = "";
            TBNICKNAME.Text = "";


        }

        void SAVEcustormer()
        {
            int intID = 0;
            Int32.TryParse(TBNUM.Text, out intID);

            if (intID > 0)
            {
                SqlConnection con = new SqlConnection(scsb.ToString());
                con.Open();
                string strSQL =
                "update custormer set _name=@NewName, nickname=@Newnickname ,phone_number=@Newphone ,cellphone=@Newcellphone,custormer_address=@Newadress where custormer_ID=@SearchID";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@SearchID", intID);
                cmd.Parameters.AddWithValue("@NewName", TBNAME.Text);
                cmd.Parameters.AddWithValue("@Newnickname", TBNICKNAME.Text);
                cmd.Parameters.AddWithValue("@Newphone", TBPHONE.Text);
                cmd.Parameters.AddWithValue("@Newcellphone", TBCELL.Text);
                cmd.Parameters.AddWithValue("@Newadress", TBADRESS.Text);


                cmd.ExecuteNonQuery();
                con.Close();
                checkchange = 0;
            }
            else
            {
                MessageBox.Show("您沒有輸入任何資料");
            }

        }

        void NewCustormer()
        {
            if (checkchange == 0)
            {
                sELECT = -1;

                SqlConnection con = new SqlConnection(scsb.ToString());
                con.Open();
                string strSQL =
                    "insert into custormer(_name) values('')";
                SqlCommand cmd = new SqlCommand(strSQL, con);

                cmd.ExecuteNonQuery();

                strSQL = "select * from custormer where _name like ''";
                SqlCommand cmd2 = new SqlCommand(strSQL, con);
                SqlDataReader reader = cmd2.ExecuteReader();

                while (reader.Read() == true)
                {
                    TBNUM.Text = string.Format("{0}", reader["custormer_ID"]);
                }


                reader.Close();
                con.Close();

                

                TBADRESS.Text = "";
                TBCELL.Text = "";
                TBNAME.Text = "";
                TBPHONE.Text = "";
                TBNICKNAME.Text = "";
                checkchange = 1;
                TBNameSearch.Text = "";
                TBnicksearch.Text = "";
            }
            else if (checkchange == 1)
            {
                DialogResult R;
                R = MessageBox.Show
                    ("您尚未儲存新客戶，是否要儲存並新增客戶?",
                    "變更確認",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Asterisk);
                if (R == DialogResult.Yes)
                {
                    SAVEcustormer();
                    if (searchselect)
                    {
                        NameSearch();
                    }
                    else { NICKNameSearch(); }
                    NewCustormer();

                }
                else 
                {
                }

            }else
            {
                DialogResult R;
                R = MessageBox.Show
                    ("您尚未儲存變更，是否要儲存?",
                    "變更確認",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Asterisk);
                if (R == DialogResult.Yes)
                {
                    SAVEcustormer();
                    NewCustormer();
                }
                else if (R == DialogResult.No)
                {
                    checkchange = 0;
                    NewCustormer();
                }
                else
                {

                }

            }
        }

        private void TBNAME_TextChanged(object sender, EventArgs e)
        {
            if (TBNAME.Text != TNAME)
            {
                checkchange = 2;
            }
        }

        private void TBNICKNAME_TextChanged(object sender, EventArgs e)
        {
            if (TBNICKNAME.Text!=TNICK)
            {
                checkchange = 2;
            }

        }

        private void TBPHONE_TextChanged(object sender, EventArgs e)
        {
            if (TBPHONE.Text!=TPHONE)
            {
                checkchange = 2;
            }

        }

        private void TBCELL_TextChanged(object sender, EventArgs e)
        {
            if (TBCELL.Text!=TCELL)
            {
                checkchange = 2;
            }

        }

        private void TBADRESS_TextChanged(object sender, EventArgs e)
        {
            if (TBADRESS.Text!=TADRESS)
            {
                checkchange = 2;
            }

        }
        
    }
}
