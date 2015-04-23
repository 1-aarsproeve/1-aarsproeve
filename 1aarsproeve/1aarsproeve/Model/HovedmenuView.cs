using System;
using System.ComponentModel.DataAnnotations;

namespace _1aarsproeve.Model
{

    public partial class HovedmenuView
    {
        public int BeskedId { get; set; }
        public string Overskrift { get; set; }
        public DateTime Dato { get; set; }
        public string Beskrivelse { get; set; }
        public DateTime Udloebsdato { get; set; }
        public string Brugernavn { get; set; }
        public string Navn { get; set; }
    }
}
