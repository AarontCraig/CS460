using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HW6.Controllers
{
    public class HomeController : Controller
    {
        private AdventureWorksContext db = new AdventureWorksContext();
        //Get product categories
        /*
        public List getMainCats()
        {
            var mainCats = db.ProductCategories.ToList();
            return mainCats;
        } */

        public ActionResult Index()
        {

            var products = db.ProductCategories;
            return View(products.ToList());
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
        public ActionResult Test()
        {
            var products = db.Products.ToList();
            return PartialView(products);
        }
    }
}