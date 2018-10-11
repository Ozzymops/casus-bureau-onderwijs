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
            int session = 0;
            

            // Controle of er iets is ingevuld in de textboxen

            if (string.IsNullOrEmpty(TextBoxUsernameLogin.Text) || string.IsNullOrEmpty(TextBoxPasswordLogin.Text))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Vul a.u.b. een gebruikersnaam en wachtwoord in.');", true);
            }
            else
            {

                /// Gaat met de ingevulde gegevens kijken of dit voorkomt in de database
                /// krijg een array terug, met als eerste nummer de rol van de bestreffende user
                /// en als tweede nummer de unieke userId
                
                Models.CC.LogIn l = new Models.CC.LogIn();
                int[] LoginRolenumber = l.LoginCC(TextBoxUsernameLogin.Text, TextBoxPasswordLogin.Text);

                foreach (var number in LoginRolenumber)
                {
                    if (LoginRolenumber.First() == 1)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Ingelogd als Admin');", true);
                        session = Convert.ToInt32(Session["int"]);
                        Response.Redirect("LogIn2FaCode.aspx");
                    }
                    else if (LoginRolenumber.First() == 2)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Inlogegd als Scheduler');", true);
                    }
                    else if (LoginRolenumber.First() == 3)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Ingelogd als Teacher');", true);
                    }
                    else if (LoginRolenumber.First() == 4)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Ingelogd als Examinor');", true);
                    }
                    else if (LoginRolenumber.First() == 10)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Ongeldige gebruikersnaam en of wachtwoord!');", true);
                    }
                    else if (LoginRolenumber.First() == 20)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Connectie met de database problemen.');", true);
                    }
                    else if (LoginRolenumber.First() == 30)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Kom op kerel, je code klopt voor de klote niet.');", true);
                    }
                }
            }
        }
    }
}