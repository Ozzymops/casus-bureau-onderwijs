﻿using System;
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
        protected int userId;
        protected string username;
        protected string password;
        protected string emailAdress;
        protected string firstname;
        protected string lastname;
        protected int twoFactorCode;
        protected int recoveryCode;
        protected int role;

        public int UserID
        {
            get { return this.userId; }
            set { this.userId = value; }
        }

        public string UserName
        {
            get { return this.username; }
            //set { this.username = value; }
        }

        public int TwoFactorCode
        {
            get { return this.twoFactorCode; }
            //set { this.username = value; }
        }

        public int RoleId
        {
            get { return this.role; }
        }

        /// <summary>
        /// Maak een lege user, vooral als nog niet ingelogd is.
        /// </summary>
        public User()
        {
            
        }

        /// <summary>
        /// Maak een user aan, aan de hand van het UserId
        /// Na de inlogpagina deze methode gebruiken, op iedere webpagina moet het userobject weer gecreerd worden.
        /// </summary>
        /// <param name="userId"></param>
        public User(int userId)
        {
            string conString = "Data Source = localhost; Initial Catalog = Bureauonderwijsdatabase; Integrated Security = True";
            string sqlQuery = "SELECT UserId, Username, Role, Emailadress FROM UserAccount WHERE UserId = '" + userId + "'";

            SqlConnection con = new SqlConnection(conString);
            SqlCommand cmd = new SqlCommand(sqlQuery, con);

            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    //Alle gegevens opslaan in het User object 
                    //-> Nu alleen deze 5 gebruikt: UserId, Username, Password, Role, Emailadress
                    userId = reader.GetInt32(0);
                    username = reader.GetString(1);
                    role = reader.GetInt32(2);
                    emailAdress = reader.GetString(3);
                }
            }
            con.Close();
        }

        public string GetLoginError(int RoleUseridRandomNumber)
        {            
            if (RoleUseridRandomNumber == -1)
            {
               return "alert('Ongeldige gebruikersnaam en of wachtwoord!');";
            }
            else if (RoleUseridRandomNumber == -2)
            {
                return "alert('Problemen met de connectie van de database.');";
            }
            else if (RoleUseridRandomNumber == -3)
            {
                return "alert('Kom op kerel, je code klopt voor de klote niet ;)');";
            }
            else if (RoleUseridRandomNumber == -4)
            {
                return "alert('Problemen met de mailingdinghusus');";
            }
            return "alert('Neem a.u.b. contact op met je netwerkbeheerder.');";
        }

        public bool LogIn(string username, string password)
        {
            //int[] result = { 0, 0, 0 };
            string conString = "Data Source = localhost; Initial Catalog = Bureauonderwijsdatabase; Integrated Security = True";
            //string sqlQuery = "SELECT Role, UserId FROM UserAccount WHERE Username = '" + username + "' and Password = '" + password + "'";
            string sqlQuery = "SELECT UserId, Username, Password, Role, Emailadress FROM UserAccount WHERE Username = '" + username + "' and Password = '" + password + "'";
            //string sqlQueryGetEmailAdress = "SELECT Emailadress FROM UserAccount WHERE Username = '" + username + "' and Password = '" + password + "'";

            try
            {
                SqlConnection con = new SqlConnection(conString);
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                //SqlCommand cmdEmail = new SqlCommand(sqlQueryGetEmailAdress, con);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        //result[0] = reader.GetInt32(0);
                        //result[1] = reader.GetInt32(1);

                        //Alle gegevens opslaan in het User object 
                        //-> Nu alleen deze 5 gebruikt: UserId, Username, Password, Role, Emailadress
                        userId = reader.GetInt32(0);
                        username = reader.GetString(1);
                        password = reader.GetString(2);
                        role = reader.GetInt32(3);
                        emailAdress = reader.GetString(4);
                    }
                    con.Close();

                    /// login succesvol, gaat een 2FA code genereren met RandomNumerGenerator
                    /// en stuurt vervolgens deze 2FA code naar het email adres van de persoon die wilt inloggen.

                    RandomNumberGenerator r = new RandomNumberGenerator();
                    twoFactorCode = r.GenerateNumber(1000, 9999);

                    /// Uitvoeren van de mailingfunctie om de 2FA code te versturen. 
                    /// Deze functie is uitgecomment zodat dit tijdens het maken van het 
                    /// programma niet constant uitgevoerd wordt. 
                    /*
                    try
                    {
                        send2facodeLogin();
                    }
                    catch
                    {
                        throw new Exception("Problemen met de mailingdinghusus.")
                    }
                    */

                    return true;
                }
                else
                {
                    con.Close();
                    throw new Exception("Ongeldige gebruikersnaam en of wachtwoord.");
                }
            }
            catch (SqlException)
            {
                throw new Exception("Problemen met de connectie van de database.");
            }
            throw new Exception("Kom op kerel, je code klopt voor de klote niet ;)");
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

        public string UpdateVoornaam(string voornaam)
        {
            //legt de locatie van de database vast en de query welke er naar toe verstuurd dient te worden met deze methode
            string conStringVn = "Data Source = localhost; Initial Catalog = Bureauonderwijsdatabase; Integrated Security = True";
            string sqlQueryVn = "UPDATE UserAccount SET Firstname = '" + voornaam + "' WHERE UserId = '" + userId + "'";
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
        public void send2facodeLogin()
        {
            /// Onderstaande stuur de gebruiker een email met daarin de authenticatiecode
            /// De code werkt maar de aanroep is uitgecomment zodat er niet iedere keer een email verstuurd wordt.

            string conString = "Data Source = localhost; Initial Catalog = Bureauonderwijsdatabase; Integrated Security = True";
            string sqlQueryGetEmailAdress = "SELECT Emailadress FROM UserAccount WHERE Username = '" + username + "' and Password = '" + password + "'";
            string credentialGebruikersnaam = "CasusBureauonderwijs@gmail.com";
            string credentialWachtwoord = "glasGG!7481";
            string smtp = "smtp.gmail.com";
            string onderwerpMail = "Uw 2FA code om in te loggen";
            string inhoudMail = "Uw authenticatie code is: " + twoFactorCode + ".";

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
