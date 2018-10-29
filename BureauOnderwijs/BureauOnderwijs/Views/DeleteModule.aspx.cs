using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BureauOnderwijs.Views
{
    public partial class DeleteModule : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //User moet ingelogd zijn om te kunnen deleten. De CC laag wordt aangeroepen en de datatable aangemaakt
            string ingelogd = Session["UserId"].ToString();
            DataTable dtbl = new DataTable();
            Models.CC.Examiner_ReadModules RM = new Models.CC.Examiner_ReadModules();
            dtbl = RM.ReadModuleCC(ingelogd);
            GVDeleteModule.DataSource = dtbl;
            GVDeleteModule.DataBind();
        }

        protected void DeleteId_Click(object sender, EventArgs e)
        {
            //User moet ingelogd zijn om te kunnen deleten. De CC laag wordt aangeroepen en de datatable aangemaakt
            string ingelogd = Session["UserId"].ToString();
            DataTable dtbldelete = new DataTable();
            Models.CC.Examiner_DeleteModule EDM = new Models.CC.Examiner_DeleteModule();
            dtbldelete = EDM.DeleteModuleCC(Convert.ToInt32(TBDelete.Text),ingelogd);
            GVDeleteModule.DataSource = dtbldelete;
            GVDeleteModule.DataBind();
            //pagina refreshen
            Response.Redirect("~/Views/DeleteModule.aspx");
        }
    }
}