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

        [HttpPost("Create")]
        public bool Create(Guid IdKH, string mota, int trangthai)
        {
            GioHang gh = new GioHang();
            gh.IdKH = IdKH;
            gh.Mota = mota;
            gh.TrangThai = trangthai;
            return _Irepos.CreateItem(gh);
        }

        [HttpPut("Edit")]
        public bool Update(Guid Id, Guid IdKH, string mota, int trangthai)
        {
            GioHang gh = _Irepos.GetAllItem().First(p => p.Id == Id);
            gh.IdKH = IdKH;
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
