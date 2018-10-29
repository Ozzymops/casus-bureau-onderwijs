using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BureauOnderwijs.Views
{
    public partial class WensToevoegen : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                fillGvUserWishes();
            }
        }

        protected void gvUserWishes_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void gvUserWishes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "AddNew")
            {
                int ingelogd = Convert.ToInt32(Session["UserId"]);
                //int ingelogd = 1;

                string dropDownListPeriod = (gvUserWishes.FooterRow.FindControl("DropDownListPeriod") as DropDownList).SelectedValue;
                int dropDownListWeek = Convert.ToInt32((gvUserWishes.FooterRow.FindControl("DropDownListWeek") as DropDownList).SelectedValue);
                string dropDownListDag = (gvUserWishes.FooterRow.FindControl("DropDownListDag") as DropDownList).SelectedValue;
                int dropDownListStartTijdUur = Convert.ToInt32((gvUserWishes.FooterRow.FindControl("DropDownListStartTijdUur") as DropDownList).SelectedValue);
                int dropDownListStartTijdMinuut = Convert.ToInt32((gvUserWishes.FooterRow.FindControl("DropDownListStartTijdMinuut") as DropDownList).SelectedValue);
                int dropDownListEindTijdUur = Convert.ToInt32((gvUserWishes.FooterRow.FindControl("DropDownListEindTijdUur") as DropDownList).SelectedValue);
                int dropDownListEndTijdMinuut = Convert.ToInt32((gvUserWishes.FooterRow.FindControl("DropDownListEndTijdMinuut") as DropDownList).SelectedValue);

                Models.CC.Teacher_CreateWish c = new Models.CC.Teacher_CreateWish();
                int intdag = c.getIntFromDayinput(dropDownListDag);
                int result = c.CreateWishCC(dropDownListPeriod, dropDownListWeek, intdag, dropDownListStartTijdUur, dropDownListStartTijdMinuut, dropDownListEindTijdUur, dropDownListEndTijdMinuut, ingelogd);
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", c.getMessage(result), true);

            }
            else if (e.CommandName == "UserEdit")
            {
                LabelSuccesvol.Text = "Clicked edit";
            }
            else if (e.CommandName == "Delete")
            {
                LabelSuccesvol.Text = "Clicked delete";
            }

            fillGvUserWishes();
        }
        private void fillGvUserWishes()
        {
            //string ingelogd = "1";
            string ingelogd = Session["UserId"].ToString();

            DataTable dt = new DataTable();
            Models.CC.Teacher_ReadWishes r = new Models.CC.Teacher_ReadWishes();
            dt = r.GetUserWishesCC(ingelogd);

            if (dt.Rows.Count > 0)
            {
                Models.CC.Teacher_ReadWishes read = new Models.CC.Teacher_ReadWishes();
                read.makeDatatableReadable(dt);
                gvUserWishes.DataSource = dt;
                gvUserWishes.DataBind();
            }
            else
            {
                dt.Rows.Add("0", "0", "0", "0", "0", "0", "0", "0");
                gvUserWishes.DataSource = dt;
                gvUserWishes.DataBind();
            }
        }
    }
}