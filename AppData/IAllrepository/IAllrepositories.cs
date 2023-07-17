using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.IAllrepository
{
	public interface IAllrepositories<T>
	{
		IEnumerable<T> GetAllItem();
		bool CreateItem (T item);
		bool DeleteItem (T item);
		bool UpdateItem (T item);
	}
}
