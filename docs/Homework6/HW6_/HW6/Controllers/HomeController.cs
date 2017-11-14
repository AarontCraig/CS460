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
using HW6.Models.ViewModels;

namespace HW6.Controllers
{
    public class HomeController : Controller
    {
        private AdventureWorksContext db = new AdventureWorksContext();

        public ActionResult Index()
        {
            var mainList = db.ProductCategories.ToList();
            ForIndex forIndex = new ForIndex() { ProductCategories = db.ProductCategories, ProductSubcategories = db.ProductSubcategories };

            return View(forIndex);
        }

        public ActionResult ChosenCategory(int? id) //Id is ProductSubcategoryID in ProductCategory table
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Here is where I do pagination
            ChosenCategory toReturn = new Models.ViewModels.ChosenCategory()
            {
                ProductCategories = db.ProductCategories,
                ProductSubcategories = db.ProductSubcategories.ToList()[id.Value - 1].Products.ToList(),
                PageTitle = db.ProductSubcategories.ToList()[id.Value - 1].Name
            };

            return View(toReturn);
        }
        [HttpGet]
        public ActionResult Review(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            ForReview forReview = new ForReview() {
                ProductCategories = db.ProductCategories,
                SpecificProduct = db.Products.Find(id.Value),
                
            };

            return PartialView(forReview);
        }
        [HttpPost]
        public ActionResult Review(FormCollection form, int? id)
        {
            if (id == null)
                return RedirectToAction("Index");
            if (form.Get("user") == "" || form.Get("email") == "" || form.Get("comment") == "")
                return RedirectToAction("Review");
            var format = "MM-dd-yyyy HH:mm:ss:fff";
            var stringDate = DateTime.Now.ToString(format);
            var reviewDate = DateTime.ParseExact(stringDate, format, CultureInfo.InvariantCulture);
            var modifiedDate = DateTime.ParseExact(stringDate, format, CultureInfo.InvariantCulture);

            int rating = Convert.ToInt32(form.Get("rating"));

            var review = new ProductReview
            {
                ProductID = id.Value,
                ReviewerName = form.Get("user"),
                ReviewDate = reviewDate,
                EmailAddress = form.Get("email"),
                Rating = rating,
                Comments = form.Get("comment"),
                ModifiedDate = modifiedDate
            };
            db.ProductReviews.Add(review);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult NavBar()
        {
            var mainList = db.ProductCategories.ToList();
            return View(mainList);
        }
    }
}