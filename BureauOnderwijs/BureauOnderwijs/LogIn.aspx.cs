using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BureauOnderwijs
{
    public partial class LogIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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
                
                Models.CC.LogIn l = new Models.CC.LogIn();
                int[] RoleUseridNumber = l.LoginCC(TextBoxUsernameLogin.Text, TextBoxPasswordLogin.Text);

                foreach (var number in RoleUseridNumber)
                {
                    if (RoleUseridNumber[0] > 0 && RoleUseridNumber[0] < 5)
                    {
                        Session["UserId"] = RoleUseridNumber[1];
                        Session["2FaCode"] = RoleUseridNumber[2];
                        Response.Redirect("LogIn2FaCode.aspx");
                    }
                    else if (RoleUseridNumber[0] == 10)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Ongeldige gebruikersnaam en of wachtwoord!');", true);
                    }
                    else if (RoleUseridNumber[0] == 20)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Connectie met de database problemen.');", true);
                    }
                    else if (RoleUseridNumber[0] == 30)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Kom op kerel, je code klopt voor de klote niet.');", true);
                    }
                }
            }
        }
    }
}