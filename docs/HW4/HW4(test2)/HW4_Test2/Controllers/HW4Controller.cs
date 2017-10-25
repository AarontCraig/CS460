using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HW4_Test2.Controllers
{
    public class HW4Controller : Controller
    {
        public ActionResult Page_1()
        {
            string movie = Request.Form["FavMovie"];
            Debug.WriteLine(movie);
            ViewBag.movie = movie;
            string color = Request.Form["favColor"];
            ViewBag.color = color;

            Debug.WriteLine($"{movie} and {color}");
            return View();
        }
    }
}