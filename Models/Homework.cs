using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KP.Models
{
    public class Homework
    {
        public string homework;
        public string date;
        public Subject subject;

        public Homework(string homework, string date, Subject subject)
        {
            this.homework = homework;
            this.date = date;
            this.subject = subject;
        }
    }
}