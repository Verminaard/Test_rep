using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KP.Models
{
    public class MdlSchedule
    {
        public Schedule schedule;
        public List<Mark> marks;
        public List<Homework> homework;

        public MdlSchedule (Schedule schedule, List<Mark> marks, List<Homework> homework)
            {
            this.schedule = schedule;
            this.marks = marks;
            this.homework = homework;
            }
    }
}