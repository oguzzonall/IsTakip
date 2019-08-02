namespace IsTakip.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MusteriIstekler")]
    public partial class MusteriIstekler
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MusteriIstekler()
        {
            IsTakipYorums = new HashSet<IsTakipYorum>();
        }

        public int id { get; set; }

        public int MusteriId { get; set; }

        public int IstekTipId { get; set; }

        [Required]
        [StringLength(1000)]
        public string Istek { get; set; }

        public bool Goruldu { get; set; }

        public DateTime IstekTarihi { get; set; }

        public virtual IsTakipIstekTipi IsTakipIstekTipi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IsTakipYorum> IsTakipYorums { get; set; }

        public virtual Musteriler Musteriler { get; set; }
    }
}
