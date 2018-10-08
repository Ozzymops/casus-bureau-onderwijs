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
        protected void Page_Load(object sender, EventArgs e)
        {
            TitleLabel.Text = "Bureau Onderwijs app";
            TitleLabel.Font.Size = FontUnit.XLarge;
            HeadLabel.Text = Page.Title;
            FootLabel.Text = "Copyright Bureau Onderwijs " + DateTime.Now.Year.ToString();
            FootLabel.Font.Size = FontUnit.Small;
        }
    }
}