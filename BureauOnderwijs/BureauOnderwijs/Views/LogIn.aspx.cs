using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BureauOnderwijs.Views
{
    public partial class LogIn : System.Web.UI.Page
    {
        private Models.CC.LogIn l;

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["UserId"] = null;
        }

        protected void ButtonLogin_Click(object sender, EventArgs e)
        {

            // Controle of er iets is ingevuld in de textboxen

            if (string.IsNullOrEmpty(TextBoxUsernameLogin.Text) || string.IsNullOrEmpty(TextBoxPasswordLogin.Text))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Vul a.u.b. een gebruikersnaam en wachtwoord in.');", true);
            }
            else
            {
                /// Gaat met de ingevulde gegevens kijken of dit voorkomt in de database
                /// krijg een array terug, met als eerste nummer de rol van de bestreffende user
                /// en als tweede nummer de unieke userId. Het unieke UserId wordt de sessie, 
                /// hierdoor is later terug te vinden welke gebruiker ingelogd is. 
                
                l = new Models.CC.LogIn();
                int[] RoleUseridRandomNumber = l.LoginCC(TextBoxUsernameLogin.Text, TextBoxPasswordLogin.Text);

                /// feedback: role number errormessage -1 geven en role moet groter zijn dan 0. Als er nieuw rollen toegevoegd worden
                /// feedback: hoeft de code niet aangepast te worden.
                /// feedback: else if statement in cc class verwerken zodat GUI-laag simpeler blijft.
                if (RoleUseridRandomNumber[0] > 0)
                {
                    Session["UserId"] = RoleUseridRandomNumber[1];
                    Session["2FaCode"] = RoleUseridRandomNumber[2];
                    Response.Redirect("~/Views/LogIn2FaCode.aspx");
                }
                else if (RoleUseridRandomNumber[0] < 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", l.GetLoginError(RoleUseridRandomNumber[0]), true);
                }
            }
        }

        protected void ButtonRecovery_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/PasswordRecovery.aspx");
        }
    }
}