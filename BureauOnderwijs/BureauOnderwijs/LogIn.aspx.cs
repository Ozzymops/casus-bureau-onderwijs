using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
            if (string.IsNullOrEmpty(TextBoxUsernameLogin.Text) || string.IsNullOrEmpty(TextBoxPasswordLogin.Text))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Vul a.u.b. een gebruikersnaam en wachtwoord in.');", true);
            }
            else
            {
                Models.CC.LogIn l = new Models.CC.LogIn();
                int LoginRolenumber = l.LoginCC(TextBoxUsernameLogin.Text, TextBoxPasswordLogin.Text);
                if (LoginRolenumber == 1)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Ingelogd als Admin');", true);
                }
                else if (LoginRolenumber == 2)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Inlogegd als Scheduler');", true);
                }
                else if (LoginRolenumber == 3)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Ingelogd als Teacher');", true);
                }
                else if (LoginRolenumber == 4)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Ingelogd als Examinor');", true);
                }
                else if (LoginRolenumber == 10)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Ongeldige gebruikersnaam en of wachtwoord!');", true);
                }
                else if (LoginRolenumber == 20)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Connectie met de database problemen.');", true);
                }
                else if (LoginRolenumber == 30)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Kom op kerel, je code klopt voor de klote niet.');", true);
                }

            }
        }
    }
}