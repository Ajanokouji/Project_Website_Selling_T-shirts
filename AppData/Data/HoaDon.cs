using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Data
{
	public class HoaDon
	{
		public Guid Id { get; set; }
		public Guid IdUser { get; set; }
		public string Ma { get; set; }
		public string TenUser { get; set; }
		public DateTime NgayTao { get; set; }
		public DateTime NgayNhan { get; set; }
		public DateTime NgayShip { get; set; }
		public DateTime NgayThanhToan { get; set; }
		public string DiaChi { get; set; }
		public Decimal TongTien { get; set; }
		public int TrangThai { get; set; }
		public string SDTNguoiNhan { get;set; }
		public string SDTNguoiShip { get;set; }
		public Decimal TienShip { get; set; }
		public User user { get; set; }
		public ICollection<HoaDonChiTiet> hoaDonChiTiets { get; set; }
	}
}
