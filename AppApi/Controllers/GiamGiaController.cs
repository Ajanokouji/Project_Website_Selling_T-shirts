using AppData.AllRepository;
using AppData.Data;
using AppData.IAllrepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace AppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GiamGiaController : ControllerBase
    {
        IAllrepositories<GiamGia> _repo;
        private ShopDbContext _context = new ShopDbContext();
        public GiamGiaController()
        {
            Allrepositories<GiamGia> repos = new Allrepositories<GiamGia>(_context, _context.giamGias);
            _repo = repos;
        }


        [HttpGet("get-all")]
        public IEnumerable<GiamGia> GetAll()
        {
            var respone = _repo.GetAllItem();
            return respone;
        }

        [HttpPost]
        public IActionResult CreateGiamGia(
              string Ma,
              string Ten,
              DateTime NgayBatDau,
              DateTime NgayKetThuc,
              double MucGiamGiaPhanTram,
              double MucGiamGiaTienMat,
              int TrangThai
            )
        {
            var giamgia = new GiamGia
            {
                Id = Guid.NewGuid(),
                Ma = Ma,
                Ten = Ten,
                NgayBatDau = NgayBatDau,
                NgayKetThuc = NgayKetThuc,
                MucGiamGiaPhanTram = MucGiamGiaPhanTram,
                MucGiamGiaTienMat = MucGiamGiaTienMat,
                TrangThai = TrangThai
            };
            try
            {
                return Ok(_repo.CreateItem(giamgia));
            }
            catch 
            {
                return BadRequest();
            }
        }


        [HttpPut("{id}")]
        public IActionResult UpdateGiamGia(
              Guid id,
              string Ma,
              string Ten,
              DateTime NgayBatDau,
              DateTime NgayKetThuc,
              double MucGiamGiaPhanTram,
              double MucGiamGiaTienMat,
              int TrangThai)
        {
            var giamgia = _repo.GetAllItem().FirstOrDefault(c => c.Id == id);
            if (giamgia == null)
                return NotFound();

            giamgia.Ma = Ma;
            giamgia.Ten = Ten;
            giamgia.NgayBatDau = NgayBatDau;
            giamgia.NgayKetThuc = NgayKetThuc;
            giamgia.MucGiamGiaPhanTram = MucGiamGiaPhanTram;
            giamgia.MucGiamGiaTienMat = MucGiamGiaTienMat;
            giamgia.TrangThai = TrangThai;
            return Ok(_repo.UpdateItem(giamgia));

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteGiamGia(Guid id)
        {
            var giamgia = _repo.GetAllItem().FirstOrDefault(c => c.Id == id);
            if (giamgia == null)
                return NotFound();
            try
            {
                return Ok(_repo.DeleteItem(giamgia));
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
