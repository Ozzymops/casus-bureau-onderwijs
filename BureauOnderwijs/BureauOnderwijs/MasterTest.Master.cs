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
            if (GenerateNumber(3) == 0)
            {
                // normal
                lb_footer.Font.Bold = false;
                lb_footer.Font.Italic = false;
            }
            else if (GenerateNumber(3) == 1)
            {
                // bold
                lb_footer.Font.Bold = true;
                lb_footer.Font.Italic = false;
            }
            else if (GenerateNumber(3) == 2)
            {
                // italic
                lb_footer.Font.Bold = false;
                lb_footer.Font.Italic = true;
            }
            else if (GenerateNumber(3) == 3)
            {
                // bold & italic
                lb_footer.Font.Bold = true;
                lb_footer.Font.Italic = true;
            }
        }

        private int GenerateNumber(int max)
        {
            Random r = new Random();
            int number = r.Next(0, max);
            return number;
        }
    }
}