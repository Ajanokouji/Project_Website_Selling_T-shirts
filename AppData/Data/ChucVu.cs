using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Data
{
	public class ChucVu
	{
		public Guid Id { get; set; }
		public string TenChucVu { get; set; }
		public int TrangThai { get; set; }
		public ICollection<NhanVien> nhanViens { get; set; }
	}
}
