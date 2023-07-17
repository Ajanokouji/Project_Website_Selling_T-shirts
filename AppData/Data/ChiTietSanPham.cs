using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Data
{
	public class ChiTietSanPham
	{
		public Guid Id { get; set; }
		public Guid IdSP { get; set; }
		public Guid IdAnh { get; set; }
		public Guid IdKC { get; set; }
		public Guid IdMS { get; set; }
		public Guid IdLoai { get; set; }
		public Guid IdCL { get; set; }
		public Decimal GiaNhap { get; set; }
		public Decimal GiaBan { get; set; }
		public int SoLuongTon { get; set; }
		public string Mota { get; set; }
		public int TrangThai { get; set; }
		public SanPham sanPham { get; set; }
		public Anh anh { get; set; }
		public KichCo kichCo { get; set; }
		public MauSac mauSac { get; set; }
		public Loai loai { get; set; }
		public ChatLieu chatLieu { get; set; }
		public ICollection<GioHangChiTiet> gioHangChiTiets { get; set; }
		public ICollection<HoaDonChiTiet> hoaDonChiTiets { get; set; }
	}
}
