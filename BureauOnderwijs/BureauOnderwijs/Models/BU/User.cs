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
            // localhost/MSSQLSERVER indien het niet werkt (Justin)
            string conString = "Data Source = localhost; Initial Catalog = Bureauonderwijsdatabase; Integrated Security = True";
            string sqlQuery = "SELECT Role, UserId FROM UserAccount WHERE Username = '" + username + "' and Password = '" + password + "'";

            try
            {
                SqlConnection con = new SqlConnection(conString);
                SqlCommand cmd = new SqlCommand(sqlQuery, con);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                int[] result = { 0, 0, 0};

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        result[0] = reader.GetInt32(0);
                        result[1] = reader.GetInt32(1);
                    }
                }

                if (result.First() > 0 && result.First() <5)
                {
                    /// login succesvol

                    RandomNumberGenerator r = new RandomNumberGenerator();
                    result[2] = r.GenerateNumber(1000, 9999);
                    return new int[] { result[0], result[1], result[2] }; 
                }
                else if (result.First() == 0) 
                {
                    /// foutmelding laten zien dat de combinatie username en password niet voorkomt
                    //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Ongelidge username en/of wachtwoord');", true);
                    return new int[] { 10, 0, 0 };
                }
                con.Dispose();
            }
            catch (Exception)
            {
                /// er is iets mis gegaan met het inloggen, afhankelijk van de foutmelding die weergegeven wordt
                return new int[] { 20, 0, 0 };
            }
            return new int[] { 30, 0, 0 };
        }

        public void LogOut()
        {

        }

        public bool CheckIfUserExists(string username)
        {
            string query = "SELECT Username FROM UserAccount WHERE Username = '" + username + "'";
            Models.Database db = new Models.Database();
            db.Connect();
            if (db.ReturnBoolFromSingleResult(query))
            {
                return true;
            }
            return false;
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

        public string UpdateVoornaam(string voornaam, string ingelogd)
        {
            //legt de locatie van de database vast en de query welke er naar toe verstuurd dient te worden met deze methode
            string conStringVn = "Data Source = localhost; Initial Catalog = Bureauonderwijsdatabase; Integrated Security = True";
            string sqlQueryVn = "UPDATE UserAccount SET Firstname = '" + voornaam + "' WHERE UserId = '" + ingelogd + "'";
            string succes;

            //poogt de query uit te voeren, als dit succesvol verloopt wordt de return waarde succes op string value "1" gezet.
            try
            {
                SqlConnection conVn = new SqlConnection(conStringVn);
                SqlCommand cmdVn = new SqlCommand(sqlQueryVn, conVn);

                conVn.Open();
                cmdVn.ExecuteNonQuery();
                conVn.Close();
                
                return succes = "1";
                
            }
            //Bij een onsuccesvolle poging wordt de return waarde succes op string value "0" gezet.
            catch(Exception)
            {
                return succes = "0";
            }
        
            
        }

        public string UpdateAchternaam(string achternaam, string ingelogd)
        {
            //legt de locatie van de database vast en de query welke er naar toe verstuurd dient te worden met deze methode
            string conStringAn = "Data Source = localhost; Initial Catalog = Bureauonderwijsdatabase; Integrated Security = True";
            string sqlQueryAn = "UPDATE UserAccount SET Lastname = '" + achternaam + "' WHERE UserId = '" + ingelogd + "'";
            string succes;

            //poogt de query uit te voeren, als dit succesvol verloopt wordt de return waarde succes op string value "1" gezet.
            try
            {
                SqlConnection conAn = new SqlConnection(conStringAn);
                SqlCommand cmdAn = new SqlCommand(sqlQueryAn, conAn);

                conAn.Open();
                cmdAn.ExecuteNonQuery();
                conAn.Close();

                return succes = "1";

            }
            //Bij een onsuccesvolle poging wordt de return waarde succes op string value "0" gezet.
            catch (Exception)
            {
                return succes = "0";
            }


        }
    }
}