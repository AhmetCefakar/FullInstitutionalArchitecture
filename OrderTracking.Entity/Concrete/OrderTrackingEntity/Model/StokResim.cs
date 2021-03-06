namespace OrderTracking.Entity.Concrete.OrderTrackingEntity.Model
{
	using OrderTracking.Entity.Abstrack;
	using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("StokResim")]
    public partial class StokResim : IEntity
	{
        public int StokResimID { get; set; }

        public int StokID { get; set; }

        [Required]
        [StringLength(300)]
        public string Url { get; set; }

        [StringLength(300)]
        public string OkumaUrl { get; set; }

        [Required]
        [StringLength(300)]
        public string ResimAdi { get; set; }

        [StringLength(300)]
        public string OrjinalResimAdi { get; set; }

        public byte? Sira { get; set; }

        public bool Aktif { get; set; }

        public DateTime? KayitZamani { get; set; }

        public int? KullaniciID { get; set; }

        [StringLength(30)]
        public string MaccAdress { get; set; }

        public virtual Stok Stok { get; set; }
    }
}
