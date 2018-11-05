using BureauOnderwijs.Models.BU;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace BureauOnderwijs.Models.CC
{
    public class Examiner_ReadModules
    {
        public DataTable ReadModuleCC(string ingelogd)
        {
            Models.BU.Examiner M = new Models.BU.Examiner();
            return M.ReadModules(ingelogd);
        }

        public DataTable ReadModulesLinkedToTeachers(string ingelogd)
        {
            Models.BU.Examiner M = new Models.BU.Examiner();
            return M.ReadModulesLinkedToTeacher(ingelogd);
        }
    }
}