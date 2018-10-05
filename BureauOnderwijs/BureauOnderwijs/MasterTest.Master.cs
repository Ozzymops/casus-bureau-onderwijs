using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BureauOnderwijs
{
    public partial class MasterTest : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BureauOnderwijs.Models.RandomNumberGenerator rng = new BureauOnderwijs.Models.RandomNumberGenerator();
            if (rng.GenerateNumber(0, 3) == 0)
            {
                // normal
                lb_footer.Font.Bold = false;
                lb_footer.Font.Italic = false;
                lb_footer.Text += " normal!";
            }
            else if (rng.GenerateNumber(0, 3) == 1)
            {
                // bold
                lb_footer.Font.Bold = true;
                lb_footer.Font.Italic = false;
                lb_footer.Text += " bold!";
            }
            else if (rng.GenerateNumber(0, 3) == 2)
            {
                // italic
                lb_footer.Font.Bold = false;
                lb_footer.Font.Italic = true;
                lb_footer.Text += " italic!";
            }
            else if (rng.GenerateNumber(0, 3) == 3)
            {
                // bold & italic
                lb_footer.Font.Bold = true;
                lb_footer.Font.Italic = true;
                lb_footer.Text += " bold & italic!";
            }
        }
    }
}