using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestPharmaWebASP.Models
{
    public class Medicament
    {
        public int IdMedicament { get; set; }
        public string ReferenceMedicament { get; set; }
        public string Designation { get; set; }
        public double Prix { get; set; }
        public System.DateTime DateFabrication { get; set; }
        public System.DateTime DatePeremption { get; set; }
        public string Composition { get; set; }
        public string Photo { get; set; }
        public int IdCategorie { get; set; }
        public int QuantiteStock { get; set; }

        public Categorie Categorie { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }

        public Medicament()
        {
        }

        //public ICollection<MedicamentCommander> MedicamentCommanders { get; set; }






    }
}
