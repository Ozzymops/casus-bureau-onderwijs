using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BureauOnderwijs
{
    public partial class LogIn2FaCode : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LabelSessionNumberActive.Text = Session["UserId"].ToString();
            LabelGenerated2FaCodeActive.Text = Session["2FaCode"].ToString();
        }

        protected void ButtonSubmit2FaCode_Click(object sender, EventArgs e)
        {
            if (TextBox2FaCode.Text == Session["2FaCode"].ToString())
            {
                Response.Redirect("Homepage.aspx");
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Ongeldige 2FA Code!');", true);
            }
            
        }
    }
}