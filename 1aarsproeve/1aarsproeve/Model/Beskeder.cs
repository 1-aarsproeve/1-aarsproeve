using System;

namespace _1aarsproeve.Model
{
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

        public Beskeder()
        {
        }

        public void Checkbeskrivelse(string beskrivelse)
        {
            if (string.IsNullOrEmpty(beskrivelse) || beskrivelse.Length < 9 || beskrivelse.Length > 200)
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

        public void Checkoverskrift(string overskrift)
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

        /// <summary>
        /// Overskrift Property
        /// </summary>
        private string _overskrift;

        public string Overskrift
        {
            get { return _overskrift; }
            set
            {
                Checkoverskrift(value);
                _overskrift = value;
            }
        }

        /// <summary>
        /// Dato Property
        /// </summary>
        public DateTime Dato { get; set; }

        /// <summary>
        /// Beskrivelse Property
        /// </summary>
        private string _beskrivelse;

        public string Beskrivelse
        {
            get { return _beskrivelse; }
            set
            {
                Checkbeskrivelse(value);
                _beskrivelse = value;
            }
        }

        /// <summary>
        /// Udloebsdato Property
        /// </summary>
        public DateTime Udloebsdato { get; set; }

        /// <summary>
        /// Brugernavn Property
        /// </summary>
        private string _brugernavn;

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