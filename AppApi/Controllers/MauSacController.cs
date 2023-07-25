using AppData.AllRepository;
using AppData.Data;
using AppData.IAllrepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MauSacController : ControllerBase
	{
		IAllrepositories<MauSac> _iAllReposMS;
		ShopDbContext _shopDbContext = new ShopDbContext();
		public MauSacController()
		{
			Allrepositories<MauSac> repos = new Allrepositories<MauSac>(_shopDbContext, _shopDbContext.mauSacs);
			_iAllReposMS = repos;
		}


		[HttpGet("get-all-mausac")]
		public IEnumerable<MauSac> GetAll()
		{
			return _iAllReposMS.GetAllItem();
		}

		[HttpGet("get-mausac-by-id")]
		public MauSac GetMSById(Guid id)
		{
			return _iAllReposMS.GetById(id);

		}

		[HttpPost("create-mausac")]
		public bool CreateMauSac(string tenMauSac, int trangThai)
		{
			if (string.IsNullOrEmpty(tenMauSac))
			{
				return false;
			}
			var ms = new MauSac();
			ms.Id = Guid.NewGuid();
			ms.TenMauSac = tenMauSac;
			ms.TrangThai = trangThai;
			return _iAllReposMS.CreateItem(ms);
		}


		[HttpPut("update-mausac")]
		public bool UpdateMauSac(Guid id, string tenMauSac, int trangThai)
		{
            MauSac ms = _iAllReposMS.GetAllItem().First(p => p.Id == id);
			ms.Id = id;
			ms.TenMauSac = tenMauSac;
			ms.TrangThai = trangThai;
			return _iAllReposMS.UpdateItem(ms);
        }

		[HttpDelete]
		public bool DeleteMauSac(Guid id)
		{
			MauSac ms = _iAllReposMS.GetAllItem().First(c => c.Id == id);
			return _iAllReposMS.DeleteItem(ms);
		}
	}
}
