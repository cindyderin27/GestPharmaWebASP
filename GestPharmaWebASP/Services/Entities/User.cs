using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestPharmaWebASP.Services.Entities
{

    public class User
    {



        public enum RoleOption
        {
            Administrateur
        }
        public int IdPharmacien { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public string Firstname { get; set; }
        public string Country { get; set; }
        public DateTime DateCreate { get; set; }

        public RoleOption Role { get; set; }

        public User()
        {
        }

        public User(int idPharmacien, string password, string email, string firstname, string country, DateTime dateCreate, RoleOption role)
        {
            IdPharmacien = idPharmacien;
            Password = password;
            Email = email;
            Firstname = firstname;
            Country = country;
            DateCreate = dateCreate;
            Role = role;
        }
    }
}