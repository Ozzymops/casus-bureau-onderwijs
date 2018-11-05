using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BureauOnderwijs.Models.CC;

namespace BureauOnderwijs.Views
{
    public partial class WensenMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int Check = Convert.ToInt32(Session["UserId"]);

            Scheduler_Authentication oAuthentication = new Scheduler_Authentication();
            int result = oAuthentication.Authentication(Check);
            if (result == 0)
            {
            }
            else if (result == 1)
            {
                ExportWishesButton.Visible = false;
            }
            else
            {
                ExportWishesButton.Visible = false;
            }
        }

        protected void showWishesButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/WensToevoegen.aspx");
        }

        protected void exportWishesButton_Click(object sender, EventArgs e)
        {
            Scheduler_ExportWishlist Export = new Scheduler_ExportWishlist();
            int result = Export.ExportWishesCC();

            if (result == 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "PopupScript", "alert('Excelbestand is gemaakt.');", true);
                Response.ContentType = "Application/xls";
                Response.AppendHeader("Content-Disposition", "attachment; filename=WensenlijstExcel.xls");
                Response.TransmitFile(Server.MapPath("~/Downloads/WensenlijstExcel.xls"));
                Response.End();
            }
            else if (result == 1)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "PopupScript", "alert('Excel is niet juist geinstalleerd.');", true);
            }
            else if (result == 2)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "PopupScript", "alert('Kan gegevens niet toevoegen aan Excel bestand');", true);
            }
            else if (result == 3)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "PopupScript", "alert('Kan gegevens niet opslaan');", true);

            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "PopupScript", "alert('Error: Unexpected Respons');", true);
            }


        }
    }
}