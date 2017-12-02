using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Homework8.Models;
using Homework8.Models.ViewModels;
using System.Diagnostics;

namespace Homework8.Controllers
{
    public class HomeController : Controller
    {
        private Art db = new Art();

        public ActionResult Index()
        {
            Debug.WriteLine(db.ARTISTs.ToList().FirstOrDefault());

            return View();
        }
    }
}