using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BureauOnderwijs.Models
{
    public class Database
    {
        // Zie Wesley code

        protected SqlConnection conn;
        /// <summary>
        /// This method is used to setup the connection string which is used to connect to the database.
        /// Initialise this after log-in.
        /// </summary>
        /// <returns>connection string</returns>
        public SqlConnection Connect()
        {
            string connString = "Data Source = localhost; Initial Catalog = Bureauonderwijsdatabase; Integrated Security = True";
            conn = new SqlConnection(connString);
            return conn;
        }

        #region Get
        // get functies: lees uit een table
        // create things via queries and send them back to the requester.
        /// <summary>
        /// Return een boolean vanuit een enkel resultaat: zoek je op usernames? Return true wanneer er 1 username bestaat.
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public bool ReturnBoolFromSingleResult(string query)
        {
            bool returnValue = false;
            try
            {
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    if (reader.GetString(0) != null)
                    {
                        returnValue = true;
                    }
                }
                conn.Dispose();
            }
            catch (Exception)
            {
                return false;
            }
            return returnValue;
        }

        public string ReturnUsernameFromUserId(string query)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    return reader.GetString(0);
                }
                conn.Dispose();
            }
            catch (Exception)
            {
                return "error: connection error";
            }
            return "error: not found";
        }

        public List<string> GetUsernameListRole(string query)
        {
            List<string> userList = new List<string>();
            try
            {
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    userList.Add(reader.GetString(0));
                }
                conn.Dispose();
                return userList;
            }
            catch (Exception)
            {
                return null;
            }
            return null;
        }
        public List<int> GetDayListUserId(string query)
        {
            List<int> dayList = new List<int>();
            try
            {
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    dayList.Add(Convert.ToInt32(reader.GetString(0)));
                }
                conn.Dispose();
                return dayList;
            }
            catch (Exception)
            {
                return null;
            }
            return null;
        }
        #endregion

        #region Add
        // add functies: voeg toe aan een table
        #endregion

        #region Update
        // update functies: werk table bij
        public bool UpdatePassword(string query)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Dispose();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion

        #region Delete
        // delete functies: verwijder data uit een table
        // DROP NOOIT EEN TABLE! Hiermee verlies je ALLE data!
        #endregion
    }
}