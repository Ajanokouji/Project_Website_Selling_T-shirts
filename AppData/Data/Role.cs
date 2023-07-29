using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Data
{
	public class Role
	{
		public Guid Id { get; set; }
		public string TenRole { get; set; }
		public int TrangThai { get; set; }
		public ICollection<User> users { get; set; }
	}
}
