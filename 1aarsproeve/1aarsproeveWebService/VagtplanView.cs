namespace _1aarsproeveWebService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VagtplanView")]
    public partial class VagtplanView
    {
        [Key]
        [Column(Order = 0)]
        public TimeSpan Sluttidspunkt { get; set; }

        [Key]
        [Column(Order = 1)]
        public TimeSpan Starttidspunkt { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UgedagId { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Ugenummer { get; set; }

        [StringLength(50)]
        public string Navn { get; set; }
    }
}
