using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace WebApplication4
{
    public partial class MITIAN : System.Web.UI.Page
    {
        SqlConnectionStringBuilder scsb;
        string id;
        string ANS;
        protected void Page_Load(object sender, EventArgs e)
        {
            id = Request.QueryString["Q_ID"];
            if (string.IsNullOrEmpty(id))
                Response.Redirect("MITIMAIN.aspx");
            scsb = new SqlConnectionStringBuilder();
            scsb.DataSource = @".";
            scsb.InitialCatalog = "mi";
            scsb.IntegratedSecurity = true;
            SqlConnection con = new SqlConnection(scsb.ToString());
            con.Open();
            string strSQL = "select * from question where Q_ID = @SearchName";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            cmd.Parameters.AddWithValue("@SearchName", id);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                Label1.Text = string.Format("{0}", reader["Q_TITLE"]);
                Label2.Text= string.Format("{0}", reader["Q_contents"]);
                ANS= string.Format("{0}", reader["Q_ANSWER"]);
            }
            else {

                Response.Redirect("MITIMAIN.aspx");
            }

            reader.Close();
            con.Close();




        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void FormView1_ItemInserting(object sender, FormViewInsertEventArgs e)
        {

            string message1 = e.Values["A_ANSWERdetail"].ToString();
            if (string.IsNullOrEmpty(message1) )
            {
                Label7.Visible = true;
                Label7.Text = "空白必須填寫";
                e.Cancel = true;
                return;
            }
            e.Values["M_ID"] = Session["UID"].ToString();
            e.Values["A_ANSWER"] = Session["USER"].ToString();
            e.Values["Q_ID"] = id;
            int tf;
            if (ANS == message1) {
                tf = 1;
                SqlConnection con = new SqlConnection(scsb.ToString());
                con.Open();
                string strSQL = "update question set Q_answered=@AAA where Q_ID=@SearchID";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@SearchID", id);
                cmd.Parameters.AddWithValue("@AAA", tf);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            else
            {
                tf = 0;
            }
            e.Values["A_CORRECT"] = tf;

            
            

        }

        protected void Button1_Click1(object sender, EventArgs e)
        {

            Response.Redirect("MITIMAIN.aspx");
        }


    }
}