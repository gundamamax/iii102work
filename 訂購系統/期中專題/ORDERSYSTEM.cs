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
    public partial class ORDERSYSTEM : Form
    {
        public static String NAMESEL;
        public static String PROSEL;
        public static String PROSELPRI;

        SqlConnectionStringBuilder scsb;
        List<ODdetail> ODdetailLIST = new List<ODdetail>();
        List<int> detailid = new List<int>();
        bool load;
        int SearchWay = 0;

        public ORDERSYSTEM()
        {
            scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = @".";
            scsb.InitialCatalog = "GOODFOOD";
            scsb.IntegratedSecurity = true;

            InitializeComponent();
        }

        private void ORDERSYSTEM_Load(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.RemoveAt(0);
            NAMESEL = "";
            PROSEL = "";
            Rbpayall.Checked = true;
            RBOUTALL.Checked = true; selectord.Checked = true;
            dts.Value = DateTime.Now;
            dtl.Value = DateTime.Now;
            dtl.Value = new DateTime(dtl.Value.Year, dtl.Value.Month + 1, dtl.Value.Day);
            nocompletesearch();
        }      

        private void LBORDER_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LBORDER.SelectedItem != null )
            {
                load = true;
                ResultOrd();
                load = false;
            }
        }

        private void CusSTL_Click(object sender, EventArgs e)
        {
            NAMESEL = TBNAME.Text;
            Form4 fm = new Form4();
            fm.ShowDialog();
            TBNAME.Text = NAMESEL;
            TBCELL.Text = "";
            TBADRESS.Text = "";
            TBPHONE.Text = "";

            CellDfl.PerformClick();
            TelDfl.PerformClick();
            AdressDfl.PerformClick();
        }

        private void TelDfl_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(scsb.ToString());
            con.Open();
            string strSQL = "select phone_number from custormer where _name= @SN";

            SqlCommand cmd = new SqlCommand(strSQL, con);
            cmd.Parameters.AddWithValue("@SN",  TBNAME.Text );
            SqlDataReader reader = cmd.ExecuteReader();

            if(reader.Read() == true)
            {
                TBPHONE.Text = reader["phone_number"].ToString();
            }

            reader.Close();
            con.Close();
        }

        private void CellDfl_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(scsb.ToString());
            con.Open();
            string strSQL = "select cellphone from custormer where _name= @SN";

            SqlCommand cmd = new SqlCommand(strSQL, con);
            cmd.Parameters.AddWithValue("@SN", TBNAME.Text);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read() == true)
            {
                TBCELL.Text = reader["cellphone"].ToString();
            }

            reader.Close();
            con.Close();
        }

        private void AdressDfl_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(scsb.ToString());
            con.Open();
            string strSQL = "select custormer_address from custormer where _name= @SN";

            SqlCommand cmd = new SqlCommand(strSQL, con);
            cmd.Parameters.AddWithValue("@SN", TBNAME.Text);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read() == true)
            {
                TBADRESS.Text = reader["custormer_address"].ToString();
            }

            reader.Close();
            con.Close();
        }

        private void NEWDETL_Click(object sender, EventArgs e)
        {
            newdetail();
        }

        private void DELITEM_Click(object sender, EventArgs e)
        {
            Button DDD = (Button)sender;
            int DL = Convert.ToInt32(DDD.Name);
            flowLayoutPanel1.Controls.RemoveAt(DL);
            ODdetailLIST.RemoveAt(DL);
            
            REPILIE();

            double sum = 0;
            for(int i=0;i< ODdetailLIST.Count; i++)
            {
                double one=0;
                double.TryParse(ODdetailLIST[i].sum.Text, out one);
                sum += one;
            }
            TBTOTOL.Text = sum.ToString();
        }

        void REPILIE()
        {
            for(int i=0;i<= ODdetailLIST.Count()-1;i++)
            {
                ODdetailLIST[i].DEL.Name = i.ToString();
                ODdetailLIST[i].SLT.Name = i.ToString();
            }
        }

        private void PRODUCTSTL_Click(object sender, EventArgs e)
        {
            
            Button SL = (Button)sender;
            int id = Convert.ToInt32(SL.Name);
            PROSEL = ODdetailLIST[id].product.Text;
            PROSELPRI = ODdetailLIST[id].price.Text;
            productselect PRS = new productselect();
            PRS.ShowDialog();
            ODdetailLIST[id].product.Text = PROSEL;
            ODdetailLIST[id].price.Text = PROSELPRI;
            ODdetailLIST[id].proqty.Text = "0";
            ODdetailLIST[id].sum.Text = "0";


        }

        private void NEW_Click(object sender, EventArgs e)
        {
            detailid.Clear();
            ODdetailLIST.Clear();
            flowLayoutPanel1.Controls.Clear();
            neworder();                    
            TBCELL.Text = "";
            TBADRESS.Text = "";
            TBPHONE.Text = "";
            CHEKPAY.Checked = false;
            CHEKOUT.Checked = false;
        }

        private void neworder()
        {
            SqlConnection con = new SqlConnection(scsb.ToString());
            con.Open();
            string strSQL =
                "insert into _order(custormer_ID,_DATE,delivery_date,lastdate) values('0',@DA,@DB,@DC)";
            DateTime dt = DateTime.Now;
            TBORDERDATE.Text = dt.ToShortDateString();
            TBORDERDATE.Text += dt.ToShortTimeString();
            lastcrrect.Text = dt.ToShortDateString();
            lastcrrect.Text += dt.ToShortTimeString();
            TBNAME.Text = "普通客人";
            TBTOTOL.Text = "0";

            DATAOUT.Value = dt;

            string dts = dt.ToString();


            SqlCommand cmd = new SqlCommand(strSQL, con);
            cmd.Parameters.AddWithValue("@DA", dt);
            cmd.Parameters.AddWithValue("@DB", dt);
            cmd.Parameters.AddWithValue("@DC", dt);

            cmd.ExecuteNonQuery();

            strSQL = "select order_id from _order";
            SqlCommand cmd2 = new SqlCommand(strSQL, con);
            SqlDataReader reader = cmd2.ExecuteReader();

            while (reader.Read() == true)
            {
                TBID.Text = string.Format("{0}", reader["order_id"]);
            }


            reader.Close();
            con.Close();

            newdetail();
        }

        private void SAVE_Click(object sender, EventArgs e)
        {
            SaveOrder();
            SaveDetail();
        }

        private void SaveDetail()
        {
            int oddid = 1;
            

            for(int d = 0; d < ODdetailLIST.Count; d++)
            {
                if (ODdetailLIST[d].product.Text == "")
                {
                    ODdetailLIST.RemoveAt(d);
                    flowLayoutPanel1.Controls.RemoveAt(d);
                    d--;
                }
            }

            for (int j = ODdetailLIST.Count; j < detailid.Count; j++)
            {
                SqlConnection con = new SqlConnection(scsb.ToString());
                con.Open();
                string strSQL = "delete from order_detail where order_id=@A and details=@B";
                SqlCommand cmd = new SqlCommand(strSQL, con);

                cmd.Parameters.AddWithValue("@A", TBID.Text);
                cmd.Parameters.AddWithValue("@B", detailid[j]);

                cmd.ExecuteNonQuery();
                con.Close();
            }

            int i = 0;


            for (i=i; i < detailid.Count; i++)//比項目原本細項少或一樣的項目
            {
                if (ODdetailLIST.Count == i )
                {
                    break;
                }

                string PID = "";

                SqlConnection con = new SqlConnection(scsb.ToString());
                con.Open();

                string STSQL = "select product_id from product where product_name=@PN";
                SqlCommand cmd = new SqlCommand(STSQL, con);
                cmd.Parameters.AddWithValue("@PN", ODdetailLIST[i].product.Text);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read() == true) { PID = reader["product_id"].ToString(); };
                reader.Close();


                string strSQL = "update order_detail set  product_id=@B, quantity=@C, Subtotal=@D where order_id=@E and details=@A ";
                cmd = new SqlCommand(strSQL, con);

                cmd.Parameters.AddWithValue("@B", PID);
                cmd.Parameters.AddWithValue("@C", ODdetailLIST[i].proqty.Text);
                cmd.Parameters.AddWithValue("@D", ODdetailLIST[i].sum.Text);
                cmd.Parameters.AddWithValue("@E", TBID.Text);
                cmd.Parameters.AddWithValue("@A", oddid);


                cmd.ExecuteNonQuery();
                con.Close();
                oddid ++;
            }
            for (i = i; i < ODdetailLIST.Count; i++)
            {
                string PID = "";

                SqlConnection con = new SqlConnection(scsb.ToString());
                con.Open();

                string STSQL = "select product_id from product where product_name=@PN";
                SqlCommand cmd = new SqlCommand(STSQL, con);
                cmd.Parameters.AddWithValue("@PN", ODdetailLIST[i].product.Text);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read() == true) { PID = reader["product_id"].ToString(); };
                reader.Close();


                string strSQL = "insert into order_detail(order_id,details,product_id,quantity,Subtotal) values (@A,@B,@C,@D,@E)";
                cmd = new SqlCommand(strSQL, con);

                cmd.Parameters.AddWithValue("@A", TBID.Text);
                cmd.Parameters.AddWithValue("@B", oddid);
                cmd.Parameters.AddWithValue("@C", PID);
                cmd.Parameters.AddWithValue("@D", ODdetailLIST[i].proqty.Text);
                cmd.Parameters.AddWithValue("@E", ODdetailLIST[i].sum.Text);



                cmd.ExecuteNonQuery();
                con.Close();
                oddid++;
            }

            detailid.Clear();
            for(int s = 1; s <= ODdetailLIST.Count; s++)
            {
                detailid.Add(s);
            }
            
            
        }

        private void SaveOrder()
        {
            int intID = 0;
            Int32.TryParse(TBID.Text, out intID);

            string OCID = CIDSEARCH();



            if (intID > 0)
            {
                SqlConnection con = new SqlConnection(scsb.ToString());
                con.Open();
                string strSQL =
                "update _order set custormer_ID=@A,totalprice=@B,delivery_date=@C," +
                "delivery_adress=@D,phone=@E,cellphone=@F," +
                "delivery_check=@G,pay_check=@H,lastdate=@I " +
                "where order_id=@SearchID";
                SqlCommand cmd = new SqlCommand(strSQL, con);

                cmd.Parameters.AddWithValue("@SearchID", intID);
                cmd.Parameters.AddWithValue("@A", OCID);
                cmd.Parameters.AddWithValue("@B", TBTOTOL.Text);
                cmd.Parameters.AddWithValue("@C", (DateTime)DATAOUT.Value);
                cmd.Parameters.AddWithValue("@D", TBADRESS.Text);
                cmd.Parameters.AddWithValue("@E", TBPHONE.Text);
                cmd.Parameters.AddWithValue("@F", TBCELL.Text);
                cmd.Parameters.AddWithValue("@G", (bool)CHEKOUT.Checked);
                cmd.Parameters.AddWithValue("@H", (bool)CHEKPAY.Checked);
                DateTime DT = DateTime.Now;
                cmd.Parameters.AddWithValue("@I", (DateTime)DT);


                cmd.ExecuteNonQuery();
                con.Close();
            }
            else
            {
                MessageBox.Show("您沒有輸入任何資料");
            }
        }

        private string CIDSEARCH()
        {
            SqlConnection con = new SqlConnection(scsb.ToString());
            con.Open();
            string strSQL =
            "select custormer_ID from custormer where _name=@SearchID";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            cmd.Parameters.AddWithValue("@SearchID", TBNAME.Text);
            SqlDataReader reader = cmd.ExecuteReader();
            string A="";
            if (reader.Read() == true)
            {
                A = reader["custormer_ID"].ToString();
            }

            con.Close();
            return A;
        }

        private void DELETE_Click(object sender, EventArgs e)
        {
            DialogResult R;
            R = MessageBox.Show
                ("您確認要刪除這個訂單資料嗎?", "刪除確認", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);

            if (R == DialogResult.Yes)
            {
                DeleteOd();
                
                switch (SearchWay)
                {
                    case 0:
                        nocompletesearch();
                        break;
                    case 1:
                        SEARCH();
                        break;
                    default:
                        break;
                }
            }
        }

        private void DeleteOd()
        {
            int intID = 0;
            Int32.TryParse(TBID.Text, out intID);

            if (intID > 0)
            {
                SqlConnection con = new SqlConnection(scsb.ToString());
                con.Open();
                string strSQL = "delete from order_detail where order_id = @SearchID";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@SearchID", intID);
                cmd.ExecuteNonQuery();

                strSQL= "delete from _order where order_id = @SearchID";
                SqlCommand cmd2 = new SqlCommand(strSQL, con);
                cmd2.Parameters.AddWithValue("@SearchID", intID);
                cmd2.ExecuteNonQuery();


                con.Close();


                ODdetailLIST.Clear();
                detailid.Clear();
                flowLayoutPanel1.Controls.Clear();


                TBNAME.Text = "";
                TBID.Text = "";
                TBCELL.Text = "";
                TBADRESS.Text = "";
                TBORDERDATE.Text = "";
                TBPHONE.Text = "";
                TBTOTOL.Text = "";


            }
            else
            {
                MessageBox.Show("無此ID");
            }

        }

        private void BTNSEARCH_Click(object sender, EventArgs e)
        {
            SEARCH();
            SearchWay = 1;
        }

        void SEARCH()
        {

            LBORDER.Items.Clear();

            SqlConnection con = new SqlConnection(scsb.ToString());
            con.Open();
            string strSQL = "select order_id from _order ";

            if (CBD.Checked || !RBOUTALL.Checked || !Rbpayall.Checked)
            {
                strSQL += " where ";
            }

            if (CBD.Checked)
            {
                if (selectord.Checked)
                {
                    strSQL += "(_DATE >= \'" + dts.Value.ToShortDateString() + "\' and "
                        + "  _DATE<= \'" + dtl.Value.ToShortDateString() + "\') ";

                }
                else
                {
                    //delivery_date
                    strSQL += "(delivery_date >= \'" + dts.Value.ToShortDateString() + "\' and "
                    + "  delivery_date<= \'" + dtl.Value.ToShortDateString() + "\') ";
                }
            }

            if (CBD.Checked && !RBOUTALL.Checked || CBD.Checked && !Rbpayall.Checked)
            {
                strSQL += " and ";
            }
            if (RBOUTALL.Checked) { }
            else if (RBOUTAr.Checked)
            { strSQL += " (delivery_check=1) "; }
            else
            { strSQL += " (delivery_check=0) "; }

            if (!RBOUTALL.Checked && !Rbpayall.Checked)
            {
                strSQL += " and ";
            }
            if (Rbpayall.Checked) { }
            else if (Rbpayar.Checked)
            { strSQL += " (pay_check=1) "; }
            else
            { strSQL += " (pay_check=0) "; }

            // MessageBox.Show(strSQL);

            SqlCommand cmd = new SqlCommand(strSQL, con);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                LBORDER.Items.Add(reader["order_id"]);
            }
            reader.Close();
            con.Close();
        }

        void ResultOrd()
        {
            flowLayoutPanel1.Controls.Clear();
            ODdetailLIST.Clear();
            detailid.Clear();

            String strID = LBORDER.SelectedItem.ToString();

            SqlConnection con = new SqlConnection(scsb.ToString());
            con.Open();
            string strSQL = "select * from _order where order_id= @SearchName";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            cmd.Parameters.AddWithValue("@SearchName", strID);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read() == true)
            {
                TBID.Text = string.Format("{0}", reader["order_id"]);

                DateTime DTEMP = (DateTime)reader["_DATE"];
                TBORDERDATE.Text = DTEMP.ToShortDateString();
                TBORDERDATE.Text += DTEMP.ToShortTimeString();

                TBTOTOL.Text = string.Format("{0}", reader["totalprice"]);

                bool CH = DateTime.TryParse(reader["delivery_date"].ToString(), out DTEMP);
                if (CH)
                {
                    DATAOUT.Value = DTEMP;
                }

                TBADRESS.Text = string.Format("{0}", reader["delivery_adress"]);
                TBPHONE.Text = string.Format("{0}", reader["phone"]);
                TBCELL.Text = string.Format("{0}", reader["cellphone"]);
                CHEKOUT.Checked = (bool)reader["delivery_check"];
                CHEKPAY.Checked = (bool)reader["pay_check"];

                DTEMP = (DateTime)reader["lastdate"];
                lastcrrect.Text = DTEMP.ToShortDateString();
                lastcrrect.Text += DTEMP.ToShortTimeString();


                String CID = string.Format("{0}", reader["custormer_ID"]);
                reader.Close();
                string strSQL2 = "select * from custormer where custormer_ID= @SearchName";
                SqlCommand cmd2 = new SqlCommand(strSQL2, con);
                cmd2.Parameters.AddWithValue("@SearchName", CID);
                SqlDataReader reader2 = cmd2.ExecuteReader();
                if (reader2.Read() == true)
                { TBNAME.Text = string.Format("{0}", reader2["_name"]); }
                reader2.Close();


            }

            reader.Close();
            con.Close();

            DL();
        }

        void DL()
        {
            SqlConnection con = new SqlConnection(scsb.ToString());
            con.Open();
            string strSQL = "select * from order_detail where order_id= @ID";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(TBID.Text));
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                newdetail();
                detailid.Add(ODdetailLIST.Count);

                ODdetailLIST[ODdetailLIST.Count - 1].product.Text =
                    string.Format("{0}", reader["product_id"]);
                ODdetailLIST[ODdetailLIST.Count - 1].proqty.Text =
                    string.Format("{0}", reader["quantity"]);
                ODdetailLIST[ODdetailLIST.Count - 1].sum.Text =
                    string.Format("{0}", reader["Subtotal"]);

               

                

            }
            reader.Close();

            for(int i=0;i< ODdetailLIST.Count; i++) { 

            string strSQL2 = "select * from product where product_id= @SearchName";
            SqlCommand cmd2 = new SqlCommand(strSQL2, con);
            cmd2.Parameters.AddWithValue("@SearchName", ODdetailLIST[i].product.Text);
            SqlDataReader reader2 = cmd2.ExecuteReader();
            if (reader2.Read() == true)
            {
                ODdetailLIST[i].product.Text =
                         string.Format("{0}", reader2["product_name"]);
                ODdetailLIST[i].price.Text =
                       string.Format("{0}", reader2["product_price"]);
            }
            
            reader2.Close();
            }

            con.Close();
        }

        void newdetail()
        {
            ODdetail ND = new ODdetail();

            ND.detail.Size = new System.Drawing.Size(887, 113);
            ND.detail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            flowLayoutPanel1.Controls.Add(ND.detail);

            ND.product.Font = new System.Drawing.Font("微軟正黑體", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            ND.product.Location= new System.Drawing.Point(115, 13);
            ND.product.ReadOnly = true;
            ND.product.Size = new System.Drawing.Size(303, 43);
            ND.detail.Controls.Add(ND.product);
            
            ND.proqty.Font= new System.Drawing.Font("微軟正黑體", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            ND.proqty.Location= new System.Drawing.Point(115, 64);
            ND.proqty.Name = ODdetailLIST.Count.ToString();
            ND.proqty.MaxLength = 10;
            ND.proqty.TextChanged += new System.EventHandler(AMTCHANGE_TextChanged);
            ND.proqty.Size = new System.Drawing.Size(303, 43);
            ND.detail.Controls.Add(ND.proqty);

            ND.price.Font = new System.Drawing.Font("微軟正黑體", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            ND.price.Location= new System.Drawing.Point(605, 3);
            ND.price.Size = new System.Drawing.Size(264, 50);
            ND.price.ReadOnly = true;
            ND.detail.Controls.Add(ND.price);

            ND.sum.Font = new System.Drawing.Font("微軟正黑體", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            ND.sum.Location = new System.Drawing.Point(605, 59);
            ND.sum.Size = new System.Drawing.Size(264, 50);
            ND.sum.Name = ODdetailLIST.Count.ToString();
            ND.sum.MaxLength = 10;
            ND.sum.TextChanged += new System.EventHandler(SUMCHANGE_TextChanged);
            ND.detail.Controls.Add(ND.sum);
            
            ND.DEL.Font = new System.Drawing.Font("微軟正黑體", 14.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            ND.DEL.Location = new System.Drawing.Point(3, 5);
            ND.DEL.Name = ODdetailLIST.Count.ToString();
            ND.DEL.Size = new System.Drawing.Size(34, 104);
            ND.DEL.Text = "刪除項目";
            ND.DEL.UseVisualStyleBackColor = true;
            ND.DEL.Click += new System.EventHandler(DELITEM_Click);
            ND.detail.Controls.Add(ND.DEL);

            ND.SLT.Font =  new System.Drawing.Font("微軟正黑體", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            ND.SLT.Location = new System.Drawing.Point(425, 15);
            ND.SLT.Name = ODdetailLIST.Count.ToString();
            ND.SLT.Size = new System.Drawing.Size(94, 39);
            ND.SLT.Text = "選擇";
            ND.SLT.UseVisualStyleBackColor = true;
            ND.SLT.Click += new System.EventHandler(PRODUCTSTL_Click);
            ND.detail.Controls.Add(ND.SLT);

            Label LB = new Label();
            LB.AutoSize = true;
            LB.Font = new System.Drawing.Font("微軟正黑體", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            LB.Location = new System.Drawing.Point(40, 16);
            LB.Text = "商品";
            ND.detail.Controls.Add(LB);

            Label LC = new Label();
            LC.AutoSize = true;
            LC.Font = new System.Drawing.Font("微軟正黑體", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            LC.Location = new System.Drawing.Point(40, 67);
            LC.Text = "數量";
            ND.detail.Controls.Add(LC);

            Label LD = new Label();
            LD.AutoSize = true;
            LD.Font = new System.Drawing.Font("微軟正黑體", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            LD.Location = new System.Drawing.Point(530, 11);
            LD.Text = "單價";
            ND.detail.Controls.Add(LD);

            Label LE = new Label();
            LE.AutoSize = true;
            LE.Font = new System.Drawing.Font("微軟正黑體", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            LE.Location = new System.Drawing.Point(530, 68);
            LE.Text = "小計";
            ND.detail.Controls.Add(LE);


            ODdetailLIST.Add(ND);
        }        

        private void AMTCHANGE_TextChanged(object sender, EventArgs e)
        {
            if (!load)
            {
                NewMethod(sender);
            }
        }

        private void NewMethod(object sender)
        {
            TextBox DDD = (TextBox)sender;
            int am;
            int ind = Convert.ToInt32(DDD.Name);

            bool check = int.TryParse(DDD.Text, out am);

            if (check && ODdetailLIST[ind].price.Text != "")
            {
                DDD.Text = am.ToString();
                double price = Convert.ToDouble(ODdetailLIST[ind].price.Text);
                double sum = price * am;
                ODdetailLIST[ind].sum.Text
                    = sum.ToString();
            }
            else if (check)
            {

            }
            else
            {
                DDD.Text = "";
                ODdetailLIST[ind].sum.Text = "";
            }
        }

        private void SUMCHANGE_TextChanged(object sender, EventArgs e)
        {
            TextBox TTT = (TextBox)sender;
            bool B = double.TryParse(TTT.Text, out double a);
            if (B)
            {
                double sum = 0;
                for (int i = 0; i < ODdetailLIST.Count; i++)
                {
                    if (ODdetailLIST[i].sum.Text != "") {
                        sum += Convert.ToDouble(ODdetailLIST[i].sum.Text);
                    }
                }

                TBTOTOL.Text = sum.ToString();
            }
            else if (TTT.Text == "")
            { }
            else
            {
                int DL = Convert.ToInt32(TTT.Name);
                TTT.Text = (Convert.ToDouble(ODdetailLIST[DL].proqty.Text)
                    * Convert.ToDouble(ODdetailLIST[DL].price.Text))
                    .ToString();
            }
        }

        void nocompletesearch()
        {


            LBORDER.Items.Clear();

            SqlConnection con = new SqlConnection(scsb.ToString());
            con.Open();
            string strSQL = "select order_id from _order where delivery_check=0 or pay_check=0";

            SqlCommand cmd = new SqlCommand(strSQL, con);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                LBORDER.Items.Add(reader["order_id"]);
            }
            reader.Close();
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            nocompletesearch();
            SearchWay = 0;
        }


    }
}
