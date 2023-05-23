using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Product
    {

        [Key]
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductImage { get; set; }
        public Nullable<int> ProductPrice { get; set; }
        public Nullable<int> BrandID { get; set; }
        public Nullable<int> CatID { get; set; }
        public string ProductDescription { get; set; }
        public Nullable<int> ProductQuantity { get; set; }
        public string ProductStatus { get; set; }
        public virtual Brand Brand { get; set; }
        public virtual Category Category { get; set; }
    }
}