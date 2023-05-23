using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WebApplication1.Models
{
    public class CompanyDBContext:DbContext
    {
        public CompanyDBContext(): base("MyConnectionString") { }
        public DbSet<Brand> brands { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Product> products { get; set; }
    }
}