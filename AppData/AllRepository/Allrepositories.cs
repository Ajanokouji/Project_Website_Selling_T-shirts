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

		public ChatLieu GetCLByID(Guid id)
		{
			return _dbContext.chatLieus.FirstOrDefault(c => c.Id == id);
		}

		public ChucVu GetCVByID(Guid id)
		{
			return _dbContext.chucVus.FirstOrDefault(c => c.Id == id);
		}

		public GioHang GetGHByID(Guid id)
		{
			return _dbContext.gioHangs.FirstOrDefault(c => c.Id == id);
		}

		public HoaDon GetHDByID(Guid id)
		{
			return _dbContext.hoaDons.FirstOrDefault(c => c.Id == id);
		}

		public KichCo GetKCByID(Guid id)
		{
			return _dbContext.kichCos.FirstOrDefault(c => c.Id == id);
		}

		public KhachHang GetKHByID(Guid id)
		{
			return _dbContext.khachHangs.FirstOrDefault(c => c.Id == id);
		}

		public Loai GetLoaiByID(Guid id)
		{
			return _dbContext.loais.FirstOrDefault(c => c.Id == id);
		}

		public MauSac GetMSByID(Guid id)
		{
			return _dbContext.mauSacs.FirstOrDefault(c => c.Id == id);
		}

		public NhanVien GetNVByID(Guid id)
		{
			return _dbContext.nhanViens.FirstOrDefault(c => c.Id == id);
		}

		public SanPham GetSPByID(Guid id)
		{
			return _dbContext.sanPhams.FirstOrDefault(c => c.Id == id);
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
