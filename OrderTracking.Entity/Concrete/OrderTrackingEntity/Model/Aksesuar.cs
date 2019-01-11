namespace OrderTracking.Entity.Concrete.OrderTrackingEntity.Model
{
	using OrderTracking.Entity.Abstrack;
	using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Aksesuar")]
    public partial class Aksesuar: IEntity
	{
        public int AksesuarID { get; set; }

        public int? TeknikServisID { get; set; }

        public int? StokID { get; set; }
    }
}
