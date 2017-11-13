using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HW6;

namespace HW6.Controllers
{
    public class HomeController : Controller
    {
        private AdventureWorksContext db = new AdventureWorksContext();

        public ActionResult Index()
        {

            var mainList = db.ProductCategories.ToList();

            return View(mainList);
        }

        public ActionResult ChosenCategory(int? id) //Id is ProductSubcategoryID in ProductCategory table
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Here is where I do pagination
            var productLine = db.ProductSubcategories.ToList()[id.Value].Products.ToList();

            ViewBag.ProductCategories = db.ProductCategories.ToList();
            ViewBag.ProductSubcategories = db.ProductSubcategories.ToList();

            return View(productLine);
        }

        [HttpGet]
        public ActionResult Review(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var specificProduct = db.Products.Find(id);

            return PartialView(specificProduct);
        }
        [HttpPost]
        public ActionResult Review(string user, string email, int rating, string comment)
        {
            ProductReview review = new ProductReview
            {
                ProductID = ViewBag.ProductID,
                ReviewerName = user,
                ReviewDate = new DateTime(),
                EmailAddress = email,
                Rating = rating,
                Comments = comment
            };
            db.ProductReviews.Add(review);
            db.SaveChanges();

            return View();
        }
    }
}