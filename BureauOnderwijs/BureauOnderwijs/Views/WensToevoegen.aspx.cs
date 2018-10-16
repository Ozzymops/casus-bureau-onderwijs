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

            //string dropDownListPeriod = (DropDownList)gvUserWishes.FooterRow.FindControl("DropDownListPeriod").ToString();

            if (e.CommandName == "AddNew")
            {
                //int ingelogd = Convert.ToInt32(Session["UsedId"].ToString());
                int ingelogd = 1;
                
                Models.CC.Teacher_CreateWish c = new Models.CC.Teacher_CreateWish();
                int result = c.CreateWishCC(gvUserWishes.FooterRow.FindControl("DropDownListWeek").ToString(),
                    1, "Maandag", "09:00:00", "10:00:00",
                    ingelogd);
                    
                    
                    
                    //Convert.ToInt32(gvUserWishes.FooterRow.FindControl("DropDownListWeek").ToString()),
                    //gvUserWishes.FooterRow.FindControl("DropDownListDag").ToString(), 
                    //gvUserWishes.FooterRow.FindControl("DropDownListStartTijd").ToString(),
                    //gvUserWishes.FooterRow.FindControl("DropDownListEindTijd").ToString(),
                    //ingelogd);

                //int result = c.CreateWishCC((gvUserWishes.FooterRow.FindControl("DropDownListPeriod") as TextBox).Text,
                //    (Convert.ToInt32(gvUserWishes.FooterRow.FindControl("textboxWeekFooter") as TextBox)),
                //    (gvUserWishes.FooterRow.FindControl("textboxDayFooter") as TextBox).Text,
                //    (Convert.ToDateTime(gvUserWishes.FooterRow.FindControl("textboxStartTimeFooter") as TextBox)),
                //    (Convert.ToDateTime(gvUserWishes.FooterRow.FindControl("textboxEndTimeFooter") as TextBox)),
                //    ingelogd);

                if (result == 0)
                {
                    LabelSuccesvol.Text = "SUCCES!";
                }
                else if (result == 1)
                {
                    LabelSuccesvol.Text = "EPIC FAIL";
                }
                else
                {
                    LabelSuccesvol.Text = "MASTER EPIC FAIL";
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
            //string ingelogd = Session["UserId"].ToString();
            string ingelogd = "1";
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