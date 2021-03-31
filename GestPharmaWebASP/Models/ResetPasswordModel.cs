using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestPharmaWebASP.Models
{
    public class ResetPasswordModel:BaseModel
    {
        public string Password { get; set; }
        public ResetPasswordModel()
        {

        }

        public ResetPasswordModel(string password)
        {
            Password = password;
        }
    }
}