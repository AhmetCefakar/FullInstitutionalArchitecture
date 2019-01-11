namespace OrderTracking.Entity.Concrete.OrderTrackingEntity.Model
{
	using OrderTracking.Entity.Abstrack;
	using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Model")]
    public partial class Model : IEntity
	{
        public int ModelID { get; set; }

        [StringLength(50)]
        public string ModelAdi { get; set; }

        public int? MarkaID { get; set; }

        public bool? Aktif { get; set; }

        public DateTime? KayitZamani { get; set; }

        public int? KullaniciID { get; set; }

        public virtual Marka Marka { get; set; }
    }
}
