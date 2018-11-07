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
            Examiner ex = new Examiner();
            return ex.UpdateModule(Name, Code, Period, Year, Faculty, Profile, Credits, GeneralModule, ExaminerId, Description, LectureHours, PracticalHours, ModuleId, ingelogd);
        }
    }
}