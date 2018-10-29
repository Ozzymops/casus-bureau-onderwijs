using BureauOnderwijs.Models.BU;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace BureauOnderwijs.Models.CC
{
    public class Teacher_CreateWish
    {
        public int CreateWishCC(string period, int week, int day, int startHour, int startMinute, int endHour, int endMinute, int ingelogd)
        {
            Wish w = new Wish();
            return w.CreateWish(period, week, day, startHour, startMinute, endHour, endMinute, ingelogd);
        }

        public int getIntFromDayinput(string dag)
        {
            if (dag == "Maandag")
            {
                return 1;
            }
            else if (dag == "Dinsdag")
            {
                return 2;
            }
            else if (dag == "Woensdag")
            {
                return 3;
            }
            else if (dag == "Donderdag")
            {
                return 4;
            }
            else if (dag == "Vrijdag")
            {
                return 5;
            }
            return 0;
        }

        public string getMessage(int result)
        {
            if (result == 1)
            {
                return "alert('Fout, problemen met de connectie van de database.');";
            }
            else if (result == 0)
            {
                return "alert('Wens succesvol toegevoegd');";
            }
            return "alert('Er is iets fout gegaan, neem contact op met uw netwerkbeheerder!');";
        }
    }
}