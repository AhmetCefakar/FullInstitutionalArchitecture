﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using OrderTracking.Entity.Abstrack;

namespace OrderTracking.DataAccessLayer.Abstarct.Repository
{
	/// <summary>
	/// Model katmanımızda bulunan her T tipi için aşağıda tanımladığımız fonksiyonları gerçekleştirebilecek generic bir repository tanımlıyoruz.
	/// </summary>
	/// <typeparam name="T">IEntity Type</typeparam>
	public interface IGenericRepository<T> where T : class, IEntity, new()
	{
		IQueryable<T> GetAll();
		IQueryable<T> GetAll(Expression<Func<T, bool>> predicate); // LINQ desteği sunabilmek içinde expression'ları kullanıyoruz.
		T GetById(int id);
		T Get(Expression<Func<T, bool>> predicate);

		void Add(T entity);
		void Update(T entity);
		void Delete(T entity);
		void Delete(int id);
	}
}
