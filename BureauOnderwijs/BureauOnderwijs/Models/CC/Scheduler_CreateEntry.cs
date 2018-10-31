using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BureauOnderwijs.Models.CC
{
    public class Scheduler_CreateEntry
    {
        /// <summary>
        /// Maak een entry aan in de database.
        /// </summary>
        public void CreateEntry(Models.BU.Lecture lecture)
        {
            Models.BU.Scheduler s = new Models.BU.Scheduler();
            s.CreateEntry(lecture);
        }
    }
}