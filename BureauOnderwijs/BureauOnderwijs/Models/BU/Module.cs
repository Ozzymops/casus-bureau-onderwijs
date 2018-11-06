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
    }
}
