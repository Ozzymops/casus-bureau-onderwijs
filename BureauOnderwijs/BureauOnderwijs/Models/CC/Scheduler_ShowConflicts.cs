using BureauOnderwijs.Models.BU;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BureauOnderwijs.Models.CC
{
    public class Scheduler_ShowConflicts
    {
        public int Conflicts()
        {
            Models.BU.Scheduler s = new Scheduler();
            return s.ConflictCheck();
        }
    }
}