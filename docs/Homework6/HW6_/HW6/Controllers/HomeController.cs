using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace HW6.Controllers
{
    public class HomeController : Controller
    {
        private AdventureWorksContext db = new AdventureWorksContext();

        public ActionResult Index()
        {
            //Here is where I do pagination
            var mainList = db.ProductCategories.ToList();

            return View(mainList);
        }

        public ActionResult ChosenCategory(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Product product = db.Products.Find(id);

            return View(product);
        }

        public ActionResult Test()
        {
            var products = db.Products.ToList();
            return PartialView(products);
        }
    }
}