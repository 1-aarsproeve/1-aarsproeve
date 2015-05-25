namespace WS1aarsproeve
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AnmodningModel")]
    public partial class AnmodningModel
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
        [StringLength(50)]
        public string Navn { get; set; }

        [Key]
        [Column(Order = 3)]
        public TimeSpan Starttidspunkt { get; set; }

        [Key]
        [Column(Order = 4)]
        public TimeSpan Sluttidspunkt { get; set; }

        [Key]
        [Column(Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UgedagId { get; set; }

        [Key]
        [Column(Order = 6)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Ugenummer { get; set; }

        [Key]
        [Column(Order = 7)]
        [StringLength(50)]
        public string Brugernavn { get; set; }

        [Key]
        [Column(Order = 8)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int VagtId { get; set; }

        [Key]
        [Column(Order = 9)]
        [StringLength(7)]
        public string Ugedag { get; set; }
    }
}
