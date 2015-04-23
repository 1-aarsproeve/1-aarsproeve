using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _1aarsproeve.Model
{
    public partial class VagtplanView
    {
        public TimeSpan Starttidspunkt { get; set; }
        public TimeSpan Sluttidspunkt { get; set; }
        public int UgedagId { get; set; }
        public int Ugenummer { get; set; }
        public int VagtId { get; set; }
        public string Brugernavn { get; set; }
        public string Navn { get; set; }
    }
}
