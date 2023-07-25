using AppData.AllRepository;
using AppData.Data;
using AppData.IAllrepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LoaiController : ControllerBase
	{
		IAllrepositories<Loai> _iAllReposLoai;
		private ShopDbContext _shopDbContext = new ShopDbContext();
		public LoaiController()
		{
			Allrepositories<Loai> repos = new Allrepositories<Loai>(_shopDbContext, _shopDbContext.loais);
			_iAllReposLoai = repos;
		}


		[HttpGet("get-all-loai")]
		public IEnumerable<Loai> GetAll()
		{
			return _iAllReposLoai.GetAllItem();
		}

        [HttpGet("get-loai-by-id")]
        public Loai GetLoaiById(Guid id)
        {
			return _iAllReposLoai.GetById(id);

        }

        [HttpPost("create-loai")]
		public bool CreateLoai(string tenLoai, int trangThai)
		{
			Loai loai = new Loai();
			loai.Id = Guid.NewGuid();
			loai.TenLoai = tenLoai;
			loai.TrangThai = trangThai;
			return _iAllReposLoai.CreateItem(loai);
		}


		[HttpPut("update-loai")]
		public bool UpdateLoai(Guid id, string tenLoai, int trangThai)
		{
			Loai loai = _iAllReposLoai.GetAllItem().First(c => c.Id == id);
			loai.Id = id;
			loai.TenLoai = tenLoai;
			loai.TrangThai = trangThai;
			return _iAllReposLoai.UpdateItem(loai);
		}

		[HttpDelete]
		public bool DeleteLoai(Guid id)
		{
			Loai loai = _iAllReposLoai.GetAllItem().First(c => c.Id == id);
			return _iAllReposLoai.DeleteItem(loai);
		}
	}
}
