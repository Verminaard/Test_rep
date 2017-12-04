using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KP.Models
{
    public class Schedule
    {
        public string id_class;
        public string status;
        public List<Day> Days;

        public Schedule(string id_class, string status, List<Day> Days)
        {
            this.Days = Days;
            this.id_class = id_class;
            this.status = status;
        }

    }
}