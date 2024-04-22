namespace RestoManager_X.Models.RestosModel
{
    public class Proprietaire
    {
        public int Numero { get; set; }
        public string Nom { get; set; }
        public string Email { get; set; }
        public string Gsm { get; set; }
        public List<Restaurant> LesRestos { get; set; }

        public Proprietaire()
        {
            LesRestos = new List<Restaurant>();
        }


    }
}
