using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Homework8.Models;
using Homework8.Models.ViewModels;
using System.Diagnostics;
using System.Web.Script.Serialization;

namespace Homework8.Controllers
{
    public class HomeController : Controller
    {
        private UserContext db = new UserContext();

        [HttpGet]
        public ActionResult Index()
        {
            //Format the data to be passed into the main view
            AllArt data = new AllArt{
                ArtistList = db.ARTISTs,
                ArtworkList = db.ARTWORKs,
                GenreList = db.GENREs,
                ClassificationList = db.CLASSIFICATIONs
            };

            return View(data);
        }
        [HttpPost]
        public ActionResult Index(int? ID)
        {
            //Create the model we'll use
            IList<jsonModel> data = new List<jsonModel>();

            //Get the ID of the genre we're looking for
            string genreID = db.GENREs.Find(ID).NAME;

            //Build the datamodel to return
            foreach (var item in db.CLASSIFICATIONs)
            {
                jsonModel temp = new jsonModel();
                if (item.GENRE1.NAME == genreID)
                {
                    temp.Artwork = item.ARTWORK1.TITLE;
                    temp.ArtistName = item.ARTWORK1.ARTIST1.NAME;
                    data.Add(temp);
                }
            }

            IEnumerable<jsonModel> toReturn = data.OrderBy(d => d.Artwork);

            //data.OrderBy(data => data.Artwork);

            return Json(data.OrderBy(d => d.Artwork), JsonRequestBehavior.AllowGet);
        }
    }
}