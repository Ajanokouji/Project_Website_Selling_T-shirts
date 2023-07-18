using AppData.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.IAllrepository
{
	public interface IAllrepositories<T>
	{
		public IEnumerable<T> GetAllItem();
		public bool CreateItem (T item);
		public bool DeleteItem (T item);
		public bool UpdateItem (T item);
		public ChatLieu GetCLByID (Guid id);
		public ChucVu GetCVByID (Guid id);
		public GioHang GetGHByID (Guid id);
		public HoaDon GetHDByID (Guid id);
		public KhachHang GetKHByID (Guid id);
		public KichCo GetKCByID (Guid id);
		public Loai GetLoaiByID (Guid id);
		public MauSac GetMSByID (Guid id);
		public NhanVien GetNVByID (Guid id);
		public SanPham GetSPByID (Guid id);
	}
}
