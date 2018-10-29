using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BureauOnderwijs.Models.CC
{
    public class Scheduler_ReadEntry
    {
        public List<string[]> ReadEntry()
        {
            Models.BU.Scheduler s = new Models.BU.Scheduler();
            return (s.ShowEntry());
        }
    }
}