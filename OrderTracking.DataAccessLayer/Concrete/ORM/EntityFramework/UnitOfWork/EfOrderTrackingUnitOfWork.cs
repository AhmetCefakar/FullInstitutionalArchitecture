using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderTracking.DataAccessLayer.Abstarct.Repository;
using OrderTracking.DataAccessLayer.Abstarct.UnitOfWork;
using OrderTracking.DataAccessLayer.Concrete.ORM.EntityFramework.Context;
using OrderTracking.DataAccessLayer.Concrete.ORM.EntityFramework.Repository;
using OrderTracking.Entity.Abstrack;

namespace OrderTracking.DataAccessLayer.Concrete.ORM.EntityFramework.UnitOfWork
{
	/// <summary>
	/// 
	/// Bu class'ta 'Context' sınıfından sadece bir adet nesne olması için ' Thread Safety Singleton using Double Check Locking' pattern kullanıldı.
	/// </summary>
	public class EfOrderTrackingUnitOfWork : IUnitOfWork
	{
		private static readonly object padlock = new object(); // Çoklu thered ortamlarında tek context üretmek için eklendi.
		private readonly OrderTrackingContext _dbContext;

		#region Her bir tabloya özel olan Repositorylerin tanımlanması(UOW'ün bu Generic olmayan yaklaşımında her bir Repository sınıfı buraya tek tek tanımlanmalıdır)
		private EfStokRepository _efStokDal;
		public EfStokRepository EfStokDal
		{
			get
			{
				if (_efStokDal == null)
				{
					_efStokDal = new EfStokRepository(_dbContext);
				}
				return _efStokDal;
			}
		}
		#endregion



		public EfOrderTrackingUnitOfWork()
		{
			#region Thread Safety Singleton using Double Check Locking
			if (_dbContext == null)
			{
				lock (padlock)
				{
					if (_dbContext == null)
					{
						_dbContext = new OrderTrackingContext();
						Console.WriteLine("'_dbContext' nesnesi oluştu");
					}
				}
			}
			#endregion

			_efStokDal = null;

			// Buradan istediğiniz gibi EntityFramework'ü konfigure edilebilir.
			//_dbContext.Configuration.LazyLoadingEnabled = false;
			//_dbContext.Configuration.ValidateOnSaveEnabled = false;
			//_dbContext.Configuration.ProxyCreationEnabled = false;
		}

		public IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : class, IEntity, new()
		{
			return new EfOrderTrackingGenericRepositoryBase<TEntity>(_dbContext);
		}

		public bool SaveChanges()
		{
			return _dbContext.SaveChanges() > 0;
		}

		#region IDisposable Members
		//Burada IUnitOfWork arayüzüne implemente ettiğimiz IDisposable arayüzünün Dispose Patternini implemente ediyoruz.
		private bool disposed = false;
		protected virtual void Dispose(bool disposing)
		{
			if (!this.disposed)
			{
				if (disposing)
				{
					_dbContext.Dispose();
				}
			}

			this.disposed = true;
		}
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
		#endregion

	}
}
