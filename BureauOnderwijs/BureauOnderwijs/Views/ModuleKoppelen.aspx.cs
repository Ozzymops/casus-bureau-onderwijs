using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BureauOnderwijs.Views
{
    public partial class ModuleKoppelen : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BTOpslaan_Click(object sender, EventArgs e)
        {

        }

        protected void BTAnnuleren_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/ModuleKoppelen.aspx");
        }
    }
}