namespace IsTakip.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("IsTakipYorum")]
    public partial class IsTakipYorum
    {
        public int id { get; set; }

        [Required]
        [StringLength(500)]
        public string Icerik { get; set; }

        public int IstekId { get; set; }

        [Required]
        [StringLength(100)]
        public string YorumYapan { get; set; }

        public DateTime YorumTarihi { get; set; }

        public virtual MusteriIstekler MusteriIstekler { get; set; }
    }
}
