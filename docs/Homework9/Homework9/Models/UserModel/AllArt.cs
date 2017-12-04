using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Homework9.Models.UserModel
{
    public class AllArt
    {
        public IEnumerable<ARTIST> ArtistList { get; set; }
        public IEnumerable<ARTWORK> ArtworkList { get; set; }
        public IEnumerable<CLASSIFICATION> ClassificationList { get; set; }
        public IEnumerable<GENRE> GenreList { get; set; }
    }
}