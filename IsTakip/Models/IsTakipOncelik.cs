namespace IsTakip.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("IsTakipOncelik")]
    public partial class IsTakipOncelik
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public IsTakipOncelik()
        {
            IsTakipMasters = new HashSet<IsTakipMaster>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(15)]
        public string OncelikAdi { get; set; }

        public int Gun { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IsTakipMaster> IsTakipMasters { get; set; }
    }
}
