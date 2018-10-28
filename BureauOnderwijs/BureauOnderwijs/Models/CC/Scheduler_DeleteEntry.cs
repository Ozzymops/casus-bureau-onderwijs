using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BureauOnderwijs.Models.CC
{
    public class Scheduler_DeleteEntry
    {
        public void DeleteEntry(string[] entry)
        {
            Models.BU.Scheduler s = new Models.BU.Scheduler();
            s.DeleteEntry(entry);
        }
    }
}