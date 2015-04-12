using System.Collections.Generic;

namespace _1aarsproeve.Model
{
    public partial class Ansatte
    {
        public Ansatte(string brugernavn, string navn, string password, string email, string mobil, string adresse, string postnummer, int stillingId)
        {
            Brugernavn = brugernavn;
            Navn = navn;
            Password = password;
            Email = email;
            Mobil = mobil;
            Adresse = adresse;
            Postnummer = postnummer;
            StillingId = stillingId;
        }

        public string Brugernavn { get; set; }
        public string Navn { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Mobil { get; set; }
        public string Adresse { get; set; }
        public string Postnummer { get; set; }
        public int StillingId { get; set; }
    }
}
