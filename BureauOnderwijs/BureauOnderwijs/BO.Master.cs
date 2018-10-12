using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BureauOnderwijs
{
    public partial class BO : System.Web.UI.MasterPage
    {
        private int role = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            labelke.Text = Page.Title;
        }

    }
}