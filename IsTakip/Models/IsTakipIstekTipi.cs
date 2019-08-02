namespace IsTakip.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("IsTakipIstekTipi")]
    public partial class IsTakipIstekTipi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public IsTakipIstekTipi()
        {
            MusteriIsteklers = new HashSet<MusteriIstekler>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(30)]
        public string TipAdi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MusteriIstekler> MusteriIsteklers { get; set; }
    }
}
