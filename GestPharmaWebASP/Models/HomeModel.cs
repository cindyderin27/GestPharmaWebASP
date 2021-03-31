using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestPharmaWebASP.Models
{
    public class HomeModel:BaseModel
    {
        public string Firstname { get; set; }

        public HomeModel()
        {
        }

        public HomeModel(string username)
        {
            Firstname = username;
        }
    }
}