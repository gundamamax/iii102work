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
    public partial class Form4 : Form
    {

        SqlConnectionStringBuilder scsb;
        List<string> name = new List<string>();


        public Form4()
        {
            InitializeComponent();
        }

        private void DCLICK(object sender, EventArgs e)
        {

            //this.Close();
            if (LbResult.SelectedItem != null)
            {
                ORDERSYSTEM.NAMESEL = name[LbResult.SelectedIndex];
                Close();
            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {

            scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = @".";
            scsb.InitialCatalog = "GOODFOOD";
            scsb.IntegratedSecurity = true;
            search();
        }

        private void TBNameSearch_TextChanged(object sender, EventArgs e)
        {
            search();
        }

        private void search()
        {
            LbResult.Items.Clear();

            SqlConnection con = new SqlConnection(scsb.ToString());
            con.Open();
            string strSQL = "select * from custormer where _name like @SearchName";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            cmd.Parameters.AddWithValue("@SearchName", "%" + TBNameSearch.Text + "%");
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                LbResult.Items.Add(reader["_name"]);
                name.Add(reader["_name"].ToString());
            }
            reader.Close();
            con.Close();
        }



        private void button1_Click_1(object sender, EventArgs e)
        {

            if (LbResult.SelectedItem != null)
            {
                ORDERSYSTEM.NAMESEL = name[LbResult.SelectedIndex];
                Close();
            }
            Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            LbResult.Items.Clear();

            SqlConnection con = new SqlConnection(scsb.ToString());
            con.Open();
            string strSQL = "select * from custormer where nickname like @SearchName";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            cmd.Parameters.AddWithValue("@SearchName", "%" + textBox1.Text + "%");
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                LbResult.Items.Add(reader["nickname"]);
                name.Add(reader["_name"].ToString());
            }
            reader.Close();
            con.Close();
        }
    }
}
