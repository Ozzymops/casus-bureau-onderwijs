using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace BureauOnderwijs.Views
{
    public partial class Wensen : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string ingelogd = Session["UserId"].ToString();
            DataTable dt = new DataTable();
            Models.CC.Teacher_ReadWishes r = new Models.CC.Teacher_ReadWishes();
            dt = r.GetUserWishesCC(ingelogd);
            DataListWensen.DataSource = dt;
            DataListWensen.DataBind();
        }
    }
}