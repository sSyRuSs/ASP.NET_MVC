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
    public class BrandsController : Controller
    {
        CompanyDBContext db = new CompanyDBContext();
        // GET: Brand
        public ActionResult Index(/*string SortColumn = "ProId", string IconClass = "fa-sort-asc"*/)
        {

            List<Brand> brands = db.brands.ToList();
            return View(brands);
        }
        public ActionResult AddBrand()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddBrand(Brand brand)
        {
            db.brands.Add(brand);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //public ActionResult EditBrand(int id)
        //{
        //    Brand brands = db.brands.Where(row => row.BrandID == id).FirstOrDefault();
        //    return View(brands);
        //}
        //[HttpPost]
        //public ActionResult EditBrand(Brand bra)
        //{
        //    Brand brands = db.brands.Where(row => row.BrandID == bra.BrandID).FirstOrDefault();
        //    brands.BrandName = bra.BrandName;
        //    return RedirectToAction("Index");

        //}
        public ActionResult Delete(int id)
        {
            Brand brands = db.brands.Where(row => row.BrandID == id).FirstOrDefault();
            return View(brands);
        }
        [HttpPost]
        public ActionResult Delete(int id, Brand bra)
        {
            Brand brands = db.brands.Where(row => row.BrandID == id).FirstOrDefault();
            db.brands.Remove(brands);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}