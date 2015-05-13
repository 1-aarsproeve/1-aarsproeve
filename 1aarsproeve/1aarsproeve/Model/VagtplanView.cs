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
        private string _brugernavn;
        /// <summary>
        /// Default Konstruktør
        /// </summary>
        public VagtplanView()
        {
            
        }
        /// <summary>
        /// Konstruktør
        /// </summary>
        /// <param name="starttidspunkt"></param>
        /// <param name="sluttidspunkt"></param>
        /// <param name="ugenummer"></param>
        /// <param name="ugedagId"></param>
        /// <param name="brugernavn"></param>
        public VagtplanView(TimeSpan starttidspunkt, TimeSpan sluttidspunkt, int ugenummer, int ugedagId, string brugernavn)
        {
            Starttidspunkt = starttidspunkt;
            Sluttidspunkt = sluttidspunkt;
            Ugenummer = ugenummer;
            UgedagId = ugedagId;
            Brugernavn = brugernavn;
        }
        /// <summary>
        /// Konstruktør med vagtId
        /// </summary>
        /// <param name="vagtId"></param>
        /// <param name="starttidspunkt"></param>
        /// <param name="sluttidspunkt"></param>
        /// <param name="ugenummer"></param>
        /// <param name="ugedagId"></param>
        /// <param name="brugernavn"></param>
        public VagtplanView(int vagtId, TimeSpan starttidspunkt, TimeSpan sluttidspunkt, int ugenummer, int ugedagId, string brugernavn)
        {
            VagtId = vagtId;
            Starttidspunkt = starttidspunkt;
            Sluttidspunkt = sluttidspunkt;
            Ugenummer = ugenummer;
            UgedagId = ugedagId;
            Brugernavn = brugernavn;
        }
        /// <summary>
        /// Checkmetode til brugernavn
        /// </summary>
        /// <param name="brugernavn"></param>
        public void CheckBrugernavn(string brugernavn)
        {
            if (string.IsNullOrEmpty(brugernavn) || brugernavn.Length > 30)
            {
                throw new ArgumentException("brugernavn er forkert");
            }

        }
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
        
        public string Brugernavn
        {
            get { return _brugernavn; }
            set
            {
                CheckBrugernavn(value);
                _brugernavn = value;
            }
        }
        /// <summary>
        /// Navn Property
        /// </summary>
        public string Navn { get; set; }
    }
}