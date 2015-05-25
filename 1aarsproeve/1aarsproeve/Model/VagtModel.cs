using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace _1aarsproeve.Model
{
    /// <summary>
    /// VagtModel Klassen, der joiner Vagter med Ansatte
    /// </summary>
    public partial class VagtModel
    {
        private string _brugernavn;
        /// <summary>
        /// Default Konstruktør
        /// </summary>
        public VagtModel()
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
        public VagtModel(TimeSpan starttidspunkt, TimeSpan sluttidspunkt, int ugenummer, Ugedage ugedag, Ansatte ansat)
        {
            Ansat = new Ansatte();
            Ugedag = new Ugedage();
            Starttidspunkt = starttidspunkt;
            Sluttidspunkt = sluttidspunkt;
            Ugenummer = ugenummer;
            Ansat = ansat;
            Ugedag = ugedag;
            UgedagId = Ugedag.UgedagId;
            Brugernavn = Ansat.Brugernavn;
        }

        public Ugedage Ugedag { get; set; }

        public VagtModel(TimeSpan starttidspunkt, TimeSpan sluttidspunkt, int ugedagId, int ugenummer, string brugernavn, string navn)
        {
            Starttidspunkt = starttidspunkt;
            Sluttidspunkt = sluttidspunkt;
            UgedagId = ugedagId;
            Ugenummer = ugenummer;
            Brugernavn = brugernavn;
            Navn = navn;
        }

        public Ansatte Ansat { get; set; }

        /// <summary>
        /// Konstruktør med vagtId
        /// </summary>
        /// <param name="vagtId"></param>
        /// <param name="starttidspunkt"></param>
        /// <param name="sluttidspunkt"></param>
        /// <param name="ugenummer"></param>
        /// <param name="ugedagId"></param>
        /// <param name="brugernavn"></param>
        public VagtModel(int vagtId, TimeSpan starttidspunkt, TimeSpan sluttidspunkt, int ugenummer, int ugedagId, string brugernavn)
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
        /// Formater starttidspunkt
        /// </summary>
        public string StarttidspunktFormat
        {
            get { return Starttidspunkt.ToString(@"hh\:mm", new CultureInfo("da-DK")); }
        }
        /// <summary>
        /// Formater sluttidspunkt
        /// </summary>
        public string SluttidspunktFormat
        {
            get { return Sluttidspunkt.ToString(@"hh\:mm", new CultureInfo("da-DK")); }
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