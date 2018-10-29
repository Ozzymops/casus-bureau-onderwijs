using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BureauOnderwijs.Models.CC
{
    public class Scheduler_CreateEntry
    {
        public void CreateEntry(string[] entry)
        {
            Models.BU.Scheduler s = new Models.BU.Scheduler();
            s.AddEntry(entry);
        }
    }
}