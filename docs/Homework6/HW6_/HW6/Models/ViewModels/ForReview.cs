using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HW6.Models.ViewModels
{
    public class ForReview
    {
        public IEnumerable<ProductCategory> ProductCategories { get; set; }
        public Product SpecificProduct { get; set; }
    }
}