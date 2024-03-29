﻿using GestPharmaWebASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestPharmaWebASP.Services.Entities
{
    public class Medicament
    {
        public int IdDrug { get; set; }
        public string Reference { get; set; }
        public string NameDrug { get; set; }
        public System.DateTime DateFabrication { get; set; }
        public System.DateTime DatePeremption { get; set; }
        public double Prix { get; set; }
        public string Composition { get; set; }
        public int IdCategory { get; set; }

       // public virtual CategoryModel Category { get; set; }

        public Medicament()
        {
        }

        public Medicament(int idDrug, string reference, string nameDrug, DateTime dateFabrication, DateTime datePeremption, double prix,
            string composition, int idCategory)
        {
            IdDrug = idDrug;
            Reference = reference;
            NameDrug = nameDrug;
            DateFabrication = dateFabrication;
            DatePeremption = datePeremption;
            Prix = prix;
            Composition = composition;
            IdCategory = idCategory;
           
        }
    }
}