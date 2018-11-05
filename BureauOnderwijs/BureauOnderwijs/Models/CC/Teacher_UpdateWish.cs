using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BureauOnderwijs.Models.CC
{
    public class Teacher_UpdateWish
    {
        public int UpdateWish(int period, int week, int day, int startTijdUur, int startTijdMinuut, int eindTijdUur, int EindTijdMinuut, int ingelogd, int wishId)
        {
            Models.BU.Wish w = new Models.BU.Wish();
            return w.UpdateWish(period, week, day, startTijdUur, startTijdMinuut, eindTijdUur, EindTijdMinuut, ingelogd, wishId);
        }

        public int getIntFromDayInput(string dag)
        {
            if (dag == "Maandag")
            {
                return 1;
            }
            if (dag == "Dinsdag")
            {
                return 2;
            }
            if (dag == "Woensdag")
            {
                return 3;
            }
            if (dag == "Donderdag")
            {
                return 4;
            }
            if (dag == "Vrijdag")
            {
                return 5;
            }

            return 0;
        }

        public string GetMessage(int result)
        {
            if (result == 1)
            {
                return "alert('Fout, problemen met de connectie van de database.');";
            }
            if (result == 0)
            {
                return "alert('Wens succesvol gewijzigd');";
            }

            return "alert('Er is iets fout gegaan, neem contact op met uw netwerkbeheerder!');";
        }
    }
}