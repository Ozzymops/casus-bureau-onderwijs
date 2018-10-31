using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BureauOnderwijs.Models.CC
{
    public class Scheduler_UpdateEntry
    {
        /// <summary>
        /// Update een entry in de database.
        /// </summary>
        public void UpdateEntry(Models.BU.Lecture lecture, int lectureId)
        {
            Models.BU.Scheduler s = new Models.BU.Scheduler();
            s.UpdateEntry(lecture, lectureId);
        }
    }
}