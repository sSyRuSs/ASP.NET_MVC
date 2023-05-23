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
    public class AdminController : Controller
    {
        
        CompanyDBContext db = new CompanyDBContext();
        // GET: Admin
        public ActionResult Index(string search="",string SortColumn = "ProductId", string IconClass = "fa-sort-asc", int page = 1)
        {
            //List<Product> products = db.products.ToList();
            List<Product> products = db.products.Where(x => x.ProductName.Contains(search)).ToList();

            ViewBag.SortColumn = SortColumn;
            ViewBag.IconClass = IconClass;
            if (SortColumn == "ProductID")
            {
                if (IconClass == "fa-sort-asc")
                {
                    products = products.OrderBy(row => row.ProductID).ToList();
                }
                else
                {
                    products = products.OrderByDescending(row => row.ProductID).ToList();
                }
            }
            else if (SortColumn == "ProductName")
            {
                if (IconClass == "fa-sort-asc")
                {
                    products = products.OrderBy(row => row.ProductName).ToList();
                }
                else
                {
                    products = products.OrderByDescending(row => row.ProductName).ToList();
                }
            }
            else if (SortColumn == "ProductPrice")
            {
                if (IconClass == "fa-sort-asc")
                {
                    products = products.OrderBy(row => row.ProductPrice).ToList();
                }
                else
                {
                    products = products.OrderByDescending(row => row.ProductPrice).ToList();
                }
            }
            else if (SortColumn == "CatId")
            {
                if (IconClass == "fa-sort-asc")
                {
                    products = products.OrderBy(row => row.CatID).ToList();
                }
                else
                {
                    products = products.OrderByDescending(row => row.CatID).ToList();
                }
            }
            int NoOfRecordPerPage = 3;
            int NoOfPage = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(products.Count) / Convert.ToDouble(NoOfRecordPerPage)));
            int NoOfRecordToSkip = (page - 1) * NoOfRecordPerPage;
            ViewBag.Page = page;
            ViewBag.NoOfPage = NoOfPage;
            products = products.Skip(NoOfRecordToSkip).Take(NoOfRecordPerPage).ToList();

            return View(products);
        }
        [HttpGet]
        public ActionResult AddItem()
        {
            ViewBag.Brands = db.brands.ToList();
            ViewBag.Categories = db.categories.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult AddItem(Product pro, HttpPostedFileBase file)
        {
            try
            {
                if (file != null && file.ContentLength > 0)
                {
                    string filename = Path.GetFileName(file.FileName);
                    pro.ProductImage = filename;
                    string path = Path.Combine(Server.MapPath("~/Image"), filename);
                    file.SaveAs(path);
                    ViewBag.Message = "Create Succesfully";
                }
                db.products.Add(pro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        public ActionResult EditItem(int id)
        {
            ViewBag.Brands = db.brands.ToList();
            ViewBag.Categories = db.categories.ToList();
            Product products = db.products.Where(row => row.ProductID == id).FirstOrDefault();
            return View(products);

        }
        [HttpPost]
        public ActionResult EditItem(Product pro)
        {
            Product products = db.products.Where(row => row.ProductID == pro.ProductID).FirstOrDefault();
            //products.ProductId = pro.ProductId;
            products.ProductName = pro.ProductName;
            products.ProductImage = pro.ProductImage;
            products.ProductPrice = pro.ProductPrice;
            products.BrandID = pro.BrandID;
            products.CatID = pro.CatID;
            products.ProductDescription = pro.ProductDescription;
            products.ProductQuantity = pro.ProductQuantity;
            products.ProductStatus = pro.ProductStatus;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            Product products = db.products.Where(row => row.ProductID == id).FirstOrDefault();
            return View(products);
        }
        [HttpPost]
        public ActionResult Delete(int id, Product pro)
        {
            Product products = db.products.Where(row => row.ProductID == id).FirstOrDefault();
            db.products.Remove(products);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }

}
