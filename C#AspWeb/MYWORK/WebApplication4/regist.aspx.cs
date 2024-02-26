using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace WebApplication4
{
    public partial class regist : System.Web.UI.Page
    {

        SqlConnectionStringBuilder scsb;

        protected void Page_Load(object sender, EventArgs e)
        {
            scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = @".";
            scsb.InitialCatalog = "mi";
            scsb.IntegratedSecurity = true;

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("login.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Label5.Text = "";
            if (RequiredFieldValidator1.IsValid && RequiredFieldValidator2.IsValid && CompareValidator1.IsValid) {

                

                SqlConnection con = new SqlConnection(scsb.ToString());
                con.Open();
                string strSQL = "select * from member where M_NAME = @SearchName";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@SearchName",  TextBox1.Text );
                SqlDataReader reader = cmd.ExecuteReader();


                if (reader.Read())
                {
                    Label5.Text = "帳號已經有人使用";
                    reader.Close();
                    con.Close();
                    return;
                }

                reader.Close();

                strSQL = "insert into member values (@NA,@PA)";
                cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@NA", TextBox1.Text);
                cmd.Parameters.AddWithValue("@PA", TextBox2.Text);
                cmd.ExecuteNonQuery();
                con.Close();

                Response.Redirect("login.aspx");
            }




        }
    }
}