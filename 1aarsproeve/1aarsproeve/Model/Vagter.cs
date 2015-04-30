using System;

namespace _1aarsproeve.Model
{
    /// <summary>
    /// Vagter Klasse
    /// </summary>
    public partial class Vagter
    {
        /// <summary>
        /// Vagter Konstruktør
        /// </summary>
        /// <param name="starttidspunkt">starttidspunkt parameter</param>
        /// <param name="sluttidspunkt">sluttidspunkt parameter</param>
        /// <param name="ugenummer">ugenummer parameter</param>
        /// <param name="ugedagId">ugedagId parameter</param>
        /// <param name="brugernavn">brugernavn parameter</param>
        public Vagter(TimeSpan starttidspunkt, TimeSpan sluttidspunkt, int ugenummer, int ugedagId, string brugernavn)
        {
            Starttidspunkt = starttidspunkt;
            Sluttidspunkt = sluttidspunkt;
            Ugenummer = ugenummer;
            UgedagId = ugedagId;
            Brugernavn = brugernavn;
        }
        /// <summary>
        /// Vagter Default Konstruktør
        /// </summary>
        public Vagter()
        {

        }

        public void CheckBrugernavn(string brugernavn)
        {
            if (string.IsNullOrEmpty(brugernavn) || brugernavn.Length > 30)
            {
                throw new ArgumentException("brugernavn er forkert");
            }

        }
        /// <summary>
        /// VagtId Property
        /// </summary>
        public int VagtId { get; set; }
        /// <summary>
        /// Starttidspunkt Property
        /// </summary>
        public TimeSpan Starttidspunkt { get; set; }
        /// <summary>
        /// Sluttidspunkt Property
        /// </summary>
        public TimeSpan Sluttidspunkt { get; set; }
        /// <summary>
        /// Ugenummer Property
        /// </summary>
        public int Ugenummer { get; set; }
        /// <summary>
        /// UgedagId Property
        /// </summary>
        public int UgedagId { get; set; }
        /// <summary>
        /// Brugernavn Property
        /// </summary>

        private string _brugernavn;

        public string Brugernavn
        {
            get { return _brugernavn; }
            set
            {
                CheckBrugernavn(value);
                _brugernavn = value;
            }
        }
    }
}