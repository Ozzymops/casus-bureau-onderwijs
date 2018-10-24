using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;

namespace BureauOnderwijs.Views
{
    public partial class AdminRead : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dtbl = new DataTable();
            Models.CC.Admin_UpdateAccount oUpdateAccount = new Models.CC.Admin_UpdateAccount();
            dtbl = oUpdateAccount.ReadUsersCC();

            gvUsers.DataSource = dtbl;
            gvUsers.DataBind();

        }
    }
}