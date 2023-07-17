using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Data
{
	public class NhanVien
	{
		public Guid Id { get; set; }
		public Guid IdCV { get; set; }
		public string Ten { get; set; }
		public string TenTaiKhoan { get; set; }
		public string MatKhau { get; set; }
		public string Anh { get; set; }
		public string Email { get; set; }
		public int TrangThai { get; set; }
		public ChucVu chucVu { get; set; }
		public ICollection<HoaDon> hoaDons { get; set; }
	}
}
