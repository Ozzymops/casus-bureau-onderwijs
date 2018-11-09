using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BureauOnderwijs.Models.BU;
using BureauOnderwijs.Models.CC;
using System.Diagnostics;

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
                welcomeLabel.Text = "Welkom. Log a.u.b. in.";
            }
            

            //Admin wordt invisible voor andere users
            int Check = Convert.ToInt32(Session["UserId"]);

            Admin_Authentication oAuthentication = new Admin_Authentication();
            int result = oAuthentication.Authentication(Check);
            if (result == 0)
            {
            }
            else if (result == 1)
            {
                AdminButton.Visible = false;
            }
            else
            {
                AdminButton.Visible = false;
            }


            // Pas navigatiebalk aan op basis van rol
            if (Session["RoleId"] != null)
            {
                if ((int)Session["RoleId"] == 1)
                {
                    Debug.WriteLine("role 1");
                    AdminButton.Visible = false;
                    ScheduleButton.Visible = true;
                    WishButton.Visible = false;
                    ModuleButton.Visible = false;
                    SettingsButton.Visible = true;
                }
                else if ((int)Session["RoleId"] == 2)
                {
                    Debug.WriteLine("role 2");
                    AdminButton.Visible = false;
                    ScheduleButton.Visible = true;
                    WishButton.Visible = true;
                    ModuleButton.Visible = true;
                    SettingsButton.Visible = true;
                }
                else if ((int)Session["RoleId"] == 3)
                {
                    Debug.WriteLine("role 3");
                    AdminButton.Visible = false;
                    ScheduleButton.Visible = true;
                    WishButton.Visible = true;
                    ModuleButton.Visible = false;
                    SettingsButton.Visible = true;
                }
                else if ((int)Session["RoleId"] == 4)
                {
                    Debug.WriteLine("role 4");
                    AdminButton.Visible = true;
                    ScheduleButton.Visible = false;
                    WishButton.Visible = false;
                    ModuleButton.Visible = false;
                    SettingsButton.Visible = true;
                }
                else
                {
                    Debug.WriteLine("noppes");
                    AdminButton.Visible = false;
                    ScheduleButton.Visible = false;
                    WishButton.Visible = false;
                    ModuleButton.Visible = false;
                    SettingsButton.Visible = false;
                }
            }
            else
            {
                Debug.WriteLine("noppes");
                AdminButton.Visible = false;
                ScheduleButton.Visible = false;
                WishButton.Visible = false;
                ModuleButton.Visible = false;
                SettingsButton.Visible = false;
            }
        }
    }
}