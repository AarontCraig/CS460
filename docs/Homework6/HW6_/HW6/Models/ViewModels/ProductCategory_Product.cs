using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HW6.Models.ViewModels
{
    public class ProductCategory_Product
    {
        public IEnumerable<ProductCategory> ProductCategories { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}