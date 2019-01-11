using OrderTracking.DataAccessLayer.Abstarct.Repository;
using OrderTracking.Entity.Abstrack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderTracking.DataAccessLayer.Abstarct.UnitOfWork
{
	/// <summary>
	/// Transection işlemlerini yönetebilmek için eklenen sınıf
	/// </summary>
	public interface IUnitOfWork : IDisposable
	{
		IGenericRepository<T> GetRepository<T>() where T : class, IEntity, new();
		bool SaveChanges();
	}
}
