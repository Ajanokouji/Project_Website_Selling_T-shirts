using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Data
{
	public class HoaDonChiTiet
	{
		public Guid IdHD { get; set; }
		public Guid IdCTSP { get; set; }
		public Guid IdGiamGia { get; set; }
		public int SoLuong { get; set; }
		public Decimal DonGia { get; set; }
		public HoaDon hoaDon { get; set; }
		public ChiTietSanPham chiTietSanPham { get; set; }
		public GiamGia giamGia { get; set; }
	}
}
