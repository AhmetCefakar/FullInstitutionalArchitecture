namespace OrderTracking.Entity.Concrete.OrderTrackingEntity.Model
{
	using OrderTracking.Entity.Abstrack;
	using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("StokETicaret")]
    public partial class StokETicaret : IEntity
	{
        public int StokETicaretID { get; set; }

        public int StokID { get; set; }

        public int ETicaretID { get; set; }

        public DateTime? KayitZamani { get; set; }

        public int? KullaniciID { get; set; }

        [StringLength(30)]
        public string MaccAdress { get; set; }

        public virtual Stok Stok { get; set; }
    }
}
