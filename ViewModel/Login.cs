using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.ViewModel
{
    public class Login
    {
        [Required(ErrorMessage = "User không được để trống.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Password không được để trống.")]
        public string Password { get; set; }
    }
}