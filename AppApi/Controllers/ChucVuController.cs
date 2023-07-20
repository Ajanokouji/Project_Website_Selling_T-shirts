using AppData.AllRepository;
using AppData.Data;
using AppData.IAllrepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChucVuController : ControllerBase
    {
        private IAllrepositories<ChucVu> _Iallrepos;
        private ShopDbContext _shopdb = new ShopDbContext();

        public ChucVuController()
        {
            var _Repos = new Allrepositories<ChucVu>(_shopdb, _shopdb.chucVus);
            _Iallrepos = _Repos;
        }
        [HttpGet]
        public IEnumerable<ChucVu> Get()
        {
            return _Iallrepos.GetAllItem();
        }
        [HttpPost("Create")]
        public bool Create( string TenChucVu, int TrangThai)
        {
            //ChucVu result = new ChucVu();
            //result.Id = Guid.NewGuid();
            //result.TenChucVu = TenChucVu;
            //result.TrangThai = TrangThai;
            //return _Iallrepos.CreateItem(result);

            if (string.IsNullOrEmpty(TenChucVu)) return false;
            var result = new ChucVu();
            result.Id = Guid.NewGuid();
            result.TenChucVu = TenChucVu;
            result.TrangThai = TrangThai;
            // check ten trung nhau
            return _Iallrepos.CreateItem(result); // tạo mới
        }

        [HttpPut("Edit")]
        public bool Update(Guid id, string TenChucVu, int TrangThai)
        {
            ChucVu result = _Iallrepos.GetAllItem().First(p => p.Id == id);
            result.Id = id;
            result.TenChucVu = TenChucVu;
            result.TrangThai = TrangThai;
            return _Iallrepos.UpdateItem(result);
        }

        [HttpDelete("Delete")]
        public bool Delete(Guid id)
        {
            ChucVu result = _Iallrepos.GetAllItem().First(p => p.Id == id);
            return _Iallrepos.DeleteItem(result);
        }
    }
}
