using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HW6;
using System.Globalization;

namespace HW6.Controllers
{
    public class HomeController : Controller
    {
        private AdventureWorksContext db = new AdventureWorksContext();

        public ActionResult Index()
        {
            var format = "MM-dd-yyyy HH:mm:ss:fff";
            var stringDate = DateTime.Now.ToString(format);
            var reviewDate = DateTime.ParseExact(stringDate, format, CultureInfo.InvariantCulture);
            var modifiedDate = DateTime.ParseExact(stringDate, format, CultureInfo.InvariantCulture);

            var newReview = new ProductReview
            {
                ProductID = 710,
                ReviewerName = "Bobby",
                ReviewDate = reviewDate,
                EmailAddress = "Test@gmail.com",
                Rating = 4,
                Comments = "Testing",
                ModifiedDate = modifiedDate
            };
            db.ProductReviews.Add(newReview);
            db.SaveChanges();

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
            var productLine = db.ProductSubcategories.ToList()[id.Value - 1].Products.ToList();

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
        public ActionResult Review(FormCollection form)
        {
            var format = "MM-dd-yyyy HH:mm:ss:fff";
            var stringDate = DateTime.Now.ToString(format);
            var reviewDate = DateTime.ParseExact(stringDate, format, CultureInfo.InvariantCulture);
            var modifiedDate = DateTime.ParseExact(stringDate, format, CultureInfo.InvariantCulture);

            int rating = Convert.ToInt32(form.Get("rating"));
            string productID = ViewBag.ProductID;

            var newReview = new ProductReview
            {
                ProductID = 710,
                ReviewerName = "Bobby",
                ReviewDate = reviewDate,
                EmailAddress = "Test@gmail.com",
                Rating = 4,
                Comments = "Testing",
                ModifiedDate = modifiedDate
            };
            /*var review = new ProductReview
            {
                ProductID = ViewBag.ProductID,
                ReviewerName = form.Get("user"),
                ReviewDate = reviewDate,
                EmailAddress = form.Get("email"),
                Rating = rating,
                Comments = form.Get("comment"),
                ModifiedDate = modifiedDate
            };*/
            db.ProductReviews.Add(newReview);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}