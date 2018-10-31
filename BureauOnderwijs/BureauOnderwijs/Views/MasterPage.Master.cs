using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BureauOnderwijs.Models.BU;

namespace BureauOnderwijs.Views
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Get username via UserId, wordt iedere keer herhaald dus let op fouten.
            if (Session["UserId"] != null)
            {
                //Models.CC.LogIn l = new Models.CC.LogIn();
                User u = new User(Convert.ToInt32(Session["UserId"]));
                //welcomeLabel.Text = "Welkom " + l.GetUsername(Convert.ToInt32(Session["UserId"])).ToString() + ".";
                welcomeLabel.Text = "Welkom " + u.UserName + ".";
            }
            else
            {
                welcomeLabel.Text = "Welkom";
            }
        }
    }
}