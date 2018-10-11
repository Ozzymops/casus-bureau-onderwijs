using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BureauOnderwijs.Models.BU
{
    public class User
    {
        private string username;
        private string password;
        private string emailAdress;
        private string firstname;
        private string lastname;
        private int twoFactorCode;
        private int recoveryCode;
        private int role;

        public int[] LogIn(string username, string password)
        {

            string conString = "Data Source = localhost; Initial Catalog = Bureauonderwijsdatabase; Integrated Security = True";
            string sqlQuery = "SELECT Role FROM UserAccount WHERE Username = '" + username + "' and Password = '" + password + "'";

            try
            {
                SqlConnection con = new SqlConnection(conString);
                SqlCommand cmd = new SqlCommand(sqlQuery, con);

                con.Open();
                int result = Convert.ToInt16(cmd.ExecuteScalar());
                if (result == 1 || result == 2 || result == 3 || result == 4)
                {
                    /// login succesvol
                    return new int[] { result, 0}; 
                }
                else if (result == 0) 
                {
                    /// foutmelding laten zien dat de combinatie username en password niet voorkomt
                    //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Ongelidge username en/of wachtwoord');", true);
                    return new int[] { 10, 0 };
                }
                con.Dispose();
            }
            catch (Exception)
            {
                /// er is iets mis gegaan met het inloggen, afhankelijk van de foutmelding die weergegeven wordt
                return new int[] { 20, 0 };
            }
            return new int[] { 30, 0 };
        }

        public void LogOut()
        {

        }

        public void ViewSchedule()
        {

        }

        public void ResetPassword()
        {

        }

        public void UpdateData()
        {

        }
    }
}