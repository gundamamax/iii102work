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
    public partial class productselect : Form
    {

        SqlConnectionStringBuilder scsb;
        List<string> price = new List<string>();


        public productselect()
        {
            InitializeComponent();
        }

        private void DCLICK(object sender, EventArgs e)
        {
                       
            //this.Close();
            if (LbResult.SelectedItem != null)
            {
                ORDERSYSTEM.PROSEL = LbResult.SelectedItem.ToString();
                ORDERSYSTEM.PROSELPRI = price[LbResult.SelectedIndex];
                Close();
            }
        }

        private void productselect_Load(object sender, EventArgs e)
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
            string strSQL = "select * from product where product_name like @SearchName";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            cmd.Parameters.AddWithValue("@SearchName", "%" + TBNameSearch.Text + "%");
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                LbResult.Items.Add(reader["product_name"]);
                price.Add(reader["product_price"].ToString());
            }
            reader.Close();
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (LbResult.SelectedItem != null)
            {
                ORDERSYSTEM.PROSEL = LbResult.SelectedItem.ToString();
                ORDERSYSTEM.PROSELPRI = price[LbResult.SelectedIndex];
                Close();
            }
            Close();

        }
    }
}
