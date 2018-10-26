using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BureauOnderwijs.Models.CC
{
    public class Scheduler_UpdateEntry
    {
        public void UpdateEntry(string[] entry)
        {
            Models.BU.Scheduler s = new Models.BU.Scheduler();
            s.EditEntry(entry);
        }
    }
}