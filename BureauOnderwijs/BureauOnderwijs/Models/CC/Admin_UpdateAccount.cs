using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using BureauOnderwijs.Models.BU;

namespace BureauOnderwijs.Models.CC
{
    public class Admin_UpdateAccount
    {
        public DataTable ReadUsersCC()
        {
            Admin A = new Admin();
            return A.ReadUsers();
        }
    }
}