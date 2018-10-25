using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BureauOnderwijs.Models.BU;

namespace BureauOnderwijs.Models.CC
{
    public class Admin_Authentication
    {
        public int Authentication(int userid)
        {
            Admin A = new Admin();
            return A.CheckAdmin(userid);
        }
    }
}