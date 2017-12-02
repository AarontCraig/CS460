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
        private Art db = new Art();

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
            for (int i = 0; i <= db.CLASSIFICATIONs.ToList().Count; ++i)
            {
                if(db.CLASSIFICATIONs.ToList()[i].GENRE1.NAME == genreID)
                {
                    data[i].Artwork = db.CLASSIFICATIONs.ToList()[i].GENRE1.NAME;
                    data[i].ArtistName = db.CLASSIFICATIONs.ToList()[i].GENRE1.NAME;
                }
            }

            //string output = new JavaScriptSerializer().Serialize(ListOfMyObject);

            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}