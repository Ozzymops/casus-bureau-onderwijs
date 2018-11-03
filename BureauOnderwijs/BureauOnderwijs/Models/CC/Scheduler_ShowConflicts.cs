using BureauOnderwijs.Models.BU;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BureauOnderwijs.Models.CC
{
    public class Scheduler_ShowConflicts
    {
        public string ConflictsClassroomEmpty()
        {
            Models.BU.Scheduler s = new Scheduler();
            return s.ConflictCheckClassroomEmpty();
        }
        public string ConflictsTeacherEmpty()
        {
            Models.BU.Scheduler s = new Scheduler();
            return s.ConflictCheckTeacherEmpty();
        }
        public string ConflictsStudentgroupEmpty()
        {
            Models.BU.Scheduler s = new Scheduler();
            return s.ConflictCheckStudentgroupEmpty();
        }
    }
}