using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProductManagement.Entity;
using WebProductManagement.Models;

namespace WebProductManagement.Controllers
{
    public class CategoryController : Controller
    {
        DbContext db = new DbContext();
        // GET: Category
        public ActionResult Index()
        {
            return View(db.Category().ToList());
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create( Category category)
        {
            if(category != null)
            {
                DbContext.categoryId++;
                category.Id = DbContext.categoryId;
                    db.Category().Add(category);
            }
            return RedirectToAction("Index");
        }
    }
}