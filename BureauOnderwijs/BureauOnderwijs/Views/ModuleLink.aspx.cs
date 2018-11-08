using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BureauOnderwijs.Views
{
    public partial class ModuleLink : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //controle of de user is ingelogd
            string ingelogd = Session["UserId"].ToString();
            //lege datatable wordt aangemaakt en wordt doorgestuurd naar de Models.CC.Examiner_Readmodules laag
            DataTable dtbl = new DataTable();
            Models.CC.Examiner_ReadModules RM = new Models.CC.Examiner_ReadModules();
            dtbl = RM.ReadModulesLinkedToExaminor(ingelogd);
            GVLinkedModules.DataSource = dtbl;
            GVLinkedModules.DataBind();
        }
    }
}