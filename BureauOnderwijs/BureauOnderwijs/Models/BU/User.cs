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

        public void LogIn(string username, string password)
        {
            string conString = "Data Source = localhost; Initial Catalog = Bureauonderwijsdatabase; Integrated Security = True";
            string sqlQuery = "SELECT * FROM UserAccount WHERE Username = '" + username + "'";

            try
            {
                SqlConnection con = new SqlConnection(conString);
                SqlCommand cmd = new SqlCommand(sqlQuery);

                cmd.Parameters.AddWithValue("", username);

                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();

            }
            catch(Exception ex)
            {
                //Laat foutmelding zien
            }
            finally
            {
                
            }

            RandomNumberGenerator r = new RandomNumberGenerator();
            r.GenerateNumber(1000, 9999);
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