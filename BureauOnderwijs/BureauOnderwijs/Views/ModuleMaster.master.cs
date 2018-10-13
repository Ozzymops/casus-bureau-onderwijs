using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BureauOnderwijs.Views
{
    public partial class ModuleMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void readModulesButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/ReadModules.aspx");
        }

        protected void addModuleButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/AddModule.aspx");
        }

        protected void editModuleButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/EditModule.aspx");
        }

        protected void deleteModuleButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/DeleteModule.aspx");
        }
    }
}