using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BureauOnderwijs.Models.BU
{
    public class Admin : User   // inherit from User.cs
    {
        public int CheckAdmin(int UserID)
        {
            string conString = "Data Source = localhost; Initial Catalog = Bureauonderwijsdatabase; Integrated Security = True";
            string sqlQuery = ("SELECT Role FROM UserAccount WHERE UserId = " +UserID+ "");
            
            try
            {
                SqlConnection con = new SqlConnection(conString);
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                

                con.Open();
                int UserRole = (int)cmd.ExecuteScalar();
                con.Close();

                if (UserRole == 4)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            catch (Exception)
            {
                return 2;
            }
        }

        public int CreateUser(string newUsername, string newPassword, string newEmail, string newFirstName, string newLastName, int newRole)
        {
            string[] inputs = { newUsername, newPassword, newEmail, newFirstName, newLastName };

            string conString = "Data Source = localhost; Initial Catalog = Bureauonderwijsdatabase; Integrated Security = True";
            string sqlQuery = ("INSERT INTO UserAccount(Username, Password, Emailadress, Firstname, Lastname, Role) VALUES(@InputUsername, @InputPassword, @InputEmail, @InputFirstName, @InputLastName, @InputRole)");

            try
            {
                if (inputs.Any(x => string.IsNullOrWhiteSpace(x)))
                {
                    return 1;
                }
                else
                {
                    SqlConnection con = new SqlConnection(conString);
                    SqlCommand cmd = new SqlCommand(sqlQuery, con);

                    cmd.Parameters.Add("InputUsername", SqlDbType.VarChar).Value = newUsername;
                    cmd.Parameters.Add("InputPassword", SqlDbType.VarChar).Value = newPassword;
                    cmd.Parameters.Add("InputEmail", SqlDbType.VarChar).Value = newEmail;
                    cmd.Parameters.Add("InputFirstName", SqlDbType.VarChar).Value = newFirstName;
                    cmd.Parameters.Add("InputLastName", SqlDbType.VarChar).Value = newLastName;
                    cmd.Parameters.Add("InputRole", SqlDbType.Int).Value = newRole;

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    return 0;
                }
            }
            catch (Exception)
            {
                return 1;
            }
        }

        public DataTable SelDeleteUser(string delUserID)
        {
            string conString = "Data Source = localhost; Initial Catalog = Bureauonderwijsdatabase; Integrated Security = True";
            string sqlQuery = ("SELECT UserId, Username, Emailadress, Firstname, Lastname, Role FROM UserAccount WHERE UserId = "+delUserID+"");

            try
            {
                SqlConnection con = new SqlConnection(conString);
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                
                con.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter(sqlQuery, conString);
                DataTable dtblBU = new DataTable();
                sqlDa.Fill(dtblBU);
                con.Close();

                return dtblBU;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public int DeleteUser(string delUserID)
        {
            string conString = "Data Source = localhost; Initial Catalog = Bureauonderwijsdatabase; Integrated Security = True";
            string sqlQuery = ("DELETE FROM UserAccount WHERE UserId = "+delUserID+"");

            try
            {
                SqlConnection con = new SqlConnection(conString);
                SqlCommand cmd = new SqlCommand(sqlQuery, con);
                
                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                con.Close();
                
                if (rowsAffected > 0)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            catch (Exception)
            {
                return 1;
            }
        }

        public DataTable ReadUsers()
        {
            string conString = "Data Source = localhost; Initial Catalog = Bureauonderwijsdatabase; Integrated Security = True";
            string sqlQuery = ("SELECT UserID, Username, Password, Emailadress, Firstname, Lastname, Role FROM UserAccount;");

            try
            {
                SqlConnection con = new SqlConnection(conString);
                SqlCommand cmd = new SqlCommand(sqlQuery, con);

                con.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter(sqlQuery, conString);
                DataTable dtblBU = new DataTable();
                sqlDa.Fill(dtblBU);
                con.Close();

                return dtblBU;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}