using System;

namespace _1aarsproeve.Model
{
    /// <summary>
    /// Besked klasse der holder styr på fællesbeskeder
    /// </summary>
    public partial class Beskeder
    {
        /// <summary>
        /// Konstruktør til Beskeder klassen
        /// </summary>
        /// <param name="beskedId">beskedId parameter</param>
        /// <param name="overskrift">overskrift parameter</param>
        /// <param name="dato">dato parameter</param>
        /// <param name="beskrivelse">beskrivelse parameter</param>
        /// <param name="udloebsdato">udloebsdato parameter</param>
        /// <param name="brugernavn">brugernavn parameter</param>
        public Beskeder(int beskedId, string overskrift, DateTime dato, string beskrivelse, DateTime udloebsdato, string brugernavn)
        {
            BeskedId = beskedId;
            Overskrift = overskrift;
            Dato = dato;
            Beskrivelse = beskrivelse;
            Udloebsdato = udloebsdato;
            Brugernavn = brugernavn;
        }
        /// <summary>
        /// Default konstruktør
        /// </summary>
        public Beskeder()
        {
        }

        public void CheckBeskrivelse(string beskrivelse)
        {
            if (string.IsNullOrEmpty(beskrivelse) || beskrivelse.Length < 10 || beskrivelse.Length > 200)
            {
                throw new ArgumentException(" fejl i beskrivelse ");
            }
        }

        public void CheckBrugernavn(string brugernavn)
        {
            if (string.IsNullOrEmpty(brugernavn) || brugernavn.Length > 30)
            {
                throw new ArgumentException("brugernavn er forkert");
            }

        }

        public void CheckOverskrift(string overskrift)
        {
            if (string.IsNullOrEmpty(overskrift) || overskrift.Length < 10 || overskrift.Length > 50)
            {
                throw new ArgumentException("fejl i overskrift");
            }
        }
        /// <summary>
        /// BeskedId Property
        /// </summary>
        public int BeskedId { get; set; }
        private string _overskrift;
        /// <summary>
        /// Overskrift Property
        /// </summary>
        public string Overskrift
        {
            get { return _overskrift; }
            set
            {
                CheckOverskrift(value);
                _overskrift = value;
            }
        }

        /// <summary>
        /// Dato Property
        /// </summary>
        public DateTime Dato { get; set; }
        private string _beskrivelse;
        /// <summary>
        /// Beskrivelse Property
        /// </summary>
        public string Beskrivelse
        {
            get { return _beskrivelse; }
            set
            {
                CheckBeskrivelse(value);
                _beskrivelse = value;
            }
        }

        /// <summary>
        /// Udloebsdato Property
        /// </summary>
        public DateTime Udloebsdato { get; set; }
        private string _brugernavn;
        /// <summary>
        /// Brugernavn Property
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
    }
}