using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace WebApplication4
{
    public partial class login : System.Web.UI.Page
    {
        SqlConnectionStringBuilder scsb;
        protected void Page_Load(object sender, EventArgs e)
        {
            scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = @".";
            scsb.InitialCatalog = "mi";
            scsb.IntegratedSecurity = true;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(scsb.ToString());
            con.Open();
            string strSQL = "select * from member where M_NAME = @SearchName";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            cmd.Parameters.AddWithValue("@SearchName", TextBox1.Text);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                String PA= string.Format("{0}", reader["M_PASS"]);
                String ID = string.Format("{0}", reader["M_ID"]);
                if (TextBox2.Text != PA)
                {
                    Label4.Text = "帳號與密碼不符";
                }
                else {

                    reader.Close();
                    con.Close();
                    Session["USER"] = TextBox1.Text;
                    Session["UID"] = ID;
                    Response.Redirect("MITIMAIN.aspx");
                }
            }
            else {
                Label4.Text = "帳號與密碼不符";
            }

            reader.Close();
            con.Close();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("regist.aspx");
        }
    }
}