using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Data
{
	public class User
	{
		public Guid Id { get; set; }
		public Guid IdRole { get; set; }
		public string Ma { get; set; }
		public string Ten { get; set; }
		public string Anh { get; set; }
		public string TenTaiKhoan { get; set; }
		public string MatKhau { get; set; }
		public string SDT { get; set; }
		public DateTime NgaySinh { get; set; }
		public string DiaChi { get; set; }
		public int GioiTinh { get; set; }
		public string GhiChu { get; set; }
		public int TrangThai { get; set; }
		public Role role { get; set; }
		public ICollection<HoaDon> hoaDons { get; set; }
		public ICollection<GioHang> gioHangs { get; set; }
	}
}
