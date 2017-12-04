using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace KP.Models
{
    public class Day
    {
        public List<Subject> Subjects;
        Calendar cal;
        public Day(List<Subject> Subjects)
        {
            this.Subjects = Subjects;
        }
    }
}