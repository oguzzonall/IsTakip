namespace IsTakip.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("IsTakipIzleme")]
    public partial class IsTakipIzleme
    {
        public int id { get; set; }

        public int Izleyen { get; set; }

        public int Izlenen { get; set; }

        public virtual Kullanicilar Kullanicilar { get; set; }

        public virtual Kullanicilar Kullanicilar1 { get; set; }
    }
}
