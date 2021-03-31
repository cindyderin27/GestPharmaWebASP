using GestPharmaWebASP.Services.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestPharmaWebASP.Services
{
    public class ResetPassword
    {
         public ResetCommand command { get; private set; }
        public ResetPassword(ResetCommand Command)
        {
            command = Command;
        }
        public User Execute()
        {
            Sql sql = new Sql("SqlServer");
            var reader = sql.Read("Sp_Pharmacien_Update", new Sql.Parameter[]
            {
                new Sql.Parameter("@Password", command.Password, System.Data.DbType.String)
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
    public class ResetCommand
    {
    
        public string Password { get; set; }
      
        public ResetCommand(string password)
        {
       
            Password = password;
           
        }

    }
    
}