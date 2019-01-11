using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using OrderTracking.Entity.Abstrack;
using OrderTracking.Entity.Concrete.OrderTrackingEntity.Model;
using OrderTracking.DataAccessLayer.Concrete.ORM.EntityFramework.UnitOfWork;
using OrderTracking.DataAccessLayer.Abstarct.Repository;


namespace OrderTracking.UI.ConsoleApp
{
	class Program
	{
		static void Main(string[] args)
		{
			using (EfOrderTrackingUnitOfWork _uow = new EfOrderTrackingUnitOfWork())
			{
				IQueryable<Stok> stoks = _uow.EfStokDal.GetAll();
				List<Stok> stokList = stoks.ToList();

				Console.WriteLine($"Unit Of Work yapısından çekilen nesne listesi;");

				for (int i = 0; i < stokList.Count; i++)
				{
					Console.WriteLine($"{i + 1}. Item: {stokList[i].StokAdi}, {stokList[i].StokKisaAciklama}");
				}
				Console.WriteLine($"<<<<<<<<<<<<<<<<<<>>>>>>>>>>>>>>>>>>>>>");
			}

			Console.ReadLine();
		}
	}
}
