using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Data
{
	public class GioHangChiTiet
	{
		public Guid Id { get; set; }
		public Guid IdCTSP { get; set; }
		public int SoLuong { get; set; }
		public ChiTietSanPham chiTietSanPham { get; set; }
	}
}
