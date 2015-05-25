using System;

namespace _1aarsproeve.Model
{
    /// <summary>
    /// AnmodningModel Klasse
    /// </summary>
    public partial class AnmodningModel
    {
        /// <summary>
        /// AnmodningModel konstruktør
        /// </summary>
        /// <param name="vagtId">vagtId parameter</param>
        /// <param name="anmodningBrugernavn">anmodningBrugernavn parameter</param>
        public AnmodningModel(int vagtId, string anmodningBrugernavn)
        {
            VagtId = vagtId;
            AnmodningBrugernavn = anmodningBrugernavn;
        }
        /// <summary>
        /// AnmodningId property
        /// </summary>
        public int AnmodningId { get; set; }
        /// <summary>
        /// Navn property
        /// </summary>
        public string Navn { get; set; }
        /// <summary>
        /// AnmodningBrugernavn property
        /// </summary>
        public string AnmodningBrugernavn { get; set; }
        /// <summary>
        /// Starttidspunkt property
        /// </summary>
        public TimeSpan Starttidspunkt { get; set; }
        /// <summary>
        /// Sluttidspunkt property
        /// </summary>
        public TimeSpan Sluttidspunkt { get; set; }
        /// <summary>
        /// UgedagId property
        /// </summary>
        public int UgedagId { get; set; }
        /// <summary>
        /// Ugenummer property
        /// </summary>
        public int Ugenummer { get; set; }
        /// <summary>
        /// Brugernavn property
        /// </summary>
        public string Brugernavn { get; set; }
        /// <summary>
        /// VagtId property
        /// </summary>
        public int VagtId { get; set; }
        /// <summary>
        /// Ugedag property
        /// </summary>
        public string Ugedag { get; set; }
    }
}