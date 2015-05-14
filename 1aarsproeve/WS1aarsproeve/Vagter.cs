namespace WS1aarsproeve
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Vagter")]
    public partial class Vagter
    {
        public Vagter()
        {
            Anmodningers = new HashSet<Anmodninger>();
        }

        [Key]
        public int VagtId { get; set; }

        public TimeSpan Starttidspunkt { get; set; }

        public TimeSpan Sluttidspunkt { get; set; }

        public int Ugenummer { get; set; }

        public int UgedagId { get; set; }

        [Required]
        [StringLength(50)]
        public string Brugernavn { get; set; }

        public virtual ICollection<Anmodninger> Anmodningers { get; set; }

        public virtual Ansatte Ansatte { get; set; }

        public virtual Ugedage Ugedage { get; set; }
    }
}
