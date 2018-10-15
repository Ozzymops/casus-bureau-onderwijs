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
        private int period;
        private int week;
        private string day;
        private DateTime startTime;
        private DateTime endTime;

        public void CreateWish()
        {

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