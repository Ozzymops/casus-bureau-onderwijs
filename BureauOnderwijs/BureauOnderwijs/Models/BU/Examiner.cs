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
        public Examiner()
        {
            // Leeg: anders verschijnen er enge rode lijntjes.
        }

        public Examiner(int id, string username, string email, string firstname, string lastname) : base()
        {
            this.userId = id;
            this.username = username;
            this.emailAdress = email;
            this.firstname = firstname;
            this.lastname = lastname;
        }

        public DataTable ReadModules(string ingelogd)
        {
            string connectionString = "Data Source = localhost; Initial Catalog = Bureauonderwijsdatabase; Integrated Security = True";
            string sqlquery = "SELECT * FROM Module WHERE Deleted = 0";

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

        public DataTable ReadModulesLinkedToTeacher(string ingelogd)
        {
            string connectionString = "Data Source = localhost; Initial Catalog = Bureauonderwijsdatabase; Integrated Security = True";
            string sqlquery = "SELECT m.*, u.UserId FROM Module m, UserAccount u, ModuleUser mu WHERE m.ModuleId = mu.ModuleId AND u.UserId = mu.UserId AND Deleted = 0";

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

        public string AddNewModule(string Name, string Code,int Period, int Year, string Faculty, string Profile, int Credits, bool GeneralModule ,int ExaminerId, string Description, int LectureHours, int PracticalHours, string ingelogd)
        {
            string connectionString = "Data Source = localhost; Initial Catalog = Bureauonderwijsdatabase; Integrated Security = True";
            string sqlquery =   "INSERT INTO Module(Name, Code, Period, Year, Faculty, Profile, Credits, GeneralModule, ExaminerId, Description, LectureHours, PracticalHours, Deleted)" +
                                "VALUES('" + Name + "', '" + Code + "','" + Period + "','" + Year + "','" + Faculty + "','" + Profile + "','" + Credits + "','" + GeneralModule + "', '" + ExaminerId + "', '" + Description + "','" + LectureHours + "','" + PracticalHours + "', 0);";
            string sqlquery2 = "SELECT ModuleId FROM Module WHERE Name = '" + Name +"' AND Code = '" + Code +"'";
            string sqlquery3 = "INSERT INTO ModuleUser(ModuleId, UserId) VALUES(ModuleId, '" + ExaminerId + "')";
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand(sqlquery, con);
                SqlCommand cmd2 = new SqlCommand(sqlquery2, con);
                SqlCommand cmd3 = new SqlCommand(sqlquery3, con);

                con.Open();
                cmd.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
                cmd3.ExecuteNonQuery();
                con.Close();

                return "0";
            }

            catch (Exception)
            {
                return "1";
            }
        }

        public string UpdateModule(string Name, int ModuleCode, int Period, int Year, string Faculty, string Profile, int Credits, bool GeneralModule, int ExaminerId, string Description, int LectureHours, int PracticalHours,string ingelogd, int ModuleId)
        {
            string connectionString = "Data Source = localhost; Initial Catalog = Bureauonderwijsdatabase; Integrated Security = True";
            string sqlquerySelect = "SELECT[Name], [ModuleCode], [Period], [Year], [Faculty], [Profile], [Credits], [Examinor], [Description], [GeneralModule], [LectureHours], [PracticalHours], [Docent], [Docent1] [ModuleId] FROM[Module]";
            string sqlqueryUpdate = "UPDATE Module SET Name = '"+ Name + "', ModuleCode = '" + ModuleCode + "', Period = '" + Period + "', Year'" + Year + "', Faculty '" + Faculty + "', Profile '" + Profile + "', Credits'" + Credits + "', GeneralModule '" + GeneralModule + "', ExaminerId'" + ExaminerId + "', Description'" + Description + "', LectureHours'" + LectureHours + "', PracticalHours '" + PracticalHours + "' WHERE ModuleId = '" + ModuleId + "'"; 
                
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