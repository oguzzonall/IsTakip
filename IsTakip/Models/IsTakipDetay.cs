namespace IsTakip.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("IsTakipDetay")]
    public partial class IsTakipDetay
    {
        public int id { get; set; }

        public int Masterid { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime Tarih { get; set; }

        [Required]
        [StringLength(500)]
        public string Aciklama { get; set; }

        public int Durumid { get; set; }

        public int Sorumlu { get; set; }

        public DateTime KayitTarihi { get; set; }

        public double HarcananSure { get; set; }

        public virtual IsTakipDurumu IsTakipDurumu { get; set; }

        public virtual IsTakipMaster IsTakipMaster { get; set; }

        public virtual Kullanicilar Kullanicilar { get; set; }
    }
}
