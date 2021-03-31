using GestPharmaWebASP.Services.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestPharmaWebASP.Services
{
    public class Connection
    {
        public ConnectionCommand Command { get; private set; }

        public Connection(ConnectionCommand command)
        {
            Command = command;
        }

        public User Execute()
        {
            Sql sql = new Sql("SqlServer");
            var reader = sql.Read("Sp_UserPharmacien_Select", new Sql.Parameter[]
             { 
                new Sql.Parameter("@Email", Command.Email, System.Data.DbType.String),
                new Sql.Parameter("@Password", Command.Password, System.Data.DbType.String)
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


    public class ConnectionCommand
    {
       public string Email { get; set; }
        public string Password { get; set; }


        public ConnectionCommand()
        {
        }

        public ConnectionCommand(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }

}