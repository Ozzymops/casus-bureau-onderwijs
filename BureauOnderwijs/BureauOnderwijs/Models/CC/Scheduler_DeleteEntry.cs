using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BureauOnderwijs.Models.CC
{
    public class Scheduler_DeleteEntry
    {
        /// <summary>
        /// Delete een entry in de database.
        /// </summary>
        public void DeleteEntry(int lectureId)
        {
            Models.BU.Scheduler s = new Models.BU.Scheduler();
            s.DeleteEntry(lectureId);
        }
    }
}