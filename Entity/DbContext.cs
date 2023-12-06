using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebProductManagement.Models;

namespace WebProductManagement.Entity
{
    public class DbContext
    {
        public static int categoryId = 4;
        public static int productId = 8;
        private static List<Category> _categories = new List<Category>()
{
new Category{Id=1,Name="Bilgisayar",Description="Bilgisayar Kategorisi",IsStatus=true,Image="computer.png"},
new Category{Id=2,Name="Telefon",Description="Telefon Kategorisi",IsStatus=true,Image="mobile.png"},
new Category{Id=3,Name="Tablet",Description="Tablet Kategorisi",IsStatus=false,Image="tablet (1).png"},
new Category{Id=4,Name="Televizyon",Description="Televizyon Kategorisi",IsStatus=true,Image="tablet (2).png"},
};
        private static List<Product> _products = new List<Product>()
{
new Product{Id=1,Name="Asus Bilgisayar",Description="Asus Bilgisayar",CategoryId=1,Stock=12,Price=15000,IsStatus=true},
new Product{Id=2,Name="Lenovo Bilgisayar",Description="Lenovo Bilgisayar",CategoryId=1,Stock=8,Price=25000,IsStatus=true},
new Product{Id=3,Name="Iphone 15",Description="Apple Iphone 15",CategoryId=2,Stock=32,Price=75000,IsStatus=true},
new Product{Id=4,Name="Asus Rog Phone",Description="Asus Rog Phone",CategoryId=2,Stock=9,Price=33000,IsStatus=true},
new Product{Id=5,Name="Samsung Tab 7",Description="Samsung Tablet",CategoryId=3,Stock=16,Price=2000,IsStatus=false},
new Product{Id=6,Name="Ipad 12",Description="Apple Ipad 12",CategoryId=3,Stock=35,Price=21500,IsStatus=true},
new Product{Id=7,Name="Philips Curved Tv",Description="Philips Curved Televizyon",CategoryId=4,Stock=15,Price=32500,IsStatus=true},
new Product{Id=8,Name="Samsung Full Hd Tv",Description="Samsung Full Hd Televizyon",CategoryId=4,Stock=3,Price=18000,IsStatus=true},
};

        public List<Product> Products()
        {
            return _products;
        }
        public List<Category> Category()
        {
            return _categories;
        }
    }
}
