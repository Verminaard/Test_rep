using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KP.Models
{
    public class Day
    {
        public List<Subject> Subjects;
        public Day(List<Subject> Subjects)
        {
            this.Subjects = Subjects;
        }
    }
}