using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HW4_Test2.Controllers
{
    public class HomeController : Controller
    {
        // GET /home/index
        public ActionResult Index()
        {
            return View();
        }

        // GET /home/about
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        // GET /home/contact
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        // GET /home/foo == home/about
        public ActionResult Foo()
        {
            //Turns foo into a router to About page
            return View("About");
        }
    }
}