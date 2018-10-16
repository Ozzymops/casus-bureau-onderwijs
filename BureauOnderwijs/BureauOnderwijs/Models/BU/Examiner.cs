using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BureauOnderwijs.Models.BU
{
    public class Examiner : Teacher // inherit from Teacher.cs
    {
        private void ReadModules()
        {

        }

 public string AddNewModule(string Name, int ModuleCode,int Period, int Year, string Faculty, string Profile, int Credits, string Examinor, string Description, int LectureHours, int PracticalHours,  string ingelogd)
        {
            string connectionString = "Data Source = localhost; Initial Catalog = Bureauonderwijsdatabase; Integrated Security = True";
            string sqlquery = "INSERT INTO ModuleTest2(Name, ModuleCode, Period, Year, Faculty, Profile, Credits, Examinor, Description, LectureHours, PracticalHours) " +
                "VALUES('"+ Name + "','" + ModuleCode + "','" + Period + "','" + Year + "','" + Faculty + "','" + Profile + "','" + Credits + "','" + Examinor + "','" + Description + "','" + LectureHours + "','" + PracticalHours + "')";
            
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand(sqlquery, con);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                return  "0";
            }

            catch(Exception)
            {
                return  "1";
            }
        }


        private void UpdateModule()
        {

        }

        private void DeleteModule()
        {

        }
    }
}