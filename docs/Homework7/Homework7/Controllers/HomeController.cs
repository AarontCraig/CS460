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

namespace Homework7.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            WebRequest request = WebRequest.Create("http://api.giphy.com/v1/gifs/search?q=Cats&limit=20&api_key=1hY46oCFqO6Z18gCBt2a5HoE6qePLqaL"); //Requests the data from the url
            WebResponse response = request.GetResponse(); //Gets everything back from that website into one object
            Stream dataStream = response.GetResponseStream(); //Gets the response I want back, the json object
            StreamReader reader = new StreamReader(dataStream); //Decodes the stream
            string responseFromServer = reader.ReadToEnd(); //Saves it into a string
            Debug.WriteLine(responseFromServer); 
            //Close where necessary
            reader.Close();
            response.Close();

            
            

            return View();
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