using AppData.AllRepository;
using AppData.Data;
using AppData.IAllrepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace AppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SanPhamController : ControllerBase
    {
        private IAllrepositories<SanPham> _Iallrepos;
        private ShopDbContext _shopdb = new ShopDbContext();

        public SanPhamController()
        {
            var _Repos = new Allrepositories<SanPham>(_shopdb, _shopdb.sanPhams);
            _Iallrepos = _Repos;
        }
        [HttpGet]
        public IEnumerable<SanPham> Get()
        {
            return _Iallrepos.GetAllItem();
        }
        [HttpPost("Create")]
        public bool Create(string Ten, int TrangThai)
        {
            //SanPham result = new SanPham();
            //result.Id = Guid.NewGuid();
            //result.Ten = Ten;
            //result.TrangThai = TrangThai;
            //return _Iallrepos.CreateItem(result);

            if (string.IsNullOrEmpty(Ten)) return false;
            var result = new SanPham();
            result.Id = Guid.NewGuid();
            result.Ten = Ten;
            result.TrangThai = TrangThai;
            // check ten trung nhau
            return _Iallrepos.CreateItem(result); // tạo mới
        }

        [HttpPut("Edit")]
        public bool Update(Guid id, string Ten, int TrangThai)
        {
            SanPham result = _Iallrepos.GetAllItem().First(p => p.Id == id);
            result.Id = id;
            result.Ten = Ten;
            result.TrangThai = TrangThai;
            return _Iallrepos.UpdateItem(result);
        }

        [HttpDelete("Delete")]
        public bool Delete(Guid id)
        {
            SanPham result = _Iallrepos.GetAllItem().First(p => p.Id == id);
            return _Iallrepos.DeleteItem(result);
        }
    }
}
