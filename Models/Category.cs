using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;


namespace WebApplication1.Models
{
    public class Category
    {
        [Key]
        public int CatID { get; set; }
        public string CatName { get; set; }
    }
}