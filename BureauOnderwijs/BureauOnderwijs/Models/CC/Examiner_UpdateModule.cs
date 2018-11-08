using BureauOnderwijs.Models.BU;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BureauOnderwijs.Models.CC
{
    public class Examiner_UpdateModule
    {
        public string UpdateModuleCC(string Name, string Code, int Period, int Year, string Faculty, string Profile, int Credits, bool GeneralModule, int ExaminerId, string Description, int LectureHours, int PracticalHours, int ModuleId, string ingelogd)
        {
            //aanmaak van een nieuwe examinator met een return value van de informatie die de gebruiker ingevoerd heeft. deze wordt gebruikt in de BU laag.
            Models.BU.Examiner ex = new Models.BU.Examiner();
            return ex.UpdateModule(Name, Code, Period, Year, Faculty, Profile, Credits, GeneralModule, ExaminerId, Description, LectureHours, PracticalHours, ModuleId, ingelogd);
        }
    }
}