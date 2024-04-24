using System.ComponentModel.DataAnnotations;

namespace RestoManager_X.Models.RestosModel
{
    public class Avis
    {
        public int CodeAvis { get; set; }

        [Required]
        public string NomPersonne { get; set; }

        [Range(1, 5, ErrorMessage = "La note doit être comprise entre 1 et 5.")]
        public int Note { get; set; }

        public string Commentaire { get; set; }

        public int NumResto { get; set; }
        // Propriété de navigation vers Restaurant
        public virtual Restaurant LeResto { get; set; }
    }
}
