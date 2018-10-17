using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace BureauOnderwijs.Models.CC
{
    public class Examiner_DeleteModule
    {
        public DataTable DeleteModuleCC(int ModuleId, string ingelogd)
        {
            Models.BU.Examiner D = new Models.BU.Examiner();
            return D.DeleteModule(ModuleId, ingelogd);
        }
    }
}