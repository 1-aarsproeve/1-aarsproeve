
using System;
using System.ComponentModel.DataAnnotations;

namespace _1aarsproeve.Model
{
    /// <summary>
    /// Hovedmenuview klasse
    /// </summary>
    public partial class HovedmenuView
    {
        public HovedmenuView(string overskrift, DateTime dato, string beskrivelse, DateTime udleobsdato, string brugernavn)
        {
            Overskrift = overskrift;
            Dato = dato;
            Beskrivelse = beskrivelse;
            Udloebsdato = udleobsdato;
            Brugernavn = brugernavn;
        }
        public static void CheckBeskrivelse(string beskrivelse)
        {
            if (string.IsNullOrEmpty(beskrivelse) || beskrivelse.Length < 10 || beskrivelse.Length > 200)
            {
                throw new ArgumentException(" fejl i beskrivelse ");
            }
        }

        public static void CheckOverskrift(string overskrift)
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

        /// <summary>
        /// Brugernavn Property
        /// </summary>
        public string Brugernavn { get; set; }

        /// <summary>
        /// Navn property
        /// </summary>
        public string Navn { get; set; }
    }
}
