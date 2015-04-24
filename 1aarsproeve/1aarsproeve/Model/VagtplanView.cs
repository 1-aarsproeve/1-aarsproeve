using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _1aarsproeve.Model
{
    /// <summary>
    /// VagtplanView Klassen, der joiner Vagter med Ansatte
    /// </summary>
    public partial class VagtplanView
    {
        /// <summary>
        /// Starttidspunkt Property
        /// </summary>
        public TimeSpan Starttidspunkt { get; set; }
        /// <summary>
        /// Sluttidspunkt Property
        /// </summary>
        public TimeSpan Sluttidspunkt { get; set; }
        /// <summary>
        /// UgedagId Property
        /// </summary>
        public int UgedagId { get; set; }
        /// <summary>
        /// Ugenummer Property
        /// </summary>
        public int Ugenummer { get; set; }
        /// <summary>
        /// VagtId Property
        /// </summary>
        public int VagtId { get; set; }
        /// <summary>
        /// Brugernavn Property
        /// </summary>
        public string Brugernavn { get; set; }
        /// <summary>
        /// Navn Property
        /// </summary>
        public string Navn { get; set; }
    }
}

