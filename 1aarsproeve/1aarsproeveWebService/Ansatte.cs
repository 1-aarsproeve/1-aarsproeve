namespace _1aarsproeveWebService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Ansatte")]
    public partial class Ansatte
    {
        public Ansatte()
        {
            Beskeders = new HashSet<Beskeder>();
            Vagters = new HashSet<Vagter>();
        }

        [Key]
        [StringLength(50)]
        public string Brugernavn { get; set; }

        [StringLength(50)]
        public string Navn { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(50)]
        public string Mobil { get; set; }

        [StringLength(50)]
        public string Adresse { get; set; }

        [StringLength(50)]
        public string Postnummer { get; set; }

        public int StillingId { get; set; }

        public virtual Stillinger Stillinger { get; set; }

        public virtual ICollection<Beskeder> Beskeders { get; set; }

        public virtual ICollection<Vagter> Vagters { get; set; }
    }
}
