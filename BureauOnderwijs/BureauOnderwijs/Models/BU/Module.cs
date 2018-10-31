using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BureauOnderwijs.Models.BU
{
    public class Module
    {
        public int moduleId;
        public string name;
        public string moduleCode;
        public int period;
        public int year;
        public string faculty;
        public string profile;
        public int credits;
        public Examiner examiner;
        public string description;
        public bool generalModule;
        public int lectureHours;   // hoorcollege
        public int practicalHours; // werkcollege

        public int ModuleID
        {
            get { return this.moduleId; }
            set { this.moduleId = value; }
        }

        public string ModuleCode
        {
            get { return this.moduleCode; }
            set { this.moduleCode = value; }
        }

        public Module(int moduleId, string name, string moduleCode, int period, int year, string faculty, string profile, int credits, Examiner examiner, string description, bool generalModule, int lectureHours, int practicalHours)
        {
            this.moduleId = moduleId;
            this.name = name;
            this.moduleCode = moduleCode;
            this.period = period;
            this.year = year;
            this.faculty = faculty;
            this.profile = profile;
            this.credits = credits;
            this.examiner = examiner;
            this.description = description;
            this.generalModule = generalModule;
            this.lectureHours = lectureHours;
            this.practicalHours = practicalHours;
        }

        public DataTable ReadModules(string ingelogd)
        {
            string connectionString = "Data Source = localhost; Initial Catalog = Bureauonderwijsdatabase; Integrated Security = True";
            string sqlquery = "SELECT [ModuleId], [Name], [Code], [Period], [Year], [Faculty], [Profile], [Credits], [ExaminerId], [Description], [GeneralModule], [LectureHours], [PracticalHours] FROM[Module] WHERE Deleted = 0";

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

        public string AddNewModule(string Name, string Code, int Period, int Year, string Faculty, string Profile, int Credits, bool GeneralModule, int ExaminerId, string Description, int LectureHours, int PracticalHours, string ingelogd)
        {
            string connectionString = "Data Source = localhost; Initial Catalog = Bureauonderwijsdatabase; Integrated Security = True";
            string sqlquery = "INSERT INTO Module(Name, Code, Period, Year, Faculty, Profile, Credits, GeneralModule, ExaminerId, Description, LectureHours, PracticalHours, Deleted)" +
                                "VALUES('" + Name + "', '" + Code + "','" + Period + "','" + Year + "','" + Faculty + "','" + Profile + "','" + Credits + "','" + GeneralModule + "', '" + ExaminerId + "', '" + Description + "','" + LectureHours + "','" + PracticalHours + "', 0);";
            try
            {
                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand(sqlquery, con);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                return "0";
            }

            catch (Exception)
            {
                return "1";
            }
        }


        public string UpdateModule(string Name, int ModuleCode, int Period, int Year, string Faculty, string Profile, int Credits, bool GeneralModule, int ExaminerId, string Description, int LectureHours, int PracticalHours, string ingelogd, int ModuleId)
        {
            string connectionString = "Data Source = localhost; Initial Catalog = Bureauonderwijsdatabase; Integrated Security = True";
            string sqlquerySelect = "SELECT[Name], [ModuleCode], [Period], [Year], [Faculty], [Profile], [Credits], [Examinor], [Description], [GeneralModule], [LectureHours], [PracticalHours], [ModuleId] FROM[Module]";
            string sqlqueryUpdate = "UPDATE Module SET Name = '" + Name + "', ModuleCode = '" + ModuleCode + "', Period = '" + Period + "', Year'" + Year + "', Faculty '" + Faculty + "', Profile '" + Profile + "', Credits'" + Credits + "', GeneralModule '" + GeneralModule + "', ExaminerId'" + ExaminerId + "', Description'" + Description + "', LectureHours'" + LectureHours + "', PracticalHours '" + PracticalHours + "' WHERE ModuleId = '" + ModuleId + "' ";

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
            string sqlquery = "DELETE FROM Module WHERE ModuleId = ('" + ModuleId + "')";

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
