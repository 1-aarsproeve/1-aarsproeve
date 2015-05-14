using System;

namespace _1aarsproeve.Model
{
    public partial class AnmodningerView
    {
        public AnmodningerView(int vagtId, string anmodningBrugernavn)
        {
            VagtId = vagtId;
            AnmodningBrugernavn = anmodningBrugernavn;
        }

        public int AnmodningId { get; set; }
        public string AnmodningBrugernavn { get; set; }
        public TimeSpan Starttidspunkt { get; set; }
        public TimeSpan Sluttidspunkt { get; set; }
        public int UgedagId { get; set; }
        public int Ugenummer { get; set; }
        public string Brugernavn { get; set; }
        public int VagtId { get; set; }
        public string Ugedag { get; set; }
    }
}
