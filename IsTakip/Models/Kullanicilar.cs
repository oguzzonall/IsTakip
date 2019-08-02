namespace IsTakip.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Kullanicilar")]
    public partial class Kullanicilar
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Kullanicilar()
        {
            IsTakipDetays = new HashSet<IsTakipDetay>();
            IsTakipIzlemes = new HashSet<IsTakipIzleme>();
            IsTakipIzlemes1 = new HashSet<IsTakipIzleme>();
            IsTakipMasters = new HashSet<IsTakipMaster>();
            IsTakipSorumlulars = new HashSet<IsTakipSorumlular>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(15)]
        public string KullaniciNo { get; set; }

        [Required]
        [StringLength(30)]
        public string KullaniciAdi { get; set; }

        [Required]
        [StringLength(15)]
        public string Sifre { get; set; }

        public int? RolId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IsTakipDetay> IsTakipDetays { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IsTakipIzleme> IsTakipIzlemes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IsTakipIzleme> IsTakipIzlemes1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IsTakipMaster> IsTakipMasters { get; set; }

        public virtual IsTakipRoller IsTakipRoller { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IsTakipSorumlular> IsTakipSorumlulars { get; set; }
    }
}
