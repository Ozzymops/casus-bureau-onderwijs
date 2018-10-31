using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BureauOnderwijs.Models.CC
{
    public class Teacher_DeleteWish
    {
        public int DeleteWish(int wishId)
        {
            Models.BU.Wish dw = new Models.BU.Wish();
            return dw.DeleteWish(wishId);
        }
        
        public string GetMessage(int result)
        {
            if (result == 1)
            {
                return "alert('Fout, problemen met de connectie van de database.');";
            }
            else if (result == 0)
            {
                return "alert('Wens succesvol verwijderd!');";
            }
            return "alert('Er is iets fout gegaan, neem contact op met uw netwerkbeheerder!');";
        }
    }
}