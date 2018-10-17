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


                string dropDownListPeriod = (gvUserWishes.FooterRow.FindControl("DropDownListPeriod") as DropDownList).SelectedValue;
                int dropDownListWeek = Convert.ToInt32((gvUserWishes.FooterRow.FindControl("DropDownListWeek") as DropDownList).SelectedValue);
                string dropDownListDag = (gvUserWishes.FooterRow.FindControl("DropDownListDag") as DropDownList).SelectedValue;
                string dropDownListStarttijd = (gvUserWishes.FooterRow.FindControl("DropDownListStartTijd") as DropDownList).SelectedValue;
                string dropDownListEindtijd = (gvUserWishes.FooterRow.FindControl("DropDownListEindTijd") as DropDownList).SelectedValue;
                                               
                Models.CC.Teacher_CreateWish c = new Models.CC.Teacher_CreateWish();
                int result = c.CreateWishCC(dropDownListPeriod, dropDownListWeek, dropDownListDag, dropDownListStarttijd, dropDownListEindtijd ,ingelogd);

                if (result == 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Wens succesvol toegevoegd!');", true);
                }
                else if (result == 1)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Wens niet toegevoegd! Probeer het later nog eens.');", true);
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Er is iets fout gegaan, neem contact op met uw netwerkbeheerder!');", true);
                }
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
            string ingelogd = Session["UserId"].ToString();
            DataTable dt = new DataTable();
            Models.CC.Teacher_ReadWishes r = new Models.CC.Teacher_ReadWishes();
            dt = r.GetUserWishesCC(ingelogd);
            if (dt.Rows.Count > 0)
            {
                gvUserWishes.DataSource = dt;
                gvUserWishes.DataBind();
            }
            else
            {
                dt.Rows.Add("0", "Leeg", "0", "Leeg", "00:00:00", "00:00:00");
                gvUserWishes.DataSource = dt;
                gvUserWishes.DataBind();
            }
        }
    }
}