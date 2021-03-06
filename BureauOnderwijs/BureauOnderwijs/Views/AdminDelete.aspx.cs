﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace BureauOnderwijs.Views
{
    public partial class AdminDelete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TBUsername_TextChanged(object sender, EventArgs e)
        {

        }

        protected void BTSelect_Click(object sender, EventArgs e)
        //Weergeeft de geselecteerde gebruiker en zijn gegevens
        {
            DataTable dtbl = new DataTable();
            Models.CC.Admin_DeleteAccount oDeleteAccount = new Models.CC.Admin_DeleteAccount();
            dtbl = oDeleteAccount.DeleteUserCC(TBUsername.Text);

            gvUser.DataSource = dtbl;
            gvUser.DataBind();
        }

        protected void BTDelete_Click(object sender, EventArgs e)
        //Verwijdert de geselecteerde gebruiker
        {
            Models.CC.Admin_DeleteAccount oDeleteAccount = new Models.CC.Admin_DeleteAccount();
            int result = oDeleteAccount.DeleteUserExeCC(TBUsername.Text);

            if (result == 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "PopupScript", "alert('Gebruiker verwijderd.');", true);
            }
            else if (result == 1)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "PopupScript", "alert('Verwijderen mislukt. Bestaat de gebruiker?');", true);
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "PopupScript", "alert('Error: Unexpected Respons');", true);
            }
        }
    }
}