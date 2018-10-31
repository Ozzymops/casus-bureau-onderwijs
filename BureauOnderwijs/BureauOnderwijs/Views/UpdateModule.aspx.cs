using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BureauOnderwijs.Views
{
    public partial class UpdateModule : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string ingelogd = Session["UserId"].ToString();
            DataTable dtbl = new DataTable();
            Models.CC.Examiner_ReadModules RM = new Models.CC.Examiner_ReadModules();
            dtbl = RM.ReadModuleCC(ingelogd);
            GVUpdateModule.DataSource = dtbl;
            GVUpdateModule.DataBind();
        }
    }
}