using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BureauOnderwijs.Views
{
    public partial class WensenMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void showWishesButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Wensen.aspx");
        }

        protected void addWishButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/WensToevoegen.aspx");
        }

        protected void editWishButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/WensWijzigen.aspx");
        }

        protected void deleteWishButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/WensVerwijderen.aspx");
        }
    }
}