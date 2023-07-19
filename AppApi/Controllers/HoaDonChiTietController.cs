using AppData.AllRepository;
using AppData.Data;
using AppData.IAllrepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HoaDonChiTietController : ControllerBase
    {
        IAllrepositories<HoaDonChiTiet> _repo;
        private ShopDbContext _context = new ShopDbContext();
        public HoaDonChiTietController()
        {
            Allrepositories<HoaDonChiTiet> repos = new Allrepositories<HoaDonChiTiet>(_context, _context.hoaDonChiTiets);
            _repo = repos;
        }


        [HttpGet("get-all")]
        public IEnumerable<HoaDonChiTiet> GetAll()
        {
            var hdcts = _repo.GetAllItem();
            return hdcts;
        }

        [HttpPost("add")]
        public bool Add(HoaDonChiTiet item)
        {
            var hdct = new HoaDonChiTiet
            {
                IdHD = item.IdHD,
                IdCTSP = item.IdCTSP,
                IdGiamGia = item.IdGiamGia,
                SoLuong = item.SoLuong,
                DonGia = item.DonGia
            };
            return _repo.CreateItem(hdct);
        }


        [HttpPut("update")]
        public bool Update(HoaDonChiTiet item)
        {
            var hdct = _repo.GetAllItem().FirstOrDefault(c => c.IdHD == item.IdHD);
            if (hdct == null)
                return false;

            hdct.IdHD = item.IdHD;
            hdct.IdCTSP = item.IdCTSP;
            hdct.IdGiamGia = item.IdGiamGia;
            hdct.SoLuong = item.SoLuong;
            hdct.DonGia = item.DonGia;
            return _repo.UpdateItem(hdct);
        }

        [HttpDelete("delete")]
        public bool Delete(Guid id)
        {
            var hdct = _repo.GetAllItem().FirstOrDefault(c => c.IdHD == id);
            return _repo.DeleteItem(hdct);
        }
    }
}
