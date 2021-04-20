using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestPharmaWebASP.Models
{
    public class Categorie
    {
        public int IdCategorie { get; set; }
        public string ReferenceCategorie { get; set; }
        public string NomCategorie { get; set; }
        public double Taxe { get; set; }
        public IEnumerable<SelectListItem> Medicaments { get; set; }

        //public  IEnumerable<Medicament>  { get; set; }

        public Categorie()
        {
        }
    }
}