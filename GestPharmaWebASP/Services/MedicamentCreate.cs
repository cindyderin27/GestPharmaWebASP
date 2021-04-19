//using GestPharmaWebASP.Models;
//using GestPharmaWebASP.Services.Entities;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;

//namespace GestPharmaWebASP.Services
//{
//    public class MedicamentCreate
//    {
//        public MedicamentCommand Command { get; private set; }

//        public MedicamentCreate(MedicamentCommand command)
//        {
//            Command = command;
//        }



//        public Medicament ExecuteCreateMed()
//        {
//            Sql sql = new Sql("SqlServer");
//            var parametres = new Sql.Parameter[]
//             {
//                new Sql.Parameter("@IdDrug", DBNull.Value, System.Data.DbType.Int32, System.Data.ParameterDirection.InputOutput),
//                new Sql.Parameter("@Reference", Command.Reference, System.Data.DbType.String),
//                new Sql.Parameter("@NameDrug", Command.NameDrug, System.Data.DbType.String),
//                new Sql.Parameter("@DateFabrication", Command.DateFabrication, System.Data.DbType.DateTime),
//                new Sql.Parameter("@DatePeremption",Command.DatePeremption,System.Data.DbType.DateTime),
//                new Sql.Parameter("@Prix", Command.Prix, System.Data.DbType.Double),
//                new Sql.Parameter("@Composition", Command.Composition,System.Data.DbType.String),
//                new Sql.Parameter("@IdCategory", Command.IdCategory, System.Data.DbType.Int32)
//             }
//             ;

//            sql.Execute("Sp_Medicament_Insert", parametres, true);
//            var id = int.Parse(parametres[0].Value.ToString());
//            var reader = sql.Read("Sp_Medicaments_Select", new Sql.Parameter[]
//            {
//                new Sql.Parameter("@IdDrug", DBNull.Value, System.Data.DbType.Int32, System.Data.ParameterDirection.InputOutput),
//                new Sql.Parameter("@Reference", Command.Reference, System.Data.DbType.String),
//                new Sql.Parameter("@NameDrug", Command.NameDrug, System.Data.DbType.String),
//                new Sql.Parameter("@DateFabrication", Command.DateFabrication, System.Data.DbType.DateTime),
//                new Sql.Parameter("@DatePeremption",Command.DatePeremption,System.Data.DbType.DateTime),
//                new Sql.Parameter("@Prix", Command.Prix, System.Data.DbType.Double),
//                new Sql.Parameter("@Composition", Command.Composition,System.Data.DbType.String),
//                new Sql.Parameter("@IdCategory", Command.IdCategory, System.Data.DbType.Int32)
//            },
//            true);
//            if (reader != null)
//            {
//                while (reader.Read())
//                {
//                    return new Medicament
//                        (
//                        int.Parse(reader["IdDrug"].ToString()),
//                        reader["Reference"].ToString(),
//                        reader["NameDrug"].ToString(),
//                        DateTime.Parse(reader["DateFabrication"].ToString()),
//                        DateTime.Parse(reader["DatePeremption"].ToString()),
//                        float.Parse(reader["Prix"].ToString()),
//                        reader["Composition"].ToString(),
//                        int.Parse(reader["IdCategory"].ToString())

//                        );
//                }
//                reader.Close();
//            }
//            return null;
//        }
//    }
//    public class MedicamentCommand
//    {

//        public int IdDrug { get; set; }
//        public string Reference { get; set; }
//        public string NameDrug { get; set; }
//        public DateTime DateFabrication { get; set; }
//        public DateTime DatePeremption { get; set; }
//        public double Prix { get; set; }
//        public string Composition { get; set; }
//        public int IdCategory { get; set; }

//        public virtual Categorie Category { get; set; }

//        public MedicamentCommand()
//        {
//        }

//        public MedicamentCommand(int idDrug, string reference, string nameDrug,
//            DateTime dateFabrication, DateTime datePeremption, double prix,
//            string composition, int idCategory)
//        {
//            IdDrug = idDrug;
//            Reference = reference;
//            NameDrug = nameDrug;
//            DateFabrication = dateFabrication;
//            DatePeremption = datePeremption;
//            Prix = prix;
//            Composition = composition;
//            IdCategory = idCategory;

//        }
//    }
//}
