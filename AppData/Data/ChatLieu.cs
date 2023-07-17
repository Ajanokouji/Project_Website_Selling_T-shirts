using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Data
{
	public class ChatLieu
	{
		public Guid Id { get; set; }
		public string TenChatLieu { get; set; }
		public int TrangThai { get; set; }
		public ICollection<ChiTietSanPham> chiTietSanPhams { get; set; }
	}
}
