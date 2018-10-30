using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BureauOnderwijs.Models.CC
{
    public class Scheduler_GetData
    {
        Models.BU.Scheduler s = new Models.BU.Scheduler();

        /// <summary>
        /// Return de bijbehorende username volgens gegeven userId.
        /// </summary>
        public string UserIdToUsername(int userId)
        {
            return (s.UserIdToUsername(userId));
        }

        public int UsernameToUserId(string username)
        {
            return (s.UsernameToUserId(username));
        }

        /// <summary>
        /// Return een lijst van Teachers.
        /// </summary>
        /// <returns></returns>
        public List<Models.BU.Teacher> GetTeacherList()
        {
            return (s.GetTeacherList());
        }

        /// <summary>
        /// Return één Teacher.
        /// </summary>
        public Models.BU.Teacher GetSingleTeacher(int userId)
        {
            return (s.GetSingleTeacher(userId));
        }

        /// <summary>
        /// Return een lijst van Modules op basis van userId.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<Models.BU.Module> GetModuleListOfTeacher(int userId)
        {
            return (s.GetModuleListOfTeacher(userId));
        }

        /// <summary>
        /// Return één Module.
        /// </summary>
        public Models.BU.Module GetSingleModule(int moduleId)
        {
            return (s.GetSingleModule(moduleId));
        }

        /// <summary>
        /// Return een lijst van beschikbare werkdagen.
        /// </summary>
        public List<int> GetAvailableDays(int userId, int period, int week)
        {
            return (s.GetAvailableDays(userId, period, week));
        }
    }
}