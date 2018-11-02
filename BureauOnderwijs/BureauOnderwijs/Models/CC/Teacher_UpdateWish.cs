using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BureauOnderwijs.Models.CC
{
    public class Teacher_UpdateWish
    {
        public int UpdateWish(string period, int week, int day, int startTijdUur, int startTijdMinuut, int eindTijdUur, int EindTijdMinuut, int ingelogd, int wishId)
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


        public int CheckInput(string period, int week, string day, int startTijdUur, int startTijdMinuut, int eindTijdUur, int EindTijdMinuut)
        {
            if (new string[] { "1", "2", "3", "4" }.Contains(period) == false)
            {
                return 1;
            }
            if (week < 1 && week > 10)
            {
                return 2;
            }
            if (new string[] { "Maandag", "Dinsdag", "Woensdag", "Donderdag", "Vrijdag" }.Contains(day) == false)
            {
                return 3;
            }
            if (startTijdUur < 9 && startTijdUur > 18)
            {
                return 4;
            }
            if (new int[] { 0, 30 }.Contains(startTijdMinuut) == false)
            {
                return 5;
            }
            if (eindTijdUur < 9 && eindTijdUur > 18)
            {
                return 6;
            }
            if (new int[] { 0, 30 }.Contains(EindTijdMinuut) == false)
            {
                return 7;
            }

            return 0;
        }

        public string GetMessageInputError(int checkResult)
        {
            if (checkResult == 1)
            {
                return "alert('Foutieve invoer blok, probeer het nogmaals!');";
            }
            if (checkResult == 2)
            {
                return "alert('Foutieve invoer week, probeer het nogmaals!');";
            }
            if (checkResult == 3)
            {
                return "alert('Foutieve invoer dag, probeer het nogmaals!');";
            }
            if (checkResult == 4)
            {
                return "alert('Foutieve invoer starttijd uur, probeer het nogmaals!');";
            }
            if (checkResult == 5)
            {
                return "alert('Foutieve invoer starttijd minnuut, probeer het nogmaals!');";
            }
            if (checkResult == 6)
            {
                return "alert('Foutieve invoer eindtijd uur, probeer het nogmaals!');";
            }
            if (checkResult == 7)
            {
                return "alert('Foutieve invoer einddtijd minuut, probeer het nogmaals!');";
            }

            return "alert('Grote fout! Neem a.u.b. contact op met je netwerkbeheerder!');";
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