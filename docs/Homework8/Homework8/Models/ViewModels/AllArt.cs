using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Homework8.Models.ViewModels
{
    public class AllArt
    {
        public IEnumerable<ARTISTs> ArtistList { get; set; }
        public IEnumerable<ARTWORKs> ArtworkList { get; set; }
        public IEnumerable<CLASSIFICATIONs> ClassificationList { get; set; }
        public IEnumerable<GENREs> GenreList { get; set; }
    }
}