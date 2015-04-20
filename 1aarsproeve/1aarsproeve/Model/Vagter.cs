using System;

namespace _1aarsproeve.Model
{
    public partial class Vagter
    {
        public Vagter(int vagtId, TimeSpan starttidspunkt, TimeSpan sluttidspunkt, int ugenummer, int ugedagId, string brugernavn)
        {
            VagtId = vagtId;
            Starttidspunkt = starttidspunkt;
            Sluttidspunkt = sluttidspunkt;
            Ugenummer = ugenummer;
            UgedagId = ugedagId;
            Brugernavn = brugernavn;
        }
        public int VagtId { get; set; }
        public TimeSpan Starttidspunkt { get; set; }
        public TimeSpan Sluttidspunkt { get; set; }
        public int Ugenummer { get; set; }
        public int UgedagId { get; set; }
        public string Brugernavn { get; set; }
    }
}
