using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BureauOnderwijs
{
    public partial class NestedModule : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonModuleToevoegen_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddModules.aspx");
        }

        protected void ButtonModuleAanpassen_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditModules.aspx");
        }

        protected void ButtonWeergeven_Click(object sender, EventArgs e)
        {
            Response.Redirect("ReadModules.aspx");
        }

        protected void ButtonVerwijderen_Click(object sender, EventArgs e)
        {
            Response.Redirect("DeleteModules.aspx");
        }

        protected void ButtonReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Homepage.aspx");
        }
    }
}