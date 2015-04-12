namespace _1aarsproeveWebService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Beskeder")]
    public partial class Beskeder
    {
        [Key]
        public int BeskedId { get; set; }

        [StringLength(50)]
        public string Overskrift { get; set; }

        [Column(TypeName = "date")]
        public DateTime Dato { get; set; }

        [Column(TypeName = "text")]
        public string Beskrivelse { get; set; }

        [Column(TypeName = "date")]
        public DateTime Udloebsdato { get; set; }

        [Required]
        [StringLength(50)]
        public string Brugernavn { get; set; }

        public virtual Ansatte Ansatte { get; set; }
    }
}
