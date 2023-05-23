using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.ViewModel;
using WebApplication1.Identity;
using System.Web.Helpers;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace WebApplication1.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Register rvm) 
        {
            if (ModelState.IsValid) 
            {
                var appDBContext = new AppDBContext();
                var userStore = new AppUserStore(appDBContext);
                var userManager = new AppUserManager(userStore);
                var passwHash = Crypto.HashPassword(rvm.Password);
                var user = new AppUser()
                {
                    UserName = rvm.Name,
                    Email = rvm.Email,
                    PasswordHash= passwHash,
                };
                IdentityResult identityResult = userManager.Create(user);
                if(identityResult.Succeeded)
                {
                    userManager.AddToRole(user.Id, "Customer");
                    var authenManager = HttpContext.GetOwinContext().Authentication;
                    var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                    authenManager.SignIn(new AuthenticationProperties(), userIdentity);
                }
                return RedirectToAction("Login", "Account");
            }else
            {
                ModelState.AddModelError("New Error", "Invalid Data");
            }return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Login lvm)
        {
            var appDBContext = new AppDBContext();
            var userStore = new AppUserStore(appDBContext);
            var userManager = new AppUserManager(userStore);
            var user = userManager.Find(lvm.Name, lvm.Password);
            if (user != null)
            {
                var authenManager = HttpContext.GetOwinContext().Authentication;
                var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                authenManager.SignIn(new AuthenticationProperties(),userIdentity);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("myError", "Sai Username hoặc Password.");
                return View();
            }
            
        }

        public ActionResult LogOut() 
        {
            var authenManager = HttpContext.GetOwinContext().Authentication;
            authenManager.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}