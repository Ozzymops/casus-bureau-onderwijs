﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BureauOnderwijs.Models.CC
{
    public class Scheduler_GetData
    {
        public List<string> GetUsernameListRole(int role)
        {
            Models.BU.Scheduler s = new Models.BU.Scheduler();
            return(s.GetUsernameListRole(role));
        }

        public List<int> GetDayListUserId(string username)
        {
            Models.BU.Scheduler s = new Models.BU.Scheduler();
            return(s.GetDayListUserId(username));
        }

        public List<int> GetModuleListUserId(string username)
        {
            Models.BU.Scheduler s = new Models.BU.Scheduler();
            return (s.GetModuleListUserId(username));
        }

        public string GetModuleCode(int module)
        {
            Models.BU.Scheduler s = new Models.BU.Scheduler();
            return (s.GetModuleCode(module));
        }
    }
}