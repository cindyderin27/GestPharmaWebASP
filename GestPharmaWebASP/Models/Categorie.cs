using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestPharmaWebASP.Models
{
    public class Categorie
    {
        public int IdCategorie { get; set; }
        public string ReferenceCategorie { get; set; }
        public string NomCategorie { get; set; }
        public double Taxe { get; set; }

     
        public  IEnumerable<Medicament> Medicaments { get; set; }

        public Categorie()
        {
        }
    }
}