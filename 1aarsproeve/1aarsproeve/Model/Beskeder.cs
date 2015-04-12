using System;

namespace _1aarsproeve.Model
{
    public partial class Beskeder
    {
        public Beskeder(int beskedId, string overskrift, DateTime dato, string beskrivelse, DateTime udloebsdato, string brugernavn)
        {
            BeskedId = beskedId;
            Overskrift = overskrift;
            Dato = dato;
            Beskrivelse = beskrivelse;
            Udloebsdato = udloebsdato;
            Brugernavn = brugernavn;
        }
        public int BeskedId { get; set; }
        public string Overskrift { get; set; }
        public DateTime Dato { get; set; }
        public string Beskrivelse { get; set; }
        public DateTime Udloebsdato { get; set; }
        public string Brugernavn { get; set; }
    }
}
