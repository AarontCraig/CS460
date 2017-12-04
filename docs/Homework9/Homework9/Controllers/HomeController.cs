using Homework9.Models;
using Homework9.Models.UserModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Homework9.Controllers
{
    public class HomeController : Controller
    {
        private UserContext db = new UserContext();
        

        public ActionResult Index()
        {
            AllArt data = new AllArt
            {
                ArtistList = db.ARTISTs,
                ArtworkList = db.ARTWORKs,
                GenreList = db.GENREs,
                ClassificationList = db.CLASSIFICATIONs
            };

            return View(data);
        }

        [HttpGet]
        public JsonResult ShowArtList(int? ID)
        {
            string genre = db.GENREs.Find(ID.Value).NAME;

            JsonData data = new JsonData();

            foreach (var item in db.CLASSIFICATIONs)
            {
                if (item.GENRE1.NAME == genre)
                {
                    JsonData temp = new JsonData();
                    data.Artwork = item.ARTWORK1.TITLE;
                }
            }

            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}