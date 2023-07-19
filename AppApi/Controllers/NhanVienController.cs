using Microsoft.AspNetCore.Mvc;
using AppData.Data;
using AppData.IAllrepository;
using AppData.AllRepository;

namespace AppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NhanVienController : Controller
    {
        private IAllrepositories<NhanVien> irepos;
        private ShopDbContext context = new ShopDbContext();
        public NhanVienController()
        {
            Allrepositories<NhanVien> repos = new Allrepositories<NhanVien>(context, context.nhanViens);
            irepos = repos;
        }
        [HttpGet]
        public IEnumerable<NhanVien> Get()
        {
            return irepos.GetAllItem();
        }

        [HttpPost("Create")]
        public bool Create(Guid idcv, string ten, string tentk, string matkhau,
            string anh, string email, int trangthai)
        {
            NhanVien nhanvien = new NhanVien();
            nhanvien.IdCV = idcv;
            nhanvien.Ten = ten;
            nhanvien.TenTaiKhoan= tentk;
            nhanvien.MatKhau = matkhau;
            nhanvien.Anh = anh;
            nhanvien.Email = email;
            nhanvien.TrangThai = trangthai;
            return irepos.CreateItem(nhanvien);
        }

        [HttpPut("Edit")]
        public bool Update(Guid id, Guid idcv, string ten, string tentk, string matkhau,
            string anh, string email, int trangthai)
        {
            NhanVien nhanvien = irepos.GetAllItem().First(p => p.Id == id);
            nhanvien.IdCV = idcv;
            nhanvien.Ten = ten;
            nhanvien.TenTaiKhoan = tentk;
            nhanvien.MatKhau = matkhau;
            nhanvien.Anh = anh;
            nhanvien.Email = email;
            nhanvien.TrangThai = trangthai;
            return irepos.UpdateItem(nhanvien);
        }

        [HttpDelete("Delete")]
        public bool Delete(Guid id)
        {
            NhanVien nhanvien = irepos.GetAllItem().First(p => p.Id == id);
            return irepos.DeleteItem(nhanvien);
        }
    }
}
