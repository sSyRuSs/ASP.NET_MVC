using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace WebApplication1.Identity
{
    public class AppUser : IdentityUser
    {
        public DateTime? Birth { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
    }
}