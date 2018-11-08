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
            //aanmaak van een nieuwe examinator met een return value van de informatie die de gebruiker ingevoerd heeft. deze wordt gebruikt in de BU laag.
            Models.BU.Examiner D = new Models.BU.Examiner();
            return D.DeleteModule(ModuleId, ingelogd);
        }
    }
}