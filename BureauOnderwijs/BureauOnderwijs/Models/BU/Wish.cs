using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BureauOnderwijs.Models.BU
{
    public class Wish
    {
        private string period;
        private int week;
        private string day;
        private DateTime startTime;
        private DateTime endTime;

        public int CreateWish(string period, int week, string day, string startTime, string endTime, int ingelogd)
        {
            string conString = "Data Source = localhost; Initial Catalog = Bureauonderwijsdatabase; Integrated Security = True";
            string sqlQuery = "INSERT INTO Wish (Period, Week, Day, StartTime, EndTime, UserId) VALUES ('"+ period +"', '"+ week +"', '"+ day +"', '"+ startTime +"', '"+ endTime +"', '"+ ingelogd +"')";

            try
            {
                SqlConnection con = new SqlConnection(conString);
                SqlCommand cmd = new SqlCommand(sqlQuery, con);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return 0; 
            }
            catch (Exception)
            {
                return 1;
            }
        }

        public void UpdateWish()
        {

        }

        public void ExportWishlist()
        {

        }

        public DataTable GetUserWishes(string ingelogd)
        {
            string conString = "Data Source = localhost; Initial Catalog = Bureauonderwijsdatabase; Integrated Security = True";
            string sqlQuery = "SELECT WishId, Day, Week, Period, StartTime, EndTime FROM Wish Where UserId = '" + ingelogd + "'";

            try
            {
                SqlConnection con = new SqlConnection(conString);
                SqlCommand cmd = new SqlCommand(sqlQuery, con);

                con.Open();
                DataTable dt = new DataTable();
                SqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr);
                con.Close();
                return dt; 
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}