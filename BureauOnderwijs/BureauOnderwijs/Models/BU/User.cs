using System;
using System.Collections.Generic;
using System.Data;
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

                int[] result = { 0, 0, 0 };

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        result[0] = reader.GetInt32(0);
                        result[1] = reader.GetInt32(1);
                    }
                }

                if (result.First() > 0)
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
                    return new int[] { -1, 0, 0 };
                }
                con.Dispose();
            }
            catch (Exception)
            {
                return new int[] { -2, 0, 0 };
            }
            return new int[] { -3, 0, 0 };
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

        public string GetUsername(int userId)
        {
            string query = "SELECT Username FROM UserAccount WHERE UserId = " + userId;
            Models.Database db = new Models.Database();
            db.Connect();
            return db.ReturnUsernameFromUserId(query);
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

        public string LoadVn(string ingelogd)
        {
            string conStringGetVn = "Data Source = localhost; Initial Catalog = Bureauonderwijsdatabase; Integrated Security = True";
            string sqlQueryGetVn = "SELECT Firstname FROM UserAccount WHERE UserId = '" + ingelogd + "' ";

            try
            {
                SqlConnection conGetVn = new SqlConnection(conStringGetVn);
                SqlCommand cmdGetVn = new SqlCommand(sqlQueryGetVn, conGetVn);
                conGetVn.Open();
                string displayvoornaam = cmdGetVn.ExecuteScalar().ToString();

                conGetVn.Close();

                return displayvoornaam;
            }
            catch
            {
                string ditisniets = "eentext";
                return ditisniets;
            }
        }

        public string LoadAn(string ingelogd)
        {
            string conStringGetAn = "Data Source = localhost; Initial Catalog = Bureauonderwijsdatabase; Integrated Security = True";
            string sqlQueryGetAn = "SELECT Lastname FROM UserAccount WHERE UserId = '" + ingelogd + "' ";

            try
            {
                SqlConnection conGetAn = new SqlConnection(conStringGetAn);
                SqlCommand cmdGetAn = new SqlCommand(sqlQueryGetAn, conGetAn);
                conGetAn.Open();
                string displayachternaam = cmdGetAn.ExecuteScalar().ToString();

                conGetAn.Close();

                return displayachternaam;
            }
            catch
            {
                string ditisniets = "eentext";
                return ditisniets;
            }
        }

        public string LoadEm(string ingelogd)
        {
            string conStringGetEm = "Data Source = localhost; Initial Catalog = Bureauonderwijsdatabase; Integrated Security = True";
            string sqlQueryGetEm = "SELECT Emailadress FROM UserAccount WHERE UserId = '" + ingelogd + "' ";

            try
            {
                SqlConnection conGetEm = new SqlConnection(conStringGetEm);
                SqlCommand cmdGetEm = new SqlCommand(sqlQueryGetEm, conGetEm);
                conGetEm.Open();
                string displayemail = cmdGetEm.ExecuteScalar().ToString();

                conGetEm.Close();

                return displayemail;
            }
            catch
            {
                string ditisniets = "eentext";
                return ditisniets;
            }
        }

        public string UpdateVoornaam(string voornaam, string ingelogd)
        {
            //legt de locatie van de database vast en de query welke er naar toe verstuurd dient te worden met deze methode
            string conStringVn = "Data Source = localhost; Initial Catalog = Bureauonderwijsdatabase; Integrated Security = True";
            string sqlQueryVn = "UPDATE UserAccount SET Firstname = '" + voornaam + "' WHERE UserId = '" + ingelogd + "'";
            //poogt de query uit te voeren, als dit succesvol verloopt wordt de return waarde succes op string value "1" gezet.
            try
            {
                SqlConnection conVn = new SqlConnection(conStringVn);
                SqlCommand cmdVn = new SqlCommand(sqlQueryVn, conVn);
                conVn.Open();
                cmdVn.ExecuteNonQuery();
                conVn.Close();
                return "1";
            }
            //Bij een onsuccesvolle poging wordt de return waarde succes op string value "0" gezet.
            catch (Exception)
            {
                return "0";
            }
        }

        public string UpdateAchternaam(string achternaam, string ingelogd)
        {
            //legt de locatie van de database vast en de query welke er naar toe verstuurd dient te worden met deze methode
            string conStringAn = "Data Source = localhost; Initial Catalog = Bureauonderwijsdatabase; Integrated Security = True";
            string sqlQueryAn = "UPDATE UserAccount SET Lastname = '" + achternaam + "' WHERE UserId = '" + ingelogd + "'";
            //poogt de query uit te voeren, als dit succesvol verloopt wordt de return waarde succes op string value "1" gezet.
            try
            {
                SqlConnection conAn = new SqlConnection(conStringAn);
                SqlCommand cmdAn = new SqlCommand(sqlQueryAn, conAn);
                conAn.Open();
                cmdAn.ExecuteNonQuery();
                conAn.Close();
                return "1";
            }
            //Bij een onsuccesvolle poging wordt de return waarde succes op string value "0" gezet.
            catch (Exception)
            {
                return "0";
            }
        }

        public string UpdateEmail(string email, string ingelogd)
        {
            //legt de locatie van de database vast en de query welke er naar toe verstuurd dient te worden met deze methode
            string conStringEm = "Data Source = localhost; Initial Catalog = Bureauonderwijsdatabase; Integrated Security = True";
            string sqlQueryEm = "UPDATE UserAccount SET Emailadress = '" + email + "' WHERE UserId = '" + ingelogd + "'";

            //poogt de query uit te voeren, als dit succesvol verloopt wordt de return waarde succes op string value "1" gezet.
            try
            {
                SqlConnection conEm = new SqlConnection(conStringEm);
                SqlCommand cmdEm = new SqlCommand(sqlQueryEm, conEm);

                conEm.Open();
                cmdEm.ExecuteNonQuery();
                conEm.Close();

                return "1";

            }
            //Bij een onsuccesvolle poging wordt de return waarde succes op string value "0" gezet.
            catch (Exception)
            {
                return "0";
            }
        }

        public string UpdatePassword(string newpassword, string currentpassword, string ingelogd)
        {
            //legt de locatie van de database vast en de query welke er naar toe verstuurd dient te worden met deze methode
            string conStringPw = "Data Source = localhost; Initial Catalog = Bureauonderwijsdatabase; Integrated Security = True";
            string sqlQueryPwCheck = "SELECT COUNT (*) FROM UserAccount WHERE UserId = '" + ingelogd + "' AND Password = '" + currentpassword + "'";
            string sqlQueryPw = "UPDATE UserAccount SET Password = '" + newpassword + "' WHERE UserId = '" + ingelogd + "'";
            int checkpass;

            SqlConnection conPwCheck = new SqlConnection(conStringPw);
            SqlCommand cmdPwCheck = new SqlCommand(sqlQueryPwCheck, conPwCheck);

            conPwCheck.Open();
            checkpass = (Int32)cmdPwCheck.ExecuteScalar();
            conPwCheck.Close();


            //poogt de query uit te voeren, als dit succesvol verloopt wordt de return waarde succes op string value "1" gezet.
            if (checkpass == 1)
            {
                try
                {
                    SqlConnection conPw = new SqlConnection(conStringPw);
                    SqlCommand cmdPw = new SqlCommand(sqlQueryPw, conPw);

                    conPw.Open();
                    cmdPw.ExecuteNonQuery();
                    conPw.Close();

                    return "0";

                }
                //Bij een onsuccesvolle poging wordt de return waarde succes op string value "0" gezet.
                catch (Exception)
                {
                    return "1";
                }
            }
            else
            {
                return "2";
            }
        }
    }
}
