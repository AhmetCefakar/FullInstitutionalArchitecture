namespace OrderTracking.Entity.Concrete.OrderTrackingEntity.Model
{
	using OrderTracking.Entity.Abstrack;
	using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Ilce")]
    public partial class Ilce : IEntity
	{
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IlceID { get; set; }

        public int? IlID { get; set; }

        [StringLength(10)]
        public string IlceKodu { get; set; }

        [StringLength(20)]
        public string IlceAdi { get; set; }

        public virtual Il Il { get; set; }
    }
}
