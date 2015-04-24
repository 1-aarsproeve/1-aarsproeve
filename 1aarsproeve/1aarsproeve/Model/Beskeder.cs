using System;

namespace _1aarsproeve.Model
{
    /// <summary>
    /// Beskeder Klassen
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
        /// BeskedId Property
        /// </summary>
        public int BeskedId { get; set; }
        /// <summary>
        /// Overskrift Property
        /// </summary>
        public string Overskrift { get; set; }
        /// <summary>
        /// Dato Property
        /// </summary>
        public DateTime Dato { get; set; }
        /// <summary>
        /// Beskrivelse Property
        /// </summary>
        public string Beskrivelse { get; set; }
        /// <summary>
        /// Udloebsdato Property
        /// </summary>
        public DateTime Udloebsdato { get; set; }
        /// <summary>
        /// Brugernavn Property
        /// </summary>
        public string Brugernavn { get; set; }
    }
}