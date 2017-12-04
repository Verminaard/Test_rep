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
            Schedule arg1 = DAOS.GetScheduleByClass("5A");
            List<Mark> arg2 = DAOS.GetMarksById(4);
            List<Homework> arg3 = DAOS.GetHomeworkById(4);
            MdlSchedule sch = new MdlSchedule(arg1, arg2, arg3);
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