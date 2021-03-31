using System.Collections.Generic;

namespace GestPharmaWebASP.Models
{
    public class CategoryModel
    {
        public int IdCategory { get; set; }
        public string MatriculeCategory { get; set; }
        public string NomCategory { get; set; }

        public CategoryModel()
        {
            this.Medicaments = new HashSet<MedicamentModel>();
        }

        public CategoryModel(int idCategory, string matriculeCategory, string nomCategory)
        {
            IdCategory = idCategory;
            MatriculeCategory = matriculeCategory;
            NomCategory = nomCategory;
        }
        public virtual ICollection<MedicamentModel> Medicaments { get; set; }
    }
}