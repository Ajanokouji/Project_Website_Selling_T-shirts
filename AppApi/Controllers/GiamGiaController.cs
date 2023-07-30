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

        [HttpGet("GetbyId-GiamGia")]
        public GiamGia GetbyId(Guid Id)
        {
            return _repo.GetById(Id);
        }

        [HttpPost("create")]
        public bool CreateGiamGia(
              string Ma,
              string Ten,
              DateTime NgayBatDau,
              DateTime NgayKetThuc,
              double MucGiamGiaPhanTram,
              double MucGiamGiaTienMat,
              int TrangThai
            )
        {
            if (string.IsNullOrEmpty(Ten)) return false;
            var result = new GiamGia();
            result.Id = Guid.NewGuid();
            result.Ma = Ma;
            result.Ten = Ten;
            result.NgayBatDau = NgayBatDau;
            result.NgayKetThuc = NgayKetThuc;
            result.MucGiamGiaPhanTram = MucGiamGiaPhanTram;
            result.MucGiamGiaTienMat = MucGiamGiaTienMat;
            result.TrangThai = TrangThai;
            // check ten trung nhau
            return _repo.CreateItem(result); // tạo mới
        }


        [HttpPut("edit")]
        public bool UpdateGiamGia(
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
                return false;

            giamgia.Ma = Ma;
            giamgia.Ten = Ten;
            giamgia.NgayBatDau = NgayBatDau;
            giamgia.NgayKetThuc = NgayKetThuc;
            giamgia.MucGiamGiaPhanTram = MucGiamGiaPhanTram;
            giamgia.MucGiamGiaTienMat = MucGiamGiaTienMat;
            giamgia.TrangThai = TrangThai;
            return _repo.UpdateItem(giamgia);
        }

        [HttpDelete("delete")]
        public bool DeleteGiamGia(Guid id)
        {
            var giamgia = _repo.GetAllItem().FirstOrDefault(c => c.Id == id);
            if (giamgia == null)
                return false;
            return _repo.DeleteItem(giamgia);
        }
    }
}
