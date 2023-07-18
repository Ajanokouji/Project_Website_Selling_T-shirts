using AppData.AllRepository;
using AppData.Data;
using AppData.IAllrepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class KichCoController : ControllerBase
	{
		IAllrepositories<KichCo> _iAllReposKC;
		private ShopDbContext _shopDbContext = new ShopDbContext();
        public KichCoController()
        {
            Allrepositories<KichCo> repos = new Allrepositories<KichCo>(_shopDbContext, _shopDbContext.kichCos);
			_iAllReposKC = repos;
        }


		[HttpGet("get-all-kichco")]
		public IEnumerable<KichCo> GetAll()
		{
			return _iAllReposKC.GetAllItem();
		}


		[HttpPost("create-kichco")]
		public bool CreateKichCo(string size, int trangThai)
		{
			KichCo kc = new KichCo();
			kc.Id = Guid.NewGuid();
			kc.Size = size;
			kc.TrangThai = trangThai;
			return _iAllReposKC.CreateItem(kc);
		}


		[HttpPut("update-kichco")]
		public bool UpdateKichCo(Guid id, string size, int trangThai)
		{
			KichCo kc = _iAllReposKC.GetAllItem().First(c => c.Id == id);
			kc.Id = id;
			kc.Size = size;
			kc.TrangThai = trangThai;
			return _iAllReposKC.UpdateItem(kc);
		}

		[HttpDelete]
		public bool DeleteKichCo(Guid id)
		{
			KichCo kc = _iAllReposKC.GetAllItem().First(c => c.Id == id);
			return _iAllReposKC.DeleteItem(kc);
		}
	}
}
