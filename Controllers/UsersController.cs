using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Identity;
using WebApplication1.Models;
using WebApplication1.Filters;

namespace WebApplication1.Controllers
{
    [AdminAuthorization]
    public class UsersController : Controller
    {
        AppDBContext db = new AppDBContext();
        // GET: User
        public ActionResult Index()
        {
            List<AppUser> users = db.Users.ToList();
            return View(users);
        }
    }
}