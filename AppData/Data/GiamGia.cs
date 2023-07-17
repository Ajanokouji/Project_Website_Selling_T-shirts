using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Data
{
	public class GiamGia
	{
		public Guid Id { get; set; }
		public string Ma { get; set; }
		public string Ten { get; set; }
		public DateTime NgayBatDau { get; set; }
		public DateTime NgayKetThuc { get; set; }
		public double MucGiamGiaPhanTram { get; set; }
		public double MucGiamGiaTienMat { get; set; }
		public int TrangThai { get; set; }
		public ICollection<HoaDonChiTiet> hoaDonChiTiets { get; set; } 
	}
}
