using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KP.Models
{
    public class MdlSchedule
    {
        public DateTime dt;
        public int number;
        public string sub_name;
        public string homework;
        public int mark;


        public MdlSchedule (DateTime dt, int number, string sub_name, string homework, int mark)
            {
            this.dt = dt;
            this.number = number;
            this.sub_name = sub_name;
            this.homework = homework;
            this.mark = mark;
        }
    }
}