namespace IsTakip.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Musteriler")]
    public partial class Musteriler
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Musteriler()
        {
            MusteriIsteklers = new HashSet<MusteriIstekler>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(100)]
        public string SirketAdi { get; set; }

        [Required]
        [StringLength(50)]
        public string SirketNo { get; set; }

        [Required]
        [StringLength(20)]
        public string SirketSifre { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MusteriIstekler> MusteriIsteklers { get; set; }
    }
}
