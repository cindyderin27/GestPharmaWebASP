using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestPharmaWebASP.Models
{
    public class ForgotPasswordModel:BaseModel
    {
        public string Email { get; set; }
      
        public ForgotPasswordModel()
        {

        }
        public ForgotPasswordModel(string email )
        {
            Email = email;
          
           
        }
    }
}