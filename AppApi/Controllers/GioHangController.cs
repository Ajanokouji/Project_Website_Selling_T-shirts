using Microsoft.AspNetCore.Mvc;
using AppData.Data;
using AppData.IAllrepository;
using AppData.AllRepository;

namespace AppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GioHangController : ControllerBase
    {
        private IAllrepositories<GioHang> _Irepos;
        private ShopDbContext context = new ShopDbContext();

        public GioHangController()
        {
            Allrepositories<GioHang> repos = new Allrepositories<GioHang>(context, context.gioHangs);
            _Irepos = repos;
        }
        [HttpGet("Get-All")]
        public IEnumerable<GioHang> Get()
        {
            return _Irepos.GetAllItem();
        }

        [HttpGet("GetGHById")]
        public GioHang GetGHById(Guid id)
        {
            return _Irepos.GetById(id);
        }

        [HttpPost("Create")]
        public bool Create(Guid idUser, string mota, int trangthai)
        {
            GioHang gh = new GioHang();
            gh.Id = Guid.NewGuid();
            gh.IdUser = idUser;
            gh.Mota = mota;
            gh.TrangThai = trangthai;
            return _Irepos.CreateItem(gh);
        }

        [HttpPut("Edit")]
        public bool Update(Guid id, Guid idUser, string mota, int trangthai)
        {
            GioHang gh = _Irepos.GetAllItem().First(p => p.Id == id);
            gh.Id = id;
            gh.IdUser = idUser;
            gh.Mota = mota;
            gh.TrangThai = trangthai;
            return _Irepos.UpdateItem(gh);
        }

        [HttpDelete("Delete")]
        public bool Delete(Guid id)
        {
            GioHang gh = _Irepos.GetAllItem().First(p => p.Id == id);
            return _Irepos.DeleteItem(gh);
        }
    }
}
