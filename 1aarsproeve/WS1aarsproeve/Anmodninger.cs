namespace WS1aarsproeve
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Anmodninger")]
    public partial class Anmodninger
    {
        [Key]
        public int AnmodningId { get; set; }

        public int VagtId { get; set; }

        [Required]
        [StringLength(50)]
        public string AnmodningBrugernavn { get; set; }

        public virtual Ansatte Ansatte { get; set; }

        public virtual Vagter Vagter { get; set; }
    }
}
