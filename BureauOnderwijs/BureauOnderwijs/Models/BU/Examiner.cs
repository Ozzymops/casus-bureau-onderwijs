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

        //public bool NewModule(Models.BU.Module m)
        /*{
            using (SqlConnection connection = new SqlConnection())
            connection.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Module(Name, ModuleCode, Period, Year, Faculty, Profile, Credits, Examinor, Description, GeneralModule, LectureHours, PracticalHours)" +
                "VALUES (@Name, @Modulecode, @Period, @Year, @Faculty, @profile, @Credits, @Examinor, @Description, @GeneralModule, @LectureHours, @PracticalHours)");
        }*/

        private void UpdateModule()
        {

        }

        private void DeleteModule()
        {

        }
    }
}