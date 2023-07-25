using Microsoft.AspNetCore.Mvc;
using AppData.Data;
using AppData.IAllrepository;
using AppData.AllRepository;

namespace AppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GioHangChiTietController : ControllerBase
    {
        private IAllrepositories<GioHangChiTiet> _Irepos;
        private ShopDbContext context = new ShopDbContext();

        public GioHangChiTietController()
        {
            Allrepositories<GioHangChiTiet> repos = new Allrepositories<GioHangChiTiet>(context, context.gioHangChiTiets);
            _Irepos = repos;
        }
        [HttpGet("Get-All")]
        public IEnumerable<GioHangChiTiet> Get()
        {
            return _Irepos.GetAllItem();
        }


        [HttpPost("Create")]
        public bool Create(Guid idctsp, int soluong)
        {
            GioHangChiTiet ghct = new GioHangChiTiet();
            ghct.Id = Guid.NewGuid();
            ghct.IdCTSP = idctsp;
            ghct.SoLuong = soluong;
            return _Irepos.CreateItem(ghct);
        }

        [HttpPut("Update")]
        public bool Update(Guid id, int soluong)
        {
            GioHangChiTiet ghct = _Irepos.GetAllItem().First(p => p.Id == id);
            ghct.Id = id;
            ghct.SoLuong = soluong;
            return _Irepos.UpdateItem(ghct);
        }

        [HttpDelete("Delete")]
        public bool Delete(Guid id)
        {
            GioHangChiTiet ghct = _Irepos.GetAllItem().First(p => p.Id == id);
            return _Irepos.DeleteItem(ghct);
        }
    }
}
