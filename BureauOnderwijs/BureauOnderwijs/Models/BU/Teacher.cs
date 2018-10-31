using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BureauOnderwijs.Models.BU
{
    public class Teacher : User     // inherit from User.cs
    {
        private List<Wish> wishList;

        public Teacher()
        {
            // Leeg: anders verschijnen er enge rode lijntjes.
        }

        public Teacher(int id, string username, string email, string firstname, string lastname): base()
        {
            this.userId = id;
            this.username = username;
            this.emailAdress = email;
            this.firstname = firstname;
            this.lastname = lastname;
        }

        private void ViewWishlist()
        {

        }

        private void CreateWishlist()
        {

        }

        private void EditWishlist()
        {

        }

        private void DeleteWishlist()
        {

        }
    }
}