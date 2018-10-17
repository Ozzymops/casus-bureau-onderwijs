using BureauOnderwijs.Models.BU;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BureauOnderwijs.Models.CC
{
    public class Examiner_CreateModule
    {
        public string AddModuleCC(string Name, int ModuleCode, int Period, int Year, string Faculty, string Profile, int Credits, bool GeneralModule , string Examinor, string Description, int LectureHours, int PracticalHours, string ingelogd)
        {
            Examiner ex = new Examiner();
            return ex.AddNewModule(Name, ModuleCode, Period, Year, Faculty, Profile, Credits, GeneralModule ,Examinor, Description, LectureHours, PracticalHours, ingelogd);
        }
    }
}