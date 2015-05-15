namespace WS1aarsproeve
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Stillinger")]
    public partial class Stillinger
    {
        public Stillinger()
        {
            Ansattes = new HashSet<Ansatte>();
        }

        [Key]
        public int StillingId { get; set; }

        [Required]
        [StringLength(50)]
        public string Stilling { get; set; }

        public virtual ICollection<Ansatte> Ansattes { get; set; }
    }
}
