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

        [HttpPost("create")]
        public bool CreateHDCT(
            Guid IdHD,
            Guid IdCTSP,
            Guid IdGiamGia,
            int SoLuong,
            decimal DonGia
            )
        {
            var hdct = new HoaDonChiTiet
            {
                IdHD = IdHD,
                IdCTSP = IdCTSP,
                IdGiamGia = IdGiamGia,
                SoLuong = SoLuong,
                DonGia = DonGia
            };
            return _repo.CreateItem(hdct);
        }


        [HttpPut("edit")]
        public bool UpdateHDCT(
            Guid id,
            Guid IdHD,
            Guid IdCTSP,
            Guid IdGiamGia,
            int SoLuong,
            decimal DonGia
            )
        {
            var hdct = _repo.GetAllItem().FirstOrDefault(c => c.IdHD == id);
            if (hdct == null)
                return false;

            hdct.IdHD = IdHD;
            hdct.IdCTSP = IdCTSP;
            hdct.IdGiamGia = IdGiamGia;
            hdct.SoLuong = SoLuong;
            hdct.DonGia = DonGia;
            return _repo.UpdateItem(hdct);
        }

        [HttpDelete("delete")]
        public bool DeleteHDCT(Guid id)
        {
            var hdct = _repo.GetAllItem().FirstOrDefault(c => c.IdHD == id);
            if (hdct == null)
                return false;
            return _repo.DeleteItem(hdct);
        }
    }
}
