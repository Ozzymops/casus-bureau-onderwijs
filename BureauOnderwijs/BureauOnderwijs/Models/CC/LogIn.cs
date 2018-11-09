using BureauOnderwijs.Models.BU;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BureauOnderwijs.Models.CC
{
    public class LogIn
    {
        public User u;

        public int[] LoginCC(string username, string password)
        {
            if (u == null)
            {
                u = new User();
            }
            if (u.LogIn(username, password))
            {
                int[] tmp = { u.UserID, u.TwoFactorCode, u.RoleId };
                return tmp;
            }
            return null;

        }
        
        //Password Recovery hoort niet bij de UC "Login" -> Deze methode moet waarschijnlijk naar een andere .cs
        public bool CheckIfUserExists(string username)
        {
            if (u == null)
            {
                u = new User();
            }
            return u.CheckIfUserExists(username);
        }

        public string GetUsername(int userId)
        {
            /// feedback: maak niet constant een nieuw object aan. zet User.u in de class en roep dan alleen de functie(s) aan
            /// antwoord: krijg een error message dat er object u(User) null is. 
            /// -> Nieuwe contructor gemaakt hiervoor. Maar aangezien je deze functie aanroept vanuit "Master.cs", zal deze methode daar ook naar toe moeten

            if (u == null)
            {
                u = new User(userId);
            }
            return u.GetUsername(userId);
        }

 /*       public string GetLoginError(int RoleUseridRandomNumber)
        {
            return u.GetLoginError(RoleUseridRandomNumber);
            /*
            if (RoleUseridRandomNumber == -1)
            {
               return "alert('Ongeldige gebruikersnaam en of wachtwoord!');";
            }
            else if (RoleUseridRandomNumber == -2)
            {
                return "alert('Problemen met de connectie van de database.');";
            }
            else if (RoleUseridRandomNumber == -3)
            {
                return "alert('Kom op kerel, je code klopt voor de klote niet ;)');";
            }
            else if (RoleUseridRandomNumber == -4)
            {
                return "alert('Problemen met de mailingdinghusus');";
            }
            return "alert('Neem a.u.b. contact op met je netwerkbeheerder.');";
            
        }
    */
    }
}