using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Data
{
	public class MauSac
	{
		public Guid Id { get; set; }
		public string TenMauSac { get; set; }
		public int TrangThai { get; set; }
		public ICollection<ChiTietSanPham> chiTietSanPhams { get; set; }
	}
}
