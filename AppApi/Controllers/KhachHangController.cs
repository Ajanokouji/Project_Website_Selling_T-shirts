using AppData.AllRepository;
using AppData.Data;
using AppData.IAllrepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KhachHangController : ControllerBase
    {

        IAllrepositories<KhachHang> _repo;
        private ShopDbContext _context = new ShopDbContext();
        public KhachHangController()
        {
            Allrepositories<KhachHang> repos = new Allrepositories<KhachHang>(_context, _context.khachHangs);
            _repo = repos;
        }


        [HttpGet("get-all")]
        public IEnumerable<KhachHang> GetAll()
        {
            var khachhangs = _repo.GetAllItem();
            return khachhangs;
        }
        [HttpGet("{id}")]
        public KhachHang GetById(Guid id)
        {
            var kh = _repo.GetKHByID(id);
            return kh;
        }


        [HttpPost("add")]
        public bool Add(KhachHang item)
        {
            var kh = new KhachHang
            {
                Id = Guid.NewGuid(),
                Ma = item.Ma,
                Ten = item.Ten,
                TenTaiKhoan = item.TenTaiKhoan,
                MatKhau = item.MatKhau,
                SDT = item.SDT,
                NgaySinh = item.NgaySinh,
                DiaChi = item.DiaChi,
                GioiTinh = item.GioiTinh,
                GhiChu = item.GhiChu,
                TrangThai = item.TrangThai
            };
            return _repo.CreateItem(kh);
        }


        [HttpPut("update")]
        public bool Update(KhachHang item)
        {
            var kh = _repo.GetKHByID(item.Id);
            if (kh == null)
                return false;

            kh.Ma = item.Ma;
            kh.Ten = item.Ten;
            kh.TenTaiKhoan = item.TenTaiKhoan;
            kh.MatKhau = item.MatKhau;
            kh.SDT = item.SDT;
            kh.NgaySinh = item.NgaySinh;
            kh.DiaChi = item.DiaChi;
            kh.GioiTinh = item.GioiTinh;
            kh.GhiChu = item.GhiChu;
            kh.TrangThai = item.TrangThai;
            return _repo.UpdateItem(kh);
        }

        [HttpDelete("delete")]
        public bool Delete(Guid id)
        {
            var kh = _repo.GetKHByID(id);
            return _repo.DeleteItem(kh);
        }
    }
}

