using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Homework7;
using Homework7.Models;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Ajax.Utilities;
using System.Web.Helpers;
using System.Net;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;

namespace Homework7.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            string apiKey = System.Web.Configuration.WebConfigurationManager.AppSettings["GiphyKey"];
            WebRequest request = WebRequest.Create("http://api.giphy.com/v1/gifs/search?q=Cats&limit=20&api_key=" + apiKey); //Requests the data from the url
            WebResponse response = request.GetResponse(); //Gets everything back from that website into one object
            Stream dataStream = response.GetResponseStream(); //Gets the response I want back, the json object
            StreamReader reader = new StreamReader(dataStream); //Decodes the stream
            string responseFromServer = reader.ReadToEnd(); //Saves it into a string

            //Convert from json to c#
            JObject parsedString = JObject.Parse(responseFromServer);

            IList<JToken> listedJsonObject = parsedString["data"].Children().Values("images").Values("fixed_width").ToList(); //Jumping into the {} of the json object, could do this several times to get data out of inner and upper layers

            IList<Gif> giphyResultsList = new List<Gif>();
            foreach (JToken result in listedJsonObject)
            {
                Gif found = result.ToObject<Gif>();
                giphyResultsList.Add(found);
            }
            
            //Close where necessary
            reader.Close();
            response.Close();

            return View(giphyResultsList);
        }

    }
}

/*
        private static readonly HttpClient client = new HttpClient();

        public async System.Threading.Tasks.Task<ActionResult> IndexAsync()
        {
            string apiKey = System.Web.Configuration.WebConfigurationManager.AppSettings["GiphyKey"];

            using (var client = new HttpClient())
            {
                var uri = new Uri("http://api.giphy.com/v1/gifs/search?q=Cats&limit=20&api_key=" + apiKey);
                //var gifs = DownloadSeriealizedJsonData<Gif>(uri.ToString());
                var response = await client.GetAsync(uri);
                string textResult = await response.Content.ReadAsStringAsync();
                Gif gifs = JsonConvert.DeserializeObject<Gif>(textResult);
                Debug.WriteLine(gifs);
            }

            return View();
        }

        public ActionResult Index()
        {
            return View(IndexAsync());
        }

        private static T DownloadSeriealizedJsonData<T>(string url) where T :new()
        {
            using (var w = new WebClient())
            {
                var jsonData = string.Empty;
                //Download json data
                try
                {
                    jsonData = w.DownloadString(url);
                }
                catch (Exception)
                {

                }

                return !string.IsNullOrEmpty(jsonData) ? JsonConvert.DeserializeObject<T>(jsonData) : new T();
            }
        }
    }
}
*/