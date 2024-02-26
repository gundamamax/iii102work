using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication4
{
    public partial class MITIMAIN : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {if(Session["USER"]==null || Session["UID"]== null){

                Response.Redirect("login.aspx");
            }
            Label2.Text = Session["USER"].ToString();

        }
        


        protected void FormView1_ItemInserting(object sender, FormViewInsertEventArgs e)
        {
            string message1 = e.Values["Q_TITLE"].ToString();
            string message2 = e.Values["Q_contents"].ToString();
            string message3 = e.Values["Q_ANSWER"].ToString();
            if (string.IsNullOrEmpty(message1) && string.IsNullOrEmpty(message2) && string.IsNullOrEmpty(message3) )
            {
                Label4.Visible = true;
                Label4.Text = "空白必須填寫";
                e.Cancel = true;
                return;
            }

            e.Values["M_ID"] = Session["UID"].ToString();
            e.Values["Q_answered"] = 0;
        }

        protected void FormView1_ItemInserted(object sender, FormViewInsertedEventArgs e)
        {
            Response.Redirect("MITIMAIN.aspx");
        }
    }
}