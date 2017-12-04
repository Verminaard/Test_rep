using KP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KP.Controllers
{
    public class HomeController : Controller
    {
        DAO_Schedule DAOS = new DAO_Schedule();
        public ActionResult Index()
        {
            
            DateTime thisDay = DateTime.Today;
            while (thisDay.DayOfWeek != System.DayOfWeek.Monday)
            {
                thisDay = thisDay.AddDays(-1);
            }
            List < DateTime > Week = new List<DateTime>();
            for (int i = 0; i < 6; i++)
            {
                Week.Add(thisDay);
                thisDay.AddDays(2);
            }

            Schedule arg1 = DAOS.GetScheduleByClass("5A");
            List<Mark> arg2 = DAOS.GetMarksByIdAndDate(4, Week[0], Week[5]);
            List<Homework> arg3 = DAOS.GetHomeworkByIdAndDate(4, Week[0], Week[5]);
            List<MdlSchedule> sch = new List<MdlSchedule>();
            for(int i = 0; i < arg1.Days.Count; i++)
            {
                DateTime dt = Week[i];
                string  subname = "";
                for (int j = 0; j < arg1.Days[i].Subjects.Count; j++)
            {
                    string homework = "";
                     int number = j, mark = 0, k = 0, kk = 0;;
                    subname = arg1.Days[i].Subjects[j].Name;
                    if (k < arg3.Count && dt == arg3[k].date && subname == arg3[k].subject.Name)
                    {
                        homework = arg3[k++].homework;
                       // k += (k + 1 > arg3.Count) ? 0 : 1;
                    }
                    if (kk < arg2.Count && dt == arg2[kk].date && subname == arg2[kk].subject.Name)
                    {
                        mark = arg2[kk++].mark;
                       // kk += (kk + 1 > arg2.Count) ? 0 : 1;
                    }
                    sch.Add(new MdlSchedule(dt, number, subname, homework, mark));
                }
}

            return View(sch);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}