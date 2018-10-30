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

        protected void exportWishesButton_Click(object sender, EventArgs e)
        {
            Models.CC.Teacher_ExportWishes Export = new Models.CC.Teacher_ExportWishes();
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