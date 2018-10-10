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
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Gebruikersnaam en of wachtwoord niet ingevuld!');", true);
            }
            else
            {
                
                string conString = "Data Source = localhost; Initial Catalog = Bureauonderwijsdatabase; Integrated Security = True";
                string sqlQuery = "SELECT Password FROM UserAccount WHERE Username= @Username = '" + TextBoxUsernameLogin.Text + "'";

                try
                {
                    SqlConnection con = new SqlConnection(conString);
                    SqlCommand cmd = new SqlCommand(sqlQuery, con);

                    cmd.Parameters.AddWithValue("@Username", this.TextBoxUsernameLogin.Text);

                    con.Open();
                    var result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Geldige username');", true);
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Ongelidge username');", true);
                    }
                    con.Dispose();
                }
                catch (Exception ex)
                {
                    //Laat foutmelding zien
                }
                finally
                {
                    
                }
                //Models.CC.LogIn l = new Models.CC.LogIn();
                //l.LoginCC(TextBoxUsernameLogin.Text, TextBoxPasswordLogin.Text);
            }
        }
    }
}