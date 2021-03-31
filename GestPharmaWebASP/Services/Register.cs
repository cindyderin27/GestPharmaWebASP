using GestPharmaWebASP.Services.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestPharmaWebASP.Services
{
    public class Register
    {
        public RegisterCommand Command { get; private set; }

        public Register(RegisterCommand command)
        {
            Command = command;
        }



        public User ExecuteRegister()
        {
            Sql sql = new Sql("SqlServer");
            var parametres = new Sql.Parameter[]
             {
                new Sql.Parameter("@IdPharmacien", DBNull.Value, System.Data.DbType.Int32, System.Data.ParameterDirection.InputOutput),
                new Sql.Parameter("@Email", Command.Email, System.Data.DbType.String),
                new Sql.Parameter("@Password", Command.Password, System.Data.DbType.String),
                new Sql.Parameter("@Firstname", Command.Firstname, System.Data.DbType.String),
                new Sql.Parameter("@Role", Command.Role, System.Data.DbType.Int32),
                new Sql.Parameter("@DateCreate", Command.DateCreate,System.Data.DbType.DateTime),
                new Sql.Parameter("@Country", Command.Country, System.Data.DbType.String)
             }
             ;
            
            sql.Execute("Sp_UserPharmacien_Insert", parametres, true);
            var id = int.Parse(parametres[0].Value.ToString());
            var reader = sql.Read("Sp_Pharmacien_SelectList", new Sql.Parameter[]
            {
                new Sql.Parameter("@IdPharmacien",DBNull.Value, System.Data.DbType.Int32),
                new Sql.Parameter("@Email", DBNull.Value),
                new Sql.Parameter("@Password", DBNull.Value),
                new Sql.Parameter("@Firstname", DBNull.Value),
                new Sql.Parameter("@Role", DBNull.Value),
                new Sql.Parameter("@DateCreate", DBNull.Value),
                new Sql.Parameter("@Country", DBNull.Value)
            },
            true);
            if (reader != null)
            {
                while (reader.Read())
                {
                    return new User
                        (
                       int.Parse(reader["IdPharmacien"].ToString()),
                        reader["Password"].ToString(),
                        reader["Email"].ToString(),
                        reader["Firstname"].ToString(),
                        reader["Country"].ToString(),
                        DateTime.Parse(reader["DateCreate"].ToString()),
                        (User.RoleOption)int.Parse(reader["Role"].ToString())

                        );
                }
                reader.Close();
            }
            return null;
        }
    }
    public class RegisterCommand
    {

        public string Email { get; set; }
        public string Password { get; set; }
        public string Firstname { get; set; }
        public User.RoleOption Role { get; set; }
        public DateTime DateCreate { get; set; }
        public string Country { get; set; }

        public RegisterCommand()
        {
        }

        public RegisterCommand(string email, string password, string firstname, 
            User.RoleOption role, DateTime dateCreate, string country)
        {
            Email = email;
            Password = password;
            Firstname = firstname;
            Role = role;
            DateCreate = dateCreate;
            Country = country;
        }
    }
}