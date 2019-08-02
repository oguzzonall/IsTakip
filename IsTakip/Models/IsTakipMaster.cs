namespace IsTakip.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("IsTakipMaster")]
    public partial class IsTakipMaster
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public IsTakipMaster()
        {
            IsTakipDetays = new HashSet<IsTakipDetay>();
        }

        public int id { get; set; }

        public DateTime KayitTarih { get; set; }

        [Required]
        [StringLength(1000)]
        public string Aciklama { get; set; }

        public int OncelikId { get; set; }

        public int IsiVerenId { get; set; }

        public bool Kapandi { get; set; }

        public int KategoriId { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime Termin { get; set; }

        public int TamamlanmaYuzdesi { get; set; }

        public int IsGrubuId { get; set; }

        [StringLength(20)]
        public string IsKodu { get; set; }

        [Required]
        [StringLength(500)]
        public string Sorumlular { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<IsTakipDetay> IsTakipDetays { get; set; }

        public virtual IsTakipGruplar IsTakipGruplar { get; set; }

        public virtual IsTakipKategori IsTakipKategori { get; set; }

        public virtual IsTakipOncelik IsTakipOncelik { get; set; }

        public virtual Kullanicilar Kullanicilar { get; set; }
    }
}
