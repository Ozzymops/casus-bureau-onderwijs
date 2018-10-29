using BureauOnderwijs.Views;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using BureauOnderwijs.Models.CC;
using System.Linq;
using System.Web;

namespace BureauOnderwijs.Models.BU
{
    public class Examiner : Teacher // inherit from Teacher.cs
    {
        public DataTable ReadModules(string ingelogd)
        {
            string connectionString = "Data Source = localhost; Initial Catalog = Bureauonderwijsdatabase; Integrated Security = True";
            string sqlquery = "SELECT[Name], [ModuleCode], [Period], [Year], [Faculty], [Profile], [Credits], [Examinor], [Description], [GeneralModule], [LectureHours], [PracticalHours], [ModuleId] FROM[Module]";

            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand(sqlquery, con);

                con.Open();
                DataTable datatable = new DataTable();
                SqlDataReader datareader = cmd.ExecuteReader();
                datatable.Load(datareader);
                con.Close();
                return datatable;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public string AddNewModule(string Name, int ModuleCode,int Period, int Year, string Faculty, string Profile, int Credits, bool GeneralModule ,string Examinor, string Description, int LectureHours, int PracticalHours,  string ingelogd)
        {
            string connectionString = "Data Source = localhost; Initial Catalog = Bureauonderwijsdatabase; Integrated Security = True";
            string sqlquery = "INSERT INTO Module(Name, ModuleCode, Period, Year, Faculty, Profile, Credits, GeneralModule, Examinor, Description, LectureHours, PracticalHours) " +
                "VALUES('"+ Name + "','" + ModuleCode + "','" + Period + "','" + Year + "','" + Faculty + "','" + Profile + "','" + Credits + "','" + GeneralModule + "', '" + Examinor + "','" + Description + "','" + LectureHours + "','" + PracticalHours + "')";
            
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


        public string UpdateModule(string Name, int ModuleCode, int Period, int Year, string Faculty, string Profile, int Credits, bool GeneralModule, string Examinor, string Description, int LectureHours, int PracticalHours, string ingelogd, int ModuleId)
        {
            string connectionString = "Data Source = localhost; Initial Catalog = Bureauonderwijsdatabase; Integrated Security = True";
            string sqlquerySelect = "SELECT[Name], [ModuleCode], [Period], [Year], [Faculty], [Profile], [Credits], [Examinor], [Description], [GeneralModule], [LectureHours], [PracticalHours], [ModuleId] FROM[Module]";
            string sqlqueryUpdate = "UPDATE Module SET Name = '"+ Name + "', ModuleCode = '" + ModuleCode + "', Period = '" + Period + "', Year'" + Year + "', Faculty '" + Faculty + "', Profile '" + Profile + "', Credits'" + Credits + "', GeneralModule '" + GeneralModule + "', Examinor'" + Examinor + "', Description'" + Description + "', LectureHours'" + LectureHours + "', PracticalHours '" + PracticalHours + "' WHERE ModuleId = '"+ ModuleId + "' "; 
                
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand(sqlquerySelect, con);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                return "1";
            }
            catch (Exception)
            {
                return "2";
            }

        }

        public DataTable DeleteModule(int ModuleId, string ingelogd)
        {
            string connectionString = "Data Source = localhost; Initial Catalog = Bureauonderwijsdatabase; Integrated Security = True";
            string sqlquery = "DELETE FROM Module WHERE ModuleId = ('"+ ModuleId +"')";

            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand(sqlquery, con);

                con.Open();
                DataTable datatable = new DataTable();
                SqlDataReader datareader = cmd.ExecuteReader();
                datatable.Load(datareader);
                con.Close();
                return datatable;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}