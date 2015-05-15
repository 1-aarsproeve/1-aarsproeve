namespace WS1aarsproeve
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Ugedage")]
    public partial class Ugedage
    {
        public Ugedage()
        {
            Vagters = new HashSet<Vagter>();
        }

        [Key]
        public int UgedagId { get; set; }

        [Required]
        [StringLength(7)]
        public string Ugedag { get; set; }

        public virtual ICollection<Vagter> Vagters { get; set; }
    }
}
