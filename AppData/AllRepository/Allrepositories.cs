using AppData.Data;
using AppData.IAllrepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.AllRepository
{
	public class Allrepositories<T> : IAllrepositories<T> where T : class
	{
		ShopDbContext _dbContext;
		DbSet<T> _dbSet;

        public Allrepositories()
        {
            
        }
        public Allrepositories(ShopDbContext dbContext, DbSet<T> dbSet)
        {
            this._dbContext = dbContext;
			this._dbSet = dbSet;
        }
        public bool CreateItem(T item)
		{
			try
			{
				_dbSet.Add(item);
				_dbContext.SaveChanges();
				return true;
			}
			catch (Exception)
			{
				return false;
				
			}
		}

		public bool DeleteItem(T item)
		{
			try
			{
				_dbSet.Remove(item);
				_dbContext.SaveChanges();
				return true;
			}
			catch (Exception)
			{
				return false;

			}
		}

		public IEnumerable<T> GetAllItem()
		{
			return _dbSet.ToList();
		}

		public bool UpdateItem(T item)
		{
			try
			{
				_dbSet.Update(item);
				_dbContext.SaveChanges();
				return true;
			}
			catch (Exception)
			{
				return false;

			}
		}
	}
}
