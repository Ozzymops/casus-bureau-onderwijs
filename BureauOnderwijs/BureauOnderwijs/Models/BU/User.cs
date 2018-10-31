using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace BureauOnderwijs.Models.BU
{
    public class User
    {
        public int userId;
        public string username;
        private string password;
        public string emailAdress;
        public string firstname;
        public string lastname;
        private int twoFactorCode;
        private int recoveryCode;
        private int role;

        public int UserID
        {
            get { return this.userId; }
            set { this.userId = value; }
        }

        public string UserName
        {
            get { return this.username; }
            set { this.username = value; }
        }

        public int[] LogIn(string username, string password)
        {
            // localhost/MSSQLSERVER indien het niet werkt (Justin)
            // sayy wuuut? (Redmar)
            // hoi, ik ben ook hier. redmar naar Redmar veranderd.. (Gijs)

            int[] result = { 0, 0, 0 };
            string conString = "Data Source = localhost; Initial Catalog = Bureauonderwijsdatabase; Integrated Security = True";
            string sqlQuery = "SELECT Role, UserId FROM UserAccount WHERE Username = '" + username + "' and Password = '" + password + "'";
            string sqlQueryGetEmailAdress = "SELECT Emailadress FROM UserAccount WHERE Username = '" + username + "' and Password = '" + password + "'";

            try
            {
                SqlConnection con = new SqlConnection(conString);
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                SqlCommand cmdEmail = new SqlCommand(sqlQueryGetEmailAdress, con);
                
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        result[0] = reader.GetInt32(0);
                        result[1] = reader.GetInt32(1);
                    }
                }
                con.Close();

                if (result.First() > 0)
                {
                    /// login succesvol, gaat een 2FA code genereren met RandomNumerGenerator van 4 cijfers
                    /// en stuurt vervolgens deze 2FA code naar het email adres van de persoon die wilt inloggen.

                    RandomNumberGenerator r = new RandomNumberGenerator();
                    result[2] = r.GenerateNumber(1000, 9999);

                    try
                    {
                        //send2facodeLogin(result[2], username, password);
                    }
                    catch
                    {
                        return new int[] { -4, 0, 0 };
                    }

                    return new int[] { result[0], result[1], result[2] };
                }
                else if (result.First() == 0)
                {
                    return new int[] { -1, 0, 0 };
                }
            }
            catch
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
            return db.UserIdToUsername(query);
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
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
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
        public void send2facodeLogin(int randomnumer2facode, string username, string password)
        {
            /// Onderstaande stuur de gebruiker een email met daarin de authenticatiecode
            /// De code werkt maar is uitgecomment zodat er niet iedere keer een email verstuurd wordt.

            string conString = "Data Source = localhost; Initial Catalog = Bureauonderwijsdatabase; Integrated Security = True";
            string sqlQueryGetEmailAdress = "SELECT Emailadress FROM UserAccount WHERE Username = '" + username + "' and Password = '" + password + "'";
            string credentialGebruikersnaam = "CasusBureauonderwijs@gmail.com";
            string credentialWachtwoord = "glasGG!7481";
            string smtp = "smtp.gmail.com";
            string onderwerpMail = "Uw 2FA code om in te loggen";
            string inhoudMail = "Uw authenticatie code is: " + randomnumer2facode + ".";

            SqlConnection con = new SqlConnection(conString);
            SqlCommand cmdEmail = new SqlCommand(sqlQueryGetEmailAdress, con);

            con.Open();
            string mailTo = cmdEmail.ExecuteScalar().ToString();
            con.Close();

            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(credentialGebruikersnaam, "2FA code bureauonderwijs");
            mail.To.Add(mailTo);
            mail.Subject = onderwerpMail;
            mail.Body = inhoudMail;

            SmtpClient smtpServer = new SmtpClient(smtp, 587);
            smtpServer.Credentials = new NetworkCredential(credentialGebruikersnaam, credentialWachtwoord);
            smtpServer.EnableSsl = true;
            smtpServer.Send(mail);
        }
    }
}
