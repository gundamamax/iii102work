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
    public partial class Form5 : Form
    {
        SqlConnectionStringBuilder scsb;
        List<string> price = new List<string>();
        DateTime DT = DateTime.Now;
        int y1;
        int y2;
        int m2;
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {

            scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = @".";
            scsb.InitialCatalog = "GOODFOOD";
            scsb.IntegratedSecurity = true;
            TB1.Text = DT.Year.ToString();
            TB2.Text = DT.Year.ToString();
            TB3.Text = DT.Month.ToString();
            DT1.Value = DT;
            DT2.Value = DT;
            NewMethod();
        }

        private void TB1_TextChanged(object sender, EventArgs e)
        {
            bool T =Int32.TryParse(TB1.Text, out y1);
            if (!T)
            {
                TB1.Text = DT.Year.ToString();
            }
        }

        private void TB2_TextChanged(object sender, EventArgs e)
        {
            bool T = Int32.TryParse(TB2.Text, out y2);
            if (!T)
            {
                TB2.Text = DT.Year.ToString();
            }

        }

        private void TB3_TextChanged(object sender, EventArgs e)
        {

            bool T = Int32.TryParse(TB3.Text, out m2);
            if (!T)
            {
                TB3.Text = DT.Month.ToString();
            }
            else {
                if (m2<1||m2>12)
                {
                    TB3.Text = DT.Month.ToString();
                }
                
            }
        }



        private void TBSEARCH_TextChanged(object sender, EventArgs e)
        {
            NewMethod();
        }

        private void NewMethod()
        {
            listBox1.Items.Clear();
            SqlConnection con = new SqlConnection(scsb.ToString());
            con.Open();
            string strSQL = "select *  from custormer where _name like @Y";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            cmd.Parameters.AddWithValue("@Y", "%" + TBSEARCH.Text + "%");
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                listBox1.Items.Add(reader["_name"]);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s="0";
               SqlConnection con = new SqlConnection(scsb.ToString());
            con.Open();
            string strSQL = "select sum(totalprice) as so from _order where year(_DATE)=@Y";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            cmd.Parameters.AddWithValue("@Y", TB1.Text);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                s=reader["so"].ToString();
            }
            if (s == "") { s = "0"; }
            LBS.Text = TB1.Text + "年的收入為:";
            LBM.Text = s+"元";
        }

        private void button4_Click(object sender, EventArgs e)
        {

            string s = "0";
            SqlConnection con = new SqlConnection(scsb.ToString());
            con.Open();
            string strSQL = "select sum(totalprice) as so from _order where year(_DATE)=@Y and month(_DATE)=@M";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            cmd.Parameters.AddWithValue("@Y", TB2.Text);
            cmd.Parameters.AddWithValue("@M", TB3.Text);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                s = reader["so"].ToString();
            }
            if (s == "") { s = "0"; }
            LBS.Text = TB2.Text + "年"+TB3.Text+"月的收入為:";
            LBM.Text = s + "元";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string s = "0";
            SqlConnection con = new SqlConnection(scsb.ToString());
            con.Open();
            string strSQL = "select sum(totalprice) as so from _order where _DATE > @Y and _DATE < @M";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            cmd.Parameters.AddWithValue("@Y", (DateTime)DT1.Value);
            cmd.Parameters.AddWithValue("@M", (DateTime)DT2.Value);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                s = reader["so"].ToString();
            }
            if (s == "") { s = "0"; }
            LBS.Text = "此期間的收入為:";
            LBM.Text = s + "元";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string s = "0";
            if (listBox1.SelectedItem != null && listBox1.SelectedItem.ToString() != "")
            {
                string SSSS = listBox1.SelectedItem.ToString();
                
                SqlConnection con = new SqlConnection(scsb.ToString());
                con.Open();
                string strSQL = "select sum(totalprice) as so from _order where custormer_ID=(select custormer_ID from custormer where _name='"+SSSS+"')";
                if (checkBox1.Checked)
                {
                    string D5 = DT5.Value.Year.ToString() + "-" + DT5.Value.Month.ToString() + "-" + DT5.Value.Day.ToString();
                    string D6 = DT6.Value.Year.ToString() + "-" + DT6.Value.Month.ToString() + "-" + DT6.Value.Day.ToString();
                    strSQL = "select sum(totalprice) as so from _order where (custormer_ID = (select custormer_ID from custormer where _name='" + SSSS + "'))  and ";
                    strSQL += "_DATE > '" + D5 + "' and _DATE < '" + D6 + "'";
                    SSSS += "在此期間";
                }
                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@N", SSSS);
                
                SqlDataReader reader = cmd.ExecuteReader();
                

                if (reader.Read())
                {
                    s = reader["so"].ToString();
                }
                if (s == "") { s = "0"; }
                LBS.Text = SSSS+" 購買的總金額為:";
                LBM.Text = s + "元";
            }
            else {
                LBS.Text = " 姓名選擇錯誤";
                LBM.Text = "";
            }
        }

        private void DT1_ValueChanged(object sender, EventArgs e)
        {
            if (DT1.Value > DT2.Value)
            {
                DT2.Value = DT1.Value;
            }
        }

        private void DT2_ValueChanged(object sender, EventArgs e)
        {

            if (DT1.Value > DT2.Value)
            {
                DT1.Value = DT2.Value;
            }
        }

        private void DT5_ValueChanged(object sender, EventArgs e)
        {
            if (DT5.Value > DT6.Value)
            {
                DT6.Value = DT5.Value;
            }

        }

        private void DT6_ValueChanged(object sender, EventArgs e)
        {

            if (DT5.Value > DT6.Value)
            {
                DT5.Value = DT6.Value;
            }
        }
    }
}
