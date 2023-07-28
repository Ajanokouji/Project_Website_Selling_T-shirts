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
            var kh = _repo.GetAllItem().FirstOrDefault(i => i.Id == id);
            return kh;
        }


        [HttpPost("create")]
        public bool CreateKhachHang(
            string Ma,
            string Ten,
            string TenTaiKhoan,
            string MatKhau,
            string SDT,
            DateTime NgaySinh,
            string DiaChi,
            int GioiTinh,
            string GhiChu,
            int TrangThai
            )
        {
            var kh = new KhachHang
            {
                Id = Guid.NewGuid(),
                Ma = Ma,
                Ten = Ten,
                TenTaiKhoan = TenTaiKhoan,
                MatKhau = MatKhau,
                SDT = SDT,
                NgaySinh = NgaySinh,
                DiaChi = DiaChi,
                GioiTinh = GioiTinh,
                GhiChu = GhiChu,
                TrangThai = TrangThai
            };
            return _repo.CreateItem(kh);
        }


        [HttpPut("edit")]
        public bool UpdateKhachHang(
            Guid id,
            string Ma,
            string Ten,
            string TenTaiKhoan,
            string MatKhau,
            string SDT,
            DateTime NgaySinh,
            string DiaChi,
            int GioiTinh,
            string GhiChu,
            int TrangThai
            )
        {
            var kh = _repo.GetKHByID(id);
            if (kh == null)
                return false;

            kh.Ma = Ma;
            kh.Ten = Ten;
            kh.TenTaiKhoan = TenTaiKhoan;
            kh.MatKhau = MatKhau;
            kh.SDT = SDT;
            kh.NgaySinh = NgaySinh;
            kh.DiaChi = DiaChi;
            kh.GioiTinh = GioiTinh;
            kh.GhiChu = GhiChu;
            kh.TrangThai = TrangThai;
            return _repo.UpdateItem(kh);
        }

        [HttpDelete("delete")]
        public bool Delete(Guid id)
        {
            var kh = _repo.GetKHByID(id);
            if (kh == null)
                return false;
            return _repo.DeleteItem(kh);


        }
    }
}

