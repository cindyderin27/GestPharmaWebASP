using System;
using System.ComponentModel.DataAnnotations;

namespace GestPharmaWebASP.Models
{
    public class RegisterModel:BaseModel
    {
        [Required]
        [StringLength(50)]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Invalid email address")]
        public string Email { get; set; }
        [Required]
        [StringLength(15, MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        //[Compare(nameof(Password))]
        //public string ConfirmPassword { get; set; }

        [StringLength(100, MinimumLength = 2)]
        public string Firstname { get; set; }
        public string Country { get; set; }
        public DateTime DateCreate { get; set; }

        public RegisterModel()
        {
        }

        public RegisterModel(string email, string password, string firstname, string country, DateTime dateCreate)
        {
            Email = email;
            Password = password;
            Firstname = firstname;
            Country = country;
            DateCreate = dateCreate;
        }
    }
}
