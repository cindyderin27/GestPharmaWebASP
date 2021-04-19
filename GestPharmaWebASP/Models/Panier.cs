using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestPharmaWebASP.Models
{
    public class Panier
    {
        public string ReferenceMedicament { get; set; }
        public string Designation { get; set; }
        public double Prix { get; set; }
        public byte[] Photo { get; set; }
        public string NomCategorie { get; set; }
    }
}