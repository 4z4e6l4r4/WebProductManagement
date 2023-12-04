using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebProductManagement.Models.AbstractModels;

namespace WebProductManagement.Models
{
    public class Product : CommonProperty
    {
        public int Stock { get; set; }
        public double Price { get; set; }
        public int CategoryId { get; set; }
    }
}