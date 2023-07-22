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

        [HttpPost]
        public IActionResult CreateHDCT(
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
            try
            { 
                return Ok(_repo.CreateItem(hdct));
            }
            catch 
            {
                return BadRequest();
            }
        }


        [HttpPut("{id}")]
        public IActionResult UpdateHDCT(
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
                return NotFound();

            hdct.IdHD = IdHD;
            hdct.IdCTSP = IdCTSP;
            hdct.IdGiamGia = IdGiamGia;
            hdct.SoLuong = SoLuong;
            hdct.DonGia = DonGia;
            return Ok(_repo.UpdateItem(hdct));
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteHDCT(Guid id)
        {
            var hdct = _repo.GetAllItem().FirstOrDefault(c => c.IdHD == id);
            if (hdct == null)
                return NotFound();
            try
            {
                return Ok(_repo.DeleteItem(hdct));
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
