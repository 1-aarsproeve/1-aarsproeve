namespace _1aarsproeve.Model
{
    /// <summary>
    /// stillinger klasse
    /// </summary>
    public partial class Stillinger
    {
        /// <summary>
        /// konstruktør
        /// </summary>
        /// <param name="stillingId">stillingId parameter</param>
        /// <param name="stilling">stilling parameter</param>

        public Stillinger(int stillingId, string stilling)
        {
            StillingId = stillingId;
            Stilling = stilling;
        }
        /// <summary>
        /// StillingId property
        /// </summary>
        public int StillingId { get; set; }
        /// <summary>
        /// Stilling porperty
        /// </summary>
        public string Stilling { get; set; }
        /// <summary>
        /// Returnerer Stilling
        /// </summary>
        /// <returns>Returnerer ToString</returns>
        public override string ToString()
        {
            return Stilling;
        }
    }
}
