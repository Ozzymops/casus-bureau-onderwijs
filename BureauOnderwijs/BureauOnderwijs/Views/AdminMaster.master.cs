using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BureauOnderwijs.Views
{
    public partial class AdminMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void readUsersButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/AdminRead.aspx");
        }

        protected void createUsersButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/AdminCreate.aspx");
        }

        protected void deleteUsersButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/AdminDelete.aspx");
        }
    }
}