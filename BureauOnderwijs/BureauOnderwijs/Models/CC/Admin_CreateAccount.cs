using BureauOnderwijs.Models.BU;

namespace BureauOnderwijs.Models.CC
{ 
    public class Admin_CreateAccount
    //Admin functie om een account toe te voegen aan de Database
    {
        private int IntRole;

        public int CreateUserCC(string Username, string Password, string Email, string FirstName, string LastName, string StrRole)
        {
            Admin A = new Admin();

            //convert Role input naar int
            if (StrRole == "Docent")
            {
                IntRole = 1;
            }
            else if (StrRole == "Roostermaker")
            {
                IntRole = 2;
            }
            else if (StrRole == "Examinator")
            {
                IntRole = 3;
            }
            else
            //StrRole == "Administrator"
            {
                IntRole = 4;
            }

            return A.CreateUser(Username, Password, Email, FirstName, LastName, IntRole);
        }
    }
}