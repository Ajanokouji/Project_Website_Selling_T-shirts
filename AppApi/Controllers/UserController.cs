using AppData.AllRepository;
using AppData.Data;
using AppData.IAllrepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        IAllrepositories<User> _repo;
        private ShopDbContext _context = new ShopDbContext();
        public UserController()
        {
            Allrepositories<User> repos = new Allrepositories<User>(_context, _context.users);
            _repo = repos;
        }


        [HttpGet("get-all")]
        public IEnumerable<User> GetAll()
        {
            var khachhangs = _repo.GetAllItem();
            return khachhangs;
        }
        [HttpGet("{id}")]
        public User GetById(Guid id)
        {
            var kh = _repo.GetById(id);
            return kh;
        }


        [HttpPost("create")]
        public bool CreateUser(
            Guid IdRole,
            string Ma,
            string Ten,
            string Anh,
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
            var kh = new User
            {
                Id = Guid.NewGuid(),
                IdRole = IdRole,
                Ma = Ma,
                Ten = Ten,
                Anh = Anh,
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
        public bool UpdateUser(
            Guid id,
            Guid IdRole,
            string Ma,
            string Ten,
            string Anh,
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
            var kh = _repo.GetById(id);
            if (kh == null)
                return false;
            kh.IdRole = IdRole;
            kh.Ma = Ma;
            kh.Ten = Ten;
            kh.Anh = Anh;
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
            var kh = _repo.GetById(id);
            if (kh == null)
                return false;
            return _repo.DeleteItem(kh);


        }
    }
}

