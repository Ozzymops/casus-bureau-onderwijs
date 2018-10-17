using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BureauOnderwijs.Views
{
    public partial class UserSettings : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void ButtonSaveVoornaam_Click(object sender, EventArgs e)
        {
            //hier wordt de sessieId opgehaald om te controleren welke persoonsgegevens aangepast moeten kunnen worden.
            string Ingelogd = Session["UserId"].ToString();

            //als er geen voornaam is in gevuld geef de foutmelding 'geen voornaam gevonden.'. 
            if (string.IsNullOrEmpty(TextBoxVoornaam.Text))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Geen nieuwe voornaam gevonden.');", true);
            }

            //anders stuur de voornaam en sessie ID door naar CC.User_UpdateUserSettings
            else
            {
                Models.CC.User_UpdateUserSettings u = new Models.CC.User_UpdateUserSettings();
                string NewVoornaam = u.UpdateVoornaamCC(TextBoxVoornaam.Text, Ingelogd);

                //als de return waarde van succesvol updaten gelijk is aan de string waarde "0" geef foutmelding 'niet goed gegaan.'. 
                if(NewVoornaam == "0")
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Niet goed gegaan.');", true);
                }
                //als de return waarde van succesvol updaten gelijk is aan de string waarde "1" geef melding 'Succes! Voornaam is geupdatet.'.
                else if (NewVoornaam == "1")
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Succes! Voornaam is geupdatet.');", true);
                }
                //In andere gevallen geef de foutmelding 'Onbekende Fout'.
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Onbekende Fout');", true);
                }
                
            }
        }

        protected void ButtonSaveAchternaam_Click(object sender, EventArgs e)
        {
            //hier wordt de sessieId opgehaald om te controleren welke persoonsgegevens aangepast moeten kunnen worden.
            string Ingelogd = Session["UserId"].ToString();

            //als er geen achternaam is in gevuld geef de foutmelding 'geen achternaam gevonden.'. 
            if (string.IsNullOrEmpty(TextBoxAchternaam.Text))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Geen nieuwe achternaam gevonden.');", true);
            }

            //anders stuur de achternaam en sessie ID door naar CC.User_UpdateUserSettings
            else
            {
                Models.CC.User_UpdateUserSettings u = new Models.CC.User_UpdateUserSettings();
                string NewAchternaam = u.UpdateAchternaamCC(TextBoxAchternaam.Text, Ingelogd);

                //als de return waarde van succesvol updaten gelijk is aan de string waarde "0" geef foutmelding 'niet goed gegaan.'. 
                if (NewAchternaam == "0")
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Niet goed gegaan.');", true);
                }
                //als de return waarde van succesvol updaten gelijk is aan de string waarde "1" geef melding 'Succes! Achternaam is geupdatet.'.
                else if (NewAchternaam == "1")
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Succes! Achternaam is geupdatet.');", true);
                }
                //In andere gevallen geef de foutmelding 'Onbekende Fout'.
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Onbekende Fout');", true);
                }

            }
        }

        protected void ButtonSaveEmail_Click(object sender, EventArgs e)
        {
            //hier wordt de sessieId opgehaald om te controleren welke persoonsgegevens aangepast moeten kunnen worden.
            string Ingelogd = Session["UserId"].ToString();

            //als er geen achternaam is in gevuld geef de foutmelding 'geen achternaam gevonden.'. 
            if (string.IsNullOrEmpty(TextBoxEmail.Text))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Geen nieuw emailadres gevonden.');", true);
            }

            //anders stuur het emailadres en sessie ID door naar CC.User_UpdateUserSettings
            else
            {
                Models.CC.User_UpdateUserSettings u = new Models.CC.User_UpdateUserSettings();
                string NewEmail = u.UpdateEmailCC(TextBoxEmail.Text, Ingelogd);

                //als de return waarde van succesvol updaten gelijk is aan de string waarde "0" geef foutmelding 'niet goed gegaan.'. 
                if (NewEmail == "0")
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Niet goed gegaan.');", true);
                }
                //als de return waarde van succesvol updaten gelijk is aan de string waarde "1" geef melding 'Succes! Achternaam is geupdatet.'.
                else if (NewEmail == "1")
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Succes! Email is geupdatet.');", true);
                }
                //In andere gevallen geef de foutmelding 'Onbekende Fout'.
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Onbekende Fout');", true);
                }
            }
        }

        protected void ButtonSavePassword_Click(object sender, EventArgs e)
        {
            //hier wordt de sessieId opgehaald om te controleren welke persoonsgegevens aangepast moeten kunnen worden.
            string Ingelogd = Session["UserId"].ToString();

            if (string.IsNullOrWhiteSpace(TextBoxNewPassword.Text) ||
                string.IsNullOrWhiteSpace(TextBoxNewPassword2.Text) ||
                    string.IsNullOrWhiteSpace(TextBoxCurrentPassword.Text))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Error1 Niet alle velden zijn ingevuld');", true);
            }
            else
            {
                if (TextBoxNewPassword.Text != TextBoxNewPassword2.Text)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Error2 Nieuwe wachtwoorden komen niet overeen');", true);
                }
                else
                {
                    try
                    {
                        string conStringPw = "Data Source = localhost; Initial Catalog = Bureauonderwijsdb; Integrated Security = True";
                        string sqlQueryPwCheck = "SELECT COUNT (Password) FROM UserAccount WHERE UserId = '" + Ingelogd + "' AND Password = '" + TextBoxCurrentPassword.Text + "'";
                        string sqlQueryPw = "UPDATE UserAccount SET Password = '" + TextBoxNewPassword.Text + "' WHERE UserId = '" + Ingelogd + "'";
                        int checkpass;

                        SqlConnection conPwCheck = new SqlConnection(conStringPw);
                        SqlCommand cmdPwCheck = new SqlCommand(sqlQueryPwCheck, conPwCheck);

                        conPwCheck.Open();
                        checkpass = cmdPwCheck.ExecuteNonQuery();
                        conPwCheck.Close();
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('"+ checkpass +"');", true);

                    }
                    catch(Exception ex)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('asfglglegnlk catch');", true);
                    }

                    //Models.CC.User_UpdateUserSettings u = new Models.CC.User_UpdateUserSettings();
                    //string NewPassword = u.UpdatePasswordCC(TextBoxNewPassword.Text, TextBoxCurrentPassword.Text, Ingelogd);

                    //if(NewPassword == "1")
                    //{
                    //    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Niet goed gegaan.');", true);
                    //}
                    //else if(NewPassword == "0")
                    //{
                    //    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Succes! Password is geupdatet.');", true);
                    //}
                    //else
                    //{
                    //    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Onbekende Fout');", true);
                    //}
                }
            }
        }
    }
}