using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Data
{
	public class Anh
	{
		public Guid Id { get; set; }
		public string DuongDan { get; set; }
		public int TrangThai { get; set; }
		public ICollection<ChiTietSanPham> chiTietSanPhams { get; set; }
	}
}
