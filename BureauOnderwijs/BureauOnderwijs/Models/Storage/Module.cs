using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BureauOnderwijs.Models.Storage
{
    public class Module
    {
        private string name;
        private int moduleCode;
        private int period;
        private int year;
        private string faculty;
        private string profile;
        private int credits;
        private Examiner examiner;
        private string description;
        private bool generalModule;
        private int lectureHours;
        private int practicalHours;
    }
}