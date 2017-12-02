using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Homework8.Models.ViewModels
{
    public class jsonModel
    {
        public string ArtistName { get; set; }
        public DateTime ArtistDOB { get; set; }
        public string Artwork { get; set; }
        public string Genre { get; set; }
        public string Class { get; set; }
    }
}