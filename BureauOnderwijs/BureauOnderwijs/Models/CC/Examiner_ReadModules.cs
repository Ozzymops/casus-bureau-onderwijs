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
            //aanmaak van een nieuwe examinator met een return value van de in te vullen datagrid. deze wordt gebruikt in de BU laag.
            Models.BU.Examiner M = new Models.BU.Examiner();
            return M.ReadModules(ingelogd);
        }

        public DataTable ReadModulesLinkedToExaminor(string ingelogd)
        {
            //aanmaak van een nieuwe examinator met een return value van de in te vullen datagrid. deze wordt gebruikt in de BU laag.
            Models.BU.Examiner M = new Models.BU.Examiner();
            return M.ReadModulesLinkedToExaminor(ingelogd);
        }
    }
}