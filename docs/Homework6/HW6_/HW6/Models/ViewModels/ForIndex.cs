using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HW6.Models.ViewModels
{
    public class ForIndex
    {
        public IEnumerable<ProductCategory> ProductCategories { get; set; }
        public IEnumerable<ProductSubcategory> ProductSubcategories { get; set; }
    }
}