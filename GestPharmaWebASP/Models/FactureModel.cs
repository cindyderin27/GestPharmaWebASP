using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestPharmaWebASP.Models
{
    public class FactureModel:PaymentModel
    {
        public string Reference { get; set; }
        public string NameDrug { get; set; }
        public DateTime DateFabrication { get; set; }
        public DateTime DatePeremption { get; set; }
        public float Prix { get; set; }
        public string NomPharmacien { get; set; }
        public int Quantite { get; set; }

        public FactureModel()
        {

        }
    }
}