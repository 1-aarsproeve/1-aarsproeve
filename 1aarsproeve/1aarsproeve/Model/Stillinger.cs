namespace _1aarsproeve.Model
{
    public partial class Stillinger
    {
        public Stillinger(int stillingId, string stilling)
        {
            StillingId = stillingId;
            Stilling = stilling;
        }
        public int StillingId { get; set; }
        public string Stilling { get; set; }
    }
}
