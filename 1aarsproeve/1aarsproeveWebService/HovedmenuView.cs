namespace _1aarsproeveWebService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HovedmenuView")]
    public partial class HovedmenuView
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BeskedId { get; set; }

        [StringLength(50)]
        public string Overskrift { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "date")]
        public DateTime Dato { get; set; }

        [Column(TypeName = "text")]
        public string Beskrivelse { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "date")]
        public DateTime Udloebsdato { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(50)]
        public string Brugernavn { get; set; }

        [StringLength(50)]
        public string Navn { get; set; }
    }
}
