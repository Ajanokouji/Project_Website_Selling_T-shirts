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


        [HttpGet]
        public IEnumerable<KhachHang> GetAll()
        {
            return _repo.GetAllItem();
        }
        [HttpGet("{GetKHById}")]
        public KhachHang GetKHById(Guid id)
        {
            return _repo.GetById(id);
        }


        [HttpPost("Create")]
        public bool Create(string ma, string ten, string tentk, string matkhau, string sdt,
            DateTime ngaysinh, string diachi, int gioitinh, string ghichu, int trangthai)
        {
            KhachHang kh = new KhachHang();
            kh.Id = Guid.NewGuid();
            kh.Ma = ma;
            kh.Ten = ten;
            kh.TenTaiKhoan = tentk;
            kh.MatKhau = matkhau;
            kh.SDT = sdt;
            kh.NgaySinh = ngaysinh;
            kh.DiaChi = diachi;
            kh.GioiTinh = gioitinh;
            kh.GhiChu = ghichu;
            kh.TrangThai = trangthai;
            return _repo.CreateItem(kh);
        }


        [HttpPut("Update")]
        public bool Update(Guid id, string ma, string ten, string tentk, string matkhau, string sdt,
            DateTime ngaysinh, string diachi, int gioitinh, string ghichu, int trangthai)
        {
            KhachHang kh = _repo.GetAllItem().First(p => p.Id == id);
            kh.Id = id;
            kh.Ma = ma;
            kh.Ten = ten;
            kh.TenTaiKhoan = tentk;
            kh.MatKhau = matkhau;
            kh.SDT = sdt;
            kh.NgaySinh = ngaysinh;
            kh.DiaChi = diachi;
            kh.GioiTinh = gioitinh;
            kh.GhiChu = ghichu;
            kh.TrangThai = trangthai;
            return _repo.UpdateItem(kh);
        }

        [HttpDelete("Delete")]
        public bool Delete(Guid id)
        {
            KhachHang kh = _repo.GetAllItem().First(p => p.Id == id);
            return _repo.DeleteItem(kh);
        }
    }
}

