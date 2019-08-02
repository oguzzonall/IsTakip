namespace IsTakip.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("IsTakipKategori")]
    public partial class IsTakipKategori
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public IsTakipKategori()
        {
            IsTakipMasters = new HashSet<IsTakipMaster>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string KategoriAdi { get; set; }

        public bool TerminGunuBelirle { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IsTakipMaster> IsTakipMasters { get; set; }
    }
}
