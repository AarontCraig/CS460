using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HW6.Controllers
{
    public class PartialController : Controller
    {
        private AdventureWorksContext db = new AdventureWorksContext();
        // GET: Layout
        //[ChildActionOnly]
        public ActionResult SetNavBar()
        {
            var categories = db.ProductCategories;
            return View();
        }
    }
}