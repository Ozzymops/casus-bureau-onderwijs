using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BureauOnderwijs.Models
{
    public class RandomNumberGenerator
    {
        public int GenerateNumber(int min, int max)
        {
            Random r = new Random();
            int number = r.Next(min, max);
            return number;
        }
    }
}