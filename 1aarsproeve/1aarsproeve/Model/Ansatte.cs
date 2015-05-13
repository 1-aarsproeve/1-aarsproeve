using System;
using System.Collections.Generic;

namespace _1aarsproeve.Model
{
    /// <summary>
    /// Ansatte klasse der holder styr på systemets brugere
    /// </summary>
    public partial class Ansatte
    {
        private string _navn;
        private string _brugernavn;
        private string _password;
        private string _postnummer;
        private string _adresse;
        private string _mobil;
        private string _email;

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
        /// Default konstruktør
        /// </summary>
        public Ansatte()
        {
        }
        /// <summary>
        /// Checker password
        /// </summary>
        /// <param name="password">Tager password some parameter</param>
        public static void CheckPassword(string password)
        {
            if (string.IsNullOrEmpty(password) || password.Length > 30 || password.Length < 6)
            {
                throw new ArgumentException("password er forkert");
            }
        }
        /// <summary>
        /// Checker brugernavn
        /// </summary>
        /// <param name="brugernavn">Tager brugernavn som parameter</param>
        public static void CheckBrugernavn(string brugernavn)
        {
            if (string.IsNullOrEmpty(brugernavn) || brugernavn.Length > 30)
            {
                throw new ArgumentException("brugernavn er forkert");
            }

        }
        /// <summary>
        /// Checker navn
        /// </summary>
        /// <param name="navn">Tager navn som parameter</param>
        public static void CheckNavn(string navn)
        {
            if (navn.Length == 0 || navn.Length > 30 || navn.Length < 2)
            {
                throw new ArgumentException("navn er forkert");
            }
        }
        /// <summary>
        /// Checker eamil
        /// </summary>
        /// <param name="email">Tager email som parameter</param>
        public static void CheckEmail(string email)
        {
            if (email == null || email.Length > 20 || email.Length < 6)
            {
                throw new ArgumentException("email er forkert");
            }

        }
        /// <summary>
        /// Checker adresse
        /// </summary>
        /// <param name="adresse">Tager adresse som parameter</param>
        public static void CheckAdresse(string adresse)
        {
            if (adresse == null || adresse.Length > 50 || adresse.Length < 2)
            {
                throw new ArgumentException("adresse er for kort ");
            }

        }
        /// <summary>
        /// Checker mobil
        /// </summary>
        /// <param name="mobil">Tager mobil som parameter</param>
        public static void CheckMobil(string mobil)
        {
            if (mobil == null || mobil.Length > 8 || mobil.Length < 8)
            {
                throw new ArgumentException("mobil nummer er for kort");
            }
        }
        /// <summary>
        /// Checker postnummer
        /// </summary>
        /// <param name="postnummer">Tager postnummer som parameter</param>
        public static void CheckPostnummer(string postnummer)
        {
            if (postnummer == null || postnummer.Length < 4 || postnummer.Length > 4)
            {
                throw new ArgumentException("postnummer skal være 4 tegn");
            }
        }

        /// <summary>
        /// Brugernavn property
        /// </summary>
        public string Brugernavn
        {
            get { return _brugernavn; }
            set
            {
                CheckBrugernavn(value);
                _brugernavn = value;
            }
        }


        /// <summary>
        /// Navn property
        /// </summary>
        public string Navn
        {
            get { return _navn; }
            set
            {
                CheckNavn(value);
                _navn = value;
            }
        }


        /// <summary>
        /// Password property
        /// </summary>
        public string Password
        {
            get { return _password; }
            set
            {
                CheckPassword(value);
                _password = value;
            }
        }


        /// <summary>
        /// Email property
        /// </summary>  
        public string Email
        {
            get { return _email; }
            set
            {
                CheckEmail(value);
                _email = value;
            }
        }

        /// <summary>
        /// Mobil property
        /// </summary>
        public string Mobil
        {
            get { return _mobil; }
            set
            {
                CheckMobil(value);
                _mobil = value;
            }
        }


        /// <summary>
        /// Adresse property
        /// </summary>
        public string Adresse
        {
            get { return _adresse; }
            set
            {
                CheckAdresse(value);
                _adresse = value;
            }
        }

        /// <summary>
        /// Postnummer property
        /// </summary>  
        public string Postnummer
        {
            get { return _postnummer; }
            set
            {
                CheckPostnummer(value);
                _postnummer = value;
            }
        }

        /// <summary>
        /// StillingId property
        /// </summary>
        public int StillingId { get; set; }
        /// <summary>
        /// Viser Ansatte
        /// </summary>
        /// <returns>Returnerer ToString Ansatte</returns>
        public override string ToString()
        {
            return Navn;
        }
    }
}
