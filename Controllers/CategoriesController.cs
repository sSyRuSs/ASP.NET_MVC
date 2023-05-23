using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using System.Web.Services.Protocols;
using WebApplication1.Filters;
namespace WebApplication1.Controllers
{
    [AdminAuthorization]
    public class CategoriesController : Controller
    {
        CompanyDBContext db = new CompanyDBContext();
        // GET: Categories
        public ActionResult Index()
        {

            List<Category> categories = db.categories.ToList();
            return View(categories);
        }
        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(Category categories)
        {
            db.categories.Add(categories);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult EditCategory(int id)
        {
            Category categories = db.categories.Where(row => row.CatID == id).FirstOrDefault();
            return View(categories);

        }
        [HttpPost]
        public ActionResult EditCategory(Category cat)
        {
            Category categories = db.categories.Where(row => row.CatID == cat.CatID).FirstOrDefault();
            //products.ProductId = pro.ProductId;
            cat.CatName = cat.CatName;
            return RedirectToAction("Index");

        }
        public ActionResult Delete(int id)
        {
            Category categories = db.categories.Where(row => row.CatID == id).FirstOrDefault();
            return View(categories);
        }
        [HttpPost]
        public ActionResult Delete(int id, Category category)
        {
            Category categories = db.categories.Where(row => row.CatID == id).FirstOrDefault();
            db.categories.Remove(categories);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}