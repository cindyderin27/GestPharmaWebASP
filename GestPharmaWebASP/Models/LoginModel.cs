using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestPharmaWebASP.Models
{
    public class LoginModel:BaseModel
    {
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Email { get; set; }
        [Required]
        [StringLength(15, MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
       
        public string ReturnUrl { get; set; }

        public LoginModel()
        {
        }

        public LoginModel(string email, string password, string returnUrl)
        {
            Email = email;
            Password = password;
            ReturnUrl = returnUrl;
        }
    }
}