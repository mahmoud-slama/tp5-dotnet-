﻿namespace RestoManager_X.Models.RestosModel
{
    public class Restaurant
    {
        public int CodeResto { get; set; }
        public string NomResto { get; set; }
        public string Specialite { get; set; }
        public string Ville { get; set; }
        public string Tel { get; set; }
        public int NumProp { get; set; }


        public Proprietaire LeProprio { get; set; }

        // Propriété de navigation vers Avis (collection d'avis)
        public virtual ICollection<Avis> LesAvis { get; set; }
    }

}
