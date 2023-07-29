using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Data
{
	public class GioHang
	{
		public Guid Id { get; set; }
		public Guid IdUser { get; set; }
		public string Mota { get; set;}
		public int TrangThai { get; set;}
		public User user { get; set;}
		public ICollection<GioHangChiTiet> gioHangChiTiets { get; set; }
	}
}
