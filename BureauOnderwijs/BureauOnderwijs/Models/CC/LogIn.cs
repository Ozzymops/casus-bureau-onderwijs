using BureauOnderwijs.Models.BU;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BureauOnderwijs.Models.CC
{
    public class LogIn
    {
        public int[] LoginCC(string username, string password)
        {
            User u = new User();
            return u.LogIn(username, password);
        }

        public bool CheckIfUserExists(string username)
        {
            User u = new User();
            return u.CheckIfUserExists(username);
        }
    }
}