using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BureauOnderwijs.Models.BU
{
    public class Lecture
    {
        public int lectureId;
        public Teacher teacher;
        public Module module;
        public string classroom;
        public string studentGroup;
        public int period;
        public int week;
        public int day;
        public int startHour;
        public int startMinute;
        public int endHour;
        public int endMinute;

        public int LectureId
        {
            get { return this.lectureId; }
            set { this.lectureId = value; }
        }

        public Teacher Teacher
        {
            get { return this.teacher; }
            set { this.teacher = value; }
        }

        public Module Module
        {
            get { return this.module; }
            set { this.module = value; }
        }

        public Lecture()
        {
            // Leeg: anders verschijnen er enge rode lijntjes.
        }

        public Lecture(Teacher teacher, Module module, string classroom, string studentGroup,
                       int period, int week, int day, int startHour, int startMinute, int endHour, int endMinute)
        {
            this.teacher = teacher;
            this.module = module;
            this.classroom = classroom;
            this.studentGroup = studentGroup;
            this.period = period;
            this.week = week;
            this.day = day;
            this.startHour = startHour;
            this.startMinute = startMinute;
            this.endHour = endHour;
            this.endMinute = endMinute;
        }
    }
}