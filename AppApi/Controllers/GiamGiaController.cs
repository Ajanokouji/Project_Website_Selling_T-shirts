using AppData.AllRepository;
using AppData.Data;
using AppData.IAllrepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost("add")]
        public bool Add(GiamGia item)
        {
            var giamgia = new GiamGia
            {
                Id = Guid.NewGuid(),
                Ma = item.Ma,
                Ten = item.Ten,
                NgayBatDau = item.NgayBatDau,
                NgayKetThuc = item.NgayKetThuc,
                MucGiamGiaPhanTram = item.MucGiamGiaPhanTram,
                MucGiamGiaTienMat = item.MucGiamGiaTienMat,
                TrangThai = item.TrangThai
            };
            return _repo.CreateItem(giamgia);
        }


        [HttpPut("update")]
        public bool Update(GiamGia item)
        {
            var giamgia = _repo.GetAllItem().FirstOrDefault(c => c.Id == item.Id);
            if (giamgia == null)
                return false;

            giamgia.Ma = item.Ma;
            giamgia.Ten = item.Ten;
            giamgia.NgayBatDau = item.NgayBatDau;
            giamgia.NgayKetThuc = item.NgayKetThuc;
            giamgia.MucGiamGiaPhanTram = item.MucGiamGiaPhanTram;
            giamgia.MucGiamGiaTienMat = item.MucGiamGiaTienMat;
            giamgia.TrangThai = item.TrangThai;
            return _repo.UpdateItem(giamgia);
        }

        [HttpDelete("delete")]
        public bool Delete(Guid id)
        {
            var giamgia = _repo.GetAllItem().FirstOrDefault(c => c.Id == id);
            return _repo.DeleteItem(giamgia);
        }
    }
}
