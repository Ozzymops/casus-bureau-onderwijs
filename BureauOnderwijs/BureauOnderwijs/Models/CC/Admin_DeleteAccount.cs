using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using BureauOnderwijs.Models.BU;

namespace BureauOnderwijs.Models.CC
{
    public class Admin_DeleteAccount
    {
        public DataTable DeleteUserCC(string userid)
        {
            Admin A = new Admin();
            return A.SelDeleteUser(userid);
        }

        public int DeleteUserExeCC(string userid)
        {
            Admin B = new Admin();
            return B.DeleteUser(userid);
        }
    }
}