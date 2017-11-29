using Homework7.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Homework7.Controllers
{
    public class SearchController : Controller
    {
        public ActionResult Index(string q, string rating)
        {
            string apiKey = System.Web.Configuration.WebConfigurationManager.AppSettings["GiphyKey"];
            WebRequest request = WebRequest.Create("http://api.giphy.com/v1/gifs/search?q=" + q + "&limit=20&rating=" + rating + "&api_key=" + apiKey); //Requests the data from the url
            WebResponse response = request.GetResponse(); //Gets everything back from that website into one object
            Stream dataStream = response.GetResponseStream(); //Gets the response I want back, the json object
            StreamReader reader = new StreamReader(dataStream); //Decodes the stream
            string responseFromServer = reader.ReadToEnd(); //Saves it into a string

            //Convert from json to c#
            JObject parsedString = JObject.Parse(responseFromServer);

            IList<JToken> listedJsonObject = parsedString["data"].Children().Values("images").Values("fixed_width").ToList(); //Jumping into the {} of the json object, could do this several times to get data out of inner and upper layers

            IList<Models.Gif> giphyResultsList = new List<Gif>();
            foreach (JToken result in listedJsonObject)
            {
                Gif found = result.ToObject<Gif>();
                giphyResultsList.Add(found);
            }

            //Close where necessary
            reader.Close();
            response.Close();

            Debug.WriteLine("Inside Ajax");

            return Json(giphyResultsList, JsonRequestBehavior.AllowGet);
        }
    }
}