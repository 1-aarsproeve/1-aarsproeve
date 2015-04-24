using System.Collections.Generic;

namespace _1aarsproeve.Model
{
    /// <summary>
    /// Ansatte klasse der holder styr systemets brugere
    /// </summary>
    public partial class Ansatte
    {
        /// <summary>
        /// Ansatte klassens konstrutkur
        /// </summary>
        /// <param name="brugernavn">Brugernavn parameter</param>
        /// <param name="navn">Navn parameter</param>
        /// <param name="password">Password parameter</param>
        /// <param name="email">Email parameter</param>
        /// <param name="mobil">Mobil parameter</param>
        /// <param name="adresse">Adresse parameter</param>
        /// <param name="postnummer">Postnummer parameter</param>
        /// <param name="stillingId">StillingId paratmeter</param>
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
        /// <summary>
        /// Brugernavn property
        /// </summary>
        public string Brugernavn { get; set; }
        /// <summary>
        /// Navn property
        /// </summary>
        public string Navn { get; set; }
        /// <summary>
        /// Password property
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Email property
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Mobil property
        /// </summary>
        public string Mobil { get; set; }
        /// <summary>
        /// Adresse property
        /// </summary>
        public string Adresse { get; set; }
        /// <summary>
        /// Postnummer property
        /// </summary>
        public string Postnummer { get; set; }
        /// <summary>
        /// StillingId property
        /// </summary>
        public int StillingId { get; set; }
    }
}
