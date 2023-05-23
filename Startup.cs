using Microsoft.Owin;
using Owin;
using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security.Cookies;
using Microsoft.AspNet.Identity.EntityFramework;
using WebApplication1.Identity;

[assembly: OwinStartup(typeof(WebApplication1.Startup))]

namespace WebApplication1
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions()
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login")
            });
            this.CreateRolesAndUsers();
        }

        public void CreateRolesAndUsers()
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new AppDBContext()));
            var appDBContext = new AppDBContext();
            var appUserStore = new AppUserStore(appDBContext);
            var userManager = new AppUserManager(appUserStore);
            if(!roleManager.RoleExists("Admin"))
            {
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);
            }

            if(userManager.FindByName("admin")==null)
            {
                var user = new AppUser { };
                user.UserName= "admin";
                user.Email= "admin@gmail.com";
                string userPwd = "123456789";

                var chkUser = userManager.Create(user, userPwd);
                if(chkUser.Succeeded) 
                {
                    userManager.AddToRole(user.Id, "Admin");
                }
            }
            if (!roleManager.RoleExists("Customer"))
            {
                var role = new IdentityRole();
                role.Name = "Customer";
                roleManager.Create(role);
            }
        }
    }
}
