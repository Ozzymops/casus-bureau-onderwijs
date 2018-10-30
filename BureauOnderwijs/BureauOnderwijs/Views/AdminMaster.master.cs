using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BureauOnderwijs.Models.CC;

namespace BureauOnderwijs.Views
{
    public partial class AdminMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int Check = Convert.ToInt32(Session["UserId"]);

            Admin_Authentication oAuthentication = new Admin_Authentication();
            int result = oAuthentication.Authentication(Check);
            if (result == 0)
            {
            }
            else if (result == 1)
            {
                Response.Redirect("~/Views/Homepage");
            }
            else
            {
                Response.Redirect("~/Views/Homepage");
            }
        }

        protected void readUsersButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/AdminRead.aspx");
        }

        protected void createUsersButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/AdminCreate.aspx");
        }

        protected void deleteUsersButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/AdminDelete.aspx");
        }
    }
}