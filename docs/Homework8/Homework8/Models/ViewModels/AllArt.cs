using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Homework8.Models.ViewModels
{
    public class AllArt
    {
        public IEnumerable<ARTIST> ArtistList { get; set; }
        public IEnumerable<ARTWORK> ArtworkList { get; set; }
        public IEnumerable<CLASSIFICATION> ClassificationList { get; set; }
        public IEnumerable<GENRE> GenreList { get; set; }
    }
}