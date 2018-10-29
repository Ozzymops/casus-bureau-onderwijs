using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BureauOnderwijs.Views
{
    public partial class AdminCreate : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TBUsername_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TBPassword_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TBEmail_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TBFirstName_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TBLastName_TextChanged(object sender, EventArgs e)
        {

        }

        protected void BTSend_Click(object sender, EventArgs e)
        //Verzamelt de ingevulde data en slaat die op in de Database
        {
            Models.CC.Admin_CreateAccount oCreateAccount = new Models.CC.Admin_CreateAccount();
            int result = oCreateAccount.CreateUserCC(TBUsername.Text, TBPassword.Text, TBEmail.Text, TBFirstName.Text, TBLastName.Text, DropDownListRole.SelectedItem.Text);

            if (result == 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "PopupScript", "alert('Gebruiker toegevoegd.');", true);
            }
            else if (result == 1)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "PopupScript", "alert('Toevoegen mislukt. Zijn alle velden juist ingevuld?');", true);
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "PopupScript", "alert('Error: Unexpected Respons');", true);
            }
        }

        protected void BTCancel_Click(object sender, EventArgs e)
        //Maakt de tekstboxxen leeg
        {
            TBUsername.Text = string.Empty;
            TBPassword.Text = string.Empty;
            TBEmail.Text = string.Empty;
            TBFirstName.Text = string.Empty;
            TBLastName.Text = string.Empty;
        }

        protected void DropDownListRole_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}