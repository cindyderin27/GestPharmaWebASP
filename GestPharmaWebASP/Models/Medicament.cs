using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
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
        public DateTime? DateFabrication { get; set; }
        public DateTime? DatePeremption { get; set; }
        public string Composition { get; set; }
        public Categorie Categorie { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }
        
        [JsonIgnore]
        public HttpPostedFileBase Image { get; set; }
        public string Photo { get; set; }
        public int IdCategorie { get; set; }
        public int QuantiteStock { get; set; }
        

        //public virtual ICollection<MedicamentCommander> MedicamentCommanders { get; set; }
        // public int IdMedicament { get; set; }
        // [MaxLength(5)]
        // public string ReferenceMedicament { get; set; }
        // public string Designation { get; set; }
        // public double Prix { get; set; }
        // [DataType(DataType.Date)]
        // public DateTime? DateFabrication { get; set; }
        //// public DateTime?DatePeremption { get; set; }
        // public string Composition { get; set; }
        // public int IdCategorie { get; set; }
        // public int QuantiteStock { get; set; }
        // public Categorie Categorie { get; set; }
        // public IEnumerable<SelectListItem> Categories { get; set; }
        // public string Photo { get; set; }

        // [JsonIgnore]
        // public HttpPostedFileBase Image { get; set; }
        // public Medicament()
        // {
        // }

        // //public ICollection<MedicamentCommander> MedicamentCommanders { get; set; }

    }
}
