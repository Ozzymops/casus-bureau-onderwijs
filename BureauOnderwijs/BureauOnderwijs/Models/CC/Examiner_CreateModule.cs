using BureauOnderwijs.Models.BU;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BureauOnderwijs.Models.CC
{
    public class Examiner_CreateModule
    {
        public string AddModuleCC(string Name, string Code, int Period, int Year, string Faculty, string Profile, int Credits, bool GeneralModule, int ExaminerId, string Description, int LectureHours, int PracticalHours, /*int docent,*/ string ingelogd)
        {
            Examiner ex = new Examiner();
            return ex.AddNewModule(Name, Code, Period, Year, Faculty, Profile, Credits, GeneralModule ,ExaminerId, Description, LectureHours, PracticalHours, /*docent,*/ ingelogd);
        }
    }
}