using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using OrderTracking.DataAccessLayer.Abstarct.Repository;
using OrderTracking.DataAccessLayer.Concrete.ORM.EntityFramework.Context;
using OrderTracking.Entity.Abstrack;

namespace OrderTracking.DataAccessLayer.Concrete.ORM.EntityFramework.Repository
{
	/// <summary>
	/// Bu class içerisinde bütün tablolarda ortak olan CRUD işlemlerinin implement edilmiş hallerini barındırıyor
	/// bu şekilde aynı olan metodlar sadece bir seferlik burada yazılıyor.
	/// </summary>
	/// <typeparam name="TEntity"></typeparam>
	public class EfOrderTrackingGenericRepositoryBase<TEntity> : IGenericRepository<TEntity>
		where TEntity : class, IEntity, new()
		//where TContext : DbContext, new() // Not: Burada aslında context değeri de generic alınabilir, daha sonradan bu şekilde yapmayı dene!
	{
		protected static DbContext _dbContext;
		protected DbSet<TEntity> _dbSet;

		public EfOrderTrackingGenericRepositoryBase(OrderTrackingContext dbContext)
		{
			//_dbContext = new TContext();
			_dbContext = dbContext;
			_dbSet = _dbContext.Set<TEntity>();
		}

		public TEntity Get(Expression<Func<TEntity, bool>> predicate)
		{
			return _dbSet.SingleOrDefault(predicate);
		}

		public IQueryable<TEntity> GetAll()
		{
			return _dbSet;
		}

		public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate)
		{
			return _dbSet.Where(predicate);
		}

		public TEntity GetById(int id)
		{
			return _dbSet.Find(id);
		}

		public void Add(TEntity entity)
		{
			_dbSet.Add(entity);
		}

		public void Update(TEntity entity)
		{
			_dbSet.Attach(entity);
			_dbContext.Entry(entity).State = EntityState.Modified;
		}

		// Silme işlemi aslında bir güncellme işlemidir, sadece silindi alanı true yapılır o kadar. Silme için tablolarda silinme bilgisini tutan bir alana ihtiyaç vardır.
		public void Delete(TEntity entity)
		{
			//var deletedEntity = _dbContext.Entry(entity);
			//deletedEntity.State = EntityState.Deleted;
			//_dbContext.SaveChanges();
		}

		public void Delete(int id)
		{
			throw new NotImplementedException();
		}

	}
}
