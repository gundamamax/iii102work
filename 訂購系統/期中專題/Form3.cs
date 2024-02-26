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
    public partial class Form3 : Form
    {
        SqlConnectionStringBuilder scsb;
        int checkchange = 0;
        List<int> iD = new List<int>();


        public Form3()
        {
            InitializeComponent();

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = @".";
            scsb.InitialCatalog = "GOODFOOD";
            scsb.IntegratedSecurity = true;
            goodsearch();

        }

        private void PRODUCTSearch_TextChanged(object sender, EventArgs e)
        {
            goodsearch();
        }

        private void LbResult_SelectedIndexChanged(object sender, EventArgs e)
        {
            LBRESUT();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            goodsearch();
        }

        private void TBNAME_TextChanged(object sender, EventArgs e)
        {

        }

        private void TBCOST_TextChanged(object sender, EventArgs e)
        {
            bool A = double.TryParse(TBCOST.Text,out double B);
            if (TBCOST.Text=="")
            {
            }
            else if (!A)
            {
                MessageBox.Show("請輸入數字");
                TBCOST.Text = "";
            }
        }

        private void TBPRICE_TextChanged(object sender, EventArgs e)
        {
            bool A = double.TryParse(TBCOST.Text, out double B);
            if (TBPRICE.Text == "")
            {
            }
            else if (!A)
            {
                MessageBox.Show("請輸入數字");
                TBPRICE.Text = "";
            }

        }

        private void BTN1_Click(object sender, EventArgs e)
        {
            newproduct();
        }


        private void BTN2_Click(object sender, EventArgs e)
        {
            Saveproduct();
        }

        private void BTN3_Click(object sender, EventArgs e)
        {
            DialogResult R;
            R = MessageBox.Show
                ("您確認要刪除這個商品的資料嗎?", "刪除確認", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);

            if (R == DialogResult.Yes)
            {
                DelePro();
                checkchange = 0;
            }

        }




        void goodsearch()
        {

            LbResult.Items.Clear();
            iD.Clear();

            SqlConnection con = new SqlConnection(scsb.ToString());
            con.Open();
            string strSQL = "select * from product where product_name like @SearchName";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            cmd.Parameters.AddWithValue("@SearchName", "%" + PRODUCTSearch.Text + "%");
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                LbResult.Items.Add(reader["product_name"]);
                iD.Add(Convert.ToInt32(reader["product_id"]));
            }
            reader.Close();
            con.Close();
        }
        
        void LBRESUT()
        {

            if (LbResult.SelectedItem != null)
            {
                int strID = LbResult.SelectedIndex;

                SqlConnection con = new SqlConnection(scsb.ToString());
                con.Open();
                string strSQL = "select * from product where product_id= @SearchName";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@SearchName", iD[strID]);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read() == true)
                {
                    TBID.Text = string.Format("{0}", reader["product_id"]);
                    

                    //TNICK = string.Format("{0}", reader["product_name"]);
                    TBNAME.Text = string.Format("{0}", reader["product_name"]);

                    //TPHONE = string.Format("{0}", reader["product_cost"]);
                    TBCOST.Text = string.Format("{0}", reader["product_cost"]);

                    //TCELL = string.Format("{0}", reader["product_price"]);
                    TBPRICE.Text = string.Format("{0}", reader["product_price"]);

                }
                reader.Close();
                con.Close();
            }
        }
        
        void newproduct()
        {
            SqlConnection con = new SqlConnection(scsb.ToString());
            con.Open();
            string strSQL =
                "insert into product(product_name) values('')";
            SqlCommand cmd = new SqlCommand(strSQL, con);

            cmd.ExecuteNonQuery();

            strSQL = "select * from product where product_name like ''";
            SqlCommand cmd2 = new SqlCommand(strSQL, con);
            SqlDataReader reader = cmd2.ExecuteReader();

            while (reader.Read() == true)
            {
                TBID.Text = string.Format("{0}", reader["product_id"]);
            }


            reader.Close();
            con.Close();



            TBCOST.Text = "";
            TBNAME.Text = "";
            TBPRICE.Text = "";
        }

        void Saveproduct()
        {


            SqlConnection con = new SqlConnection(scsb.ToString());
            con.Open();
            string strSQL =
            "update product set product_name=@AAA, product_cost=@BBB ,product_price=@CCC  where product_ID=@SearchID";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            cmd.Parameters.AddWithValue("@SearchID", TBID.Text);
            cmd.Parameters.AddWithValue("@AAA", TBNAME.Text);
            cmd.Parameters.AddWithValue("@BBB", TBCOST.Text);
            cmd.Parameters.AddWithValue("@CCC", TBPRICE.Text);


            cmd.ExecuteNonQuery();
            con.Close();
            checkchange = 0;
        }

        void DelePro()
        {

            int intID = 0;
            Int32.TryParse(TBID.Text, out intID);

            SqlConnection con = new SqlConnection(scsb.ToString());
            con.Open();
            string strSQL = "delete from product where product_ID = @SearchID";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            cmd.Parameters.AddWithValue("@SearchID", intID);
            cmd.ExecuteNonQuery();
            con.Close();


            TBID.Text = "";
            TBNAME.Text = "";
            TBPRICE.Text = "";
            TBCOST.Text = "";

        }

    }
}
