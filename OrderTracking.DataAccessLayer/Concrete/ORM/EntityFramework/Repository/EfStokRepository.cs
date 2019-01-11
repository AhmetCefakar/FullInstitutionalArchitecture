using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderTracking.DataAccessLayer.Abstarct.Repository;
using OrderTracking.DataAccessLayer.Concrete.ORM.EntityFramework.Context;
using OrderTracking.DataAccessLayer.Concrete.ORM.EntityFramework.Repository;
using OrderTracking.Entity.Concrete.OrderTrackingEntity.Model;

namespace OrderTracking.DataAccessLayer.Concrete.ORM.EntityFramework
{
	//class EfStokDal: EfGenericRepositoryBase<Stok, OrderTrackingContext>, IStokDal
	public class EfStokRepository: EfOrderTrackingGenericRepositoryBase<Stok>, IStokDal
	{
		public EfStokRepository(OrderTrackingContext dbContext):base(dbContext)
		{

		}

	}
}
