namespace IsTakip.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("IsTakipDurumu")]
    public partial class IsTakipDurumu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public IsTakipDurumu()
        {
            IsTakipDetays = new HashSet<IsTakipDetay>();
            IsTakipSorumlulars = new HashSet<IsTakipSorumlular>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string DurumAdi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IsTakipDetay> IsTakipDetays { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IsTakipSorumlular> IsTakipSorumlulars { get; set; }
    }
}
