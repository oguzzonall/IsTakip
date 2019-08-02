namespace IsTakip.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("IsTakipSorumlular")]
    public partial class IsTakipSorumlular
    {
        public int id { get; set; }

        public int Masterid { get; set; }

        public int Sorumlu { get; set; }

        public int DurumuId { get; set; }

        public bool Mail { get; set; }

        public virtual IsTakipDurumu IsTakipDurumu { get; set; }

        public virtual Kullanicilar Kullanicilar { get; set; }
    }
}
