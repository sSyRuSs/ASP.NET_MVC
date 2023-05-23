using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Filters;

namespace WebApplication1.Controllers
{
    public class ProductsController : Controller
    {
        CompanyDBContext db =new CompanyDBContext();
        // GET: Product
        [MyAuthenFilter]
        public ActionResult Index(string SortColumn = "ProductId", string IconClass = "fa-sort-asc", int page = 1)
        {
            List<Product> products = db.products.ToList();
            ViewBag.Brands = db.brands.ToList();
            ViewBag.Categories = db.categories.ToList();

            int NoOfRecordPerPage = 5;
            int NoOfPage = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(products.Count) / Convert.ToDouble(NoOfRecordPerPage)));
            int NoOfRecordToSkip = (page - 1) * NoOfRecordPerPage;
            ViewBag.Page = page;
            ViewBag.NoOfPage = NoOfPage;
            products = products.Skip(NoOfRecordToSkip).Take(NoOfRecordPerPage).ToList();
            return View(products);
        }
        public ActionResult Details(int id) 
        {
            Product products = db.products.Where(t => t.ProductID == id).FirstOrDefault();
            
            return View(products);
        }
    }
}