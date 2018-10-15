﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BureauOnderwijs.Models.BU
{
    public class Module
    {
        private string name;
        private int moduleCode;
        private DateTime period;
        private DateTime year;
        private string faculty;
        private string profile;
        private int credits;
        private Examiner examiner;
        private string description;
        private bool generalModule;
        private int lectureHours;   // hoorcollege
        private int practicalHours; // werkcollege

        public Module(string name, int modulCode, DateTime period, DateTime year, string faculty, string profile, int credits, Examiner examiner, string description, bool generalModule, int lectureHours, int practicanHours)
        {

        }
    }
}