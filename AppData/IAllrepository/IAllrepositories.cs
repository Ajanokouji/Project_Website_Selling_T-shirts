using AppData.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.IAllrepository
{
	public interface IAllrepositories<T>
	{
		public IEnumerable<T> GetAllItem();
		public bool CreateItem (T item);
		public bool DeleteItem (T item);
		public bool UpdateItem (T item);
		public T GetById(Guid id);
	}
}
