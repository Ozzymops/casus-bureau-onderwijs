using BureauOnderwijs.Models.BU;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BureauOnderwijs.Models.CC
{
    public class Teacher_CreateWish
    {
        public int CreateWishCC(string period, int week, string day, string startTime, string endTime, int ingelogd)
        {
            Wish w = new Wish();
            return w.CreateWish(period, week, day, startTime, endTime, ingelogd);
        }
    }
}