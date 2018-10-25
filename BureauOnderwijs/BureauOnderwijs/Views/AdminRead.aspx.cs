using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using BureauOnderwijs.Models.CC;

namespace BureauOnderwijs.Views
{
    public partial class AdminRead : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //int Check = Convert.ToInt32(Session["UserId"]);

            //Admin_Authentication oAuthentication = new Admin_Authentication();
            //int result = oAuthentication.Authentication(Check);
            //if (result == 0)
            //{
            //    ClientScript.RegisterStartupScript(this.GetType(), "PopupScript", "alert('Welkom Admin');", true);
            //}
            //else if (result == 1)
            //{
            //    ClientScript.RegisterStartupScript(this.GetType(), "PopupScript", "alert('Jij bent geen Admin!?!');", true);
            //}
            //else
            //{
            //    ClientScript.RegisterStartupScript(this.GetType(), "PopupScript", "alert('Error: Unexpected Respons');", true);
            //}

            
            DataTable dtbl = new DataTable();
            Admin_UpdateAccount oUpdateAccount = new Admin_UpdateAccount();
            dtbl = oUpdateAccount.ReadUsersCC();

            gvUsers.DataSource = dtbl;
            gvUsers.DataBind();
        }
    }
}