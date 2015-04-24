using System;
using System.ComponentModel.DataAnnotations;

namespace _1aarsproeve.Model
{
    /// <summary>
    /// Hovedmenuview klasse
    /// </summary>
    public partial class HovedmenuView
    {
        /// <summary>
        /// beskedID property
        /// </summary>
        public int BeskedId { get; set; }

        /// <summary>
        /// Overskrift property
        /// </summary>
        public string Overskrift { get; set; }

        /// <summary>
        /// Dato property
        /// </summary>
        public DateTime Dato { get; set; }

        /// <summary>
        /// beskrivelse property
        /// </summary>
        public string Beskrivelse { get; set; }

        /// <summary>
        /// udloebsdato property
        /// </summary>
        public DateTime Udloebsdato { get; set; }

        /// <summary>
        /// Brugernavn property
        /// </summary>
        public string Brugernavn { get; set; }

        /// <summary>
        /// Navn property
        /// </summary>
        public string Navn { get; set; }
    }
}
