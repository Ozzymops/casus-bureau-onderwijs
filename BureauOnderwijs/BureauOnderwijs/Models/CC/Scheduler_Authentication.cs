﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BureauOnderwijs.Models.BU;

namespace BureauOnderwijs.Models.CC
{
    public class Scheduler_Authentication
    {
        public int Authentication(int userid)
        {
            Scheduler S = new Scheduler();
            return S.CheckScheduler(userid);
        }
    }
}