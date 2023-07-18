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
		private ShopDbContext _shopDbContext = new ShopDbContext();
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


		[HttpPost("create-mausac")]
		public bool CreateMauSac(string tenMauSac, int trangThai)
		{
			MauSac ms = new MauSac();
			ms.Id = Guid.NewGuid();
			ms.TenMauSac = tenMauSac;
			ms.TrangThai = trangThai;
			return _iAllReposMS.CreateItem(ms);
		}


		[HttpPut("update-mausac")]
		public bool UpdateMauSac(Guid id, string tenMauSac, int trangThai)
		{
			MauSac ms = _iAllReposMS.GetAllItem().First(c => c.Id == id);
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
