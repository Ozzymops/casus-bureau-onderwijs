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
            TitleLabel.Text = "Bureau Onderwijs app";
            TitleLabel.Font.Size = FontUnit.XLarge;
            HeadLabel.Text = Page.Title;
            FootLabel.Text = "© " + DateTime.Now.Year.ToString() + " Dream Team + Youri";
            FootLabel.Font.Size = FontUnit.Small;

            // session gedeuns
        }

    }
}