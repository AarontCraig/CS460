using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HW6.Models.ViewModels
{
    public class ChosenCategory
    {
        public IEnumerable<ProductCategory> ProductCategories { get; set; }
        public IEnumerable<Product> ProductSubcategories { get; set; }
        public string PageTitle { get; set; }
        public IEnumerable<ProductProductPhoto> ProductPhotos { get; set; }
        public IEnumerable<ProductReview> ProductReviews { get; set; }
    }
}