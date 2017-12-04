using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KP.Models
{
    public class Mark
    {
        public int mark;
        public string date;
        public Subject subject;

        public Mark(int mark, string date, Subject subject)
        {
            this.mark = mark;
            this.date = date;
            this.subject = subject;
        }
    }
}