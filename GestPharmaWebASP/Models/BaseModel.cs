using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestPharmaWebASP.Models
{
    public class BaseModel
    {
        public bool IsError { get; set; } = false;
        public string Message { get; set; } = string.Empty;
        public RegisterModel UserModel { get; set; }

        public BaseModel()
        {

        }

        public BaseModel(bool isError, string message, RegisterModel userModel)
        {
            IsError = isError;
            Message = message;
            UserModel = userModel;
        }
    }
}