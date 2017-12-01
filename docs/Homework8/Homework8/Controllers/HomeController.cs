using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Homework8.Models;
using Homework8.Models.ViewModels;

namespace Homework8.Controllers
{
    public class HomeController : Controller
    {
        private Art db = new Art();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Artist()
        {
            var artists = db.ARTISTs.ToList();
            return View(artists);
        }

        public ActionResult Artwork()
        {
            return View();
        }

        public ActionResult Genre()
        {
            return View();
        }

        public ActionResult Classification()
        {
            return View();
        }
    }
}