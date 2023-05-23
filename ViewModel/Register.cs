using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.ViewModel
{
    public class Register
    {
        [Required(ErrorMessage ="User không được để trống.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email không được để trống.")]
        [EmailAddress(ErrorMessage ="Không đúng định dạng.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password không được để trống.")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Password không được để trống.")]
        [Compare("Password",ErrorMessage ="Không khớp.")]
        public string ConfirmPassword { get; set; }
    }
}