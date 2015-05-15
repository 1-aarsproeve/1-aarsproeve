namespace WS1aarsproeve
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AnmodningerView")]
    public partial class AnmodningerView
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AnmodningId { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string AnmodningBrugernavn { get; set; }

        [Key]
        [Column(Order = 2)]
        public TimeSpan Starttidspunkt { get; set; }

        [Key]
        [Column(Order = 3)]
        public TimeSpan Sluttidspunkt { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UgedagId { get; set; }

        [Key]
        [Column(Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Ugenummer { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(50)]
        public string Brugernavn { get; set; }

        [Key]
        [Column(Order = 7)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int VagtId { get; set; }

        [Key]
        [Column(Order = 8)]
        [StringLength(7)]
        public string Ugedag { get; set; }
    }
}
