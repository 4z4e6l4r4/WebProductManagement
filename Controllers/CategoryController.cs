using System;
using System.Collections.Generic;
using System.IO;
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
            return View(db.Category().Where(x =>!x.IsDelete).ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Category category, HttpPostedFileBase Image)
        {
            if (category != null)
            {
                DbContext.categoryId++;
                category.Id = DbContext.categoryId;

                string ImagePath = "";
                string ImageName = "";
                if (Image!=null && Image.ContentLength > 0)
                {
                    ImageName=Guid.NewGuid()+"-"+Path.GetFileName(Image.FileName);

                    ImagePath = Path.Combine(Server.MapPath("~/Content/assets/images"), ImageName);
                    Image.SaveAs(ImagePath);

                    category.Image = ImageName;
                }
                db.Category().Add(category);
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id=0)
        {
            var category = db.Category().FirstOrDefault(c => c.Id == id && !c.IsDelete);
            if(category != null)
            {
                return View(category);
                            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete(int id, bool confirm)
        {
            var category = db.Category().FirstOrDefault(c => c.Id == id && !c.IsDelete);
            if (category != null && confirm)
            {
                category.IsDelete = true;
                return RedirectToAction("Index");
                            }
            return RedirectToAction("Delete", id);

        }

        public ActionResult Edit(int id = 0)
        {
            var category = db.Category().FirstOrDefault(c => c.Id == id && !c.IsDelete);
            if (category != null)
            {
                return View(category);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        //BURADA EKSİĞİN VAR TAMAMLA
        public ActionResult Edit(Category _category, HttpPostedFileBase Image)
        {
            var category = db.Category().FirstOrDefault(x => x.Id == _category.Id);
            if (category != null && !String.IsNullOrWhiteSpace(_category.Name))
            {
                string ImagePath = "";
                string ImageName = "";

                if (Image != null && Image.ContentLength > 0)
                {
                    ImageName = Guid.NewGuid() + "-" + Path.GetFileName(Image.FileName);
                    ImageName = category.Image;
                    ImagePath = Path.Combine(Server.MapPath("~/Content/assets/images"), ImageName);
                    Image.SaveAs(ImagePath);
                    category.Image = ImageName;
                }
                category.Name = _category.Name;
                category.Description = _category.Description;
                category.IsStatus = _category.IsStatus;
                TempData["Message"] = "1";
                return View(category);
            }
            else
            {
                TempData["Message"] = "0";
                return RedirectToAction("Edit", _category.Id);
            }

        }



        //
    }
}