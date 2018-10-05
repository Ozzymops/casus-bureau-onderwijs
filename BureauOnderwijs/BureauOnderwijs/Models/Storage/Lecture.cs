using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BureauOnderwijs.Models.Storage
{
    public class Lecture
    {
        public Teacher teacher;
        public string classroom;
        public DateTime startTime;
        public DateTime endTime;
        public DateTime date;
        public string studentGroup;
    }
}