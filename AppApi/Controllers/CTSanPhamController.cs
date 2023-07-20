using AppData.AllRepository;
using AppData.Data;
using AppData.IAllrepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CTSanPhamController : ControllerBase
    {
        private IAllrepositories<ChiTietSanPham> _Iallrepos;
        private ShopDbContext _shopdb = new ShopDbContext();

        public CTSanPhamController()
        {
            var _Repos = new Allrepositories<ChiTietSanPham>(_shopdb, _shopdb.chiTietSanPhams);
            _Iallrepos = _Repos;
        }
        [HttpGet]
        public IEnumerable<ChiTietSanPham> Get()
        {
            return _Iallrepos.GetAllItem();
        }
        [HttpPost("Create")]
        public bool Create(
            Guid IdSP,
            Guid IdAnh,
            Guid IdKC,
            Guid IdMS,
            Guid IdLoai,
            Guid IdCL,
            decimal GiaNhap,
            decimal GiaBan,
            string MoTa,
            int TrangThai)
        {

            ChiTietSanPham result = new ChiTietSanPham();
            result.Id = Guid.NewGuid();
            result.IdSP = IdSP;
            result.IdAnh = IdAnh;
            result.IdKC = IdKC;
            result.IdMS = IdMS;
            result.IdLoai = IdLoai;
            result.IdCL = IdCL;
            result.GiaNhap = GiaNhap;
            result.GiaBan = GiaBan;
            result.Mota = MoTa;
            result.TrangThai = TrangThai;       
            // check name trung nhau
            return _Iallrepos.CreateItem(result); // tạo result mới
        }
        [HttpPut("Edit")]
        public bool Update(Guid id, Guid IdSP,
            Guid IdAnh,
            Guid IdKC,
            Guid IdMS,
            Guid IdLoai,
            Guid IdCL,
            decimal GiaNhap,
            decimal GiaBan,
            string MoTa,
            int TrangThai)
        {
            ChiTietSanPham result = _Iallrepos.GetAllItem().First(p => p.Id == id);
            result.Id = id;
            result.IdSP = IdSP;
            result.IdAnh = IdAnh;
            result.IdKC = IdKC;
            result.IdMS = IdMS;
            result.IdLoai = IdLoai;
            result.IdCL = IdCL;
            result.GiaNhap = GiaNhap;
            result.GiaBan = GiaBan;
            result.Mota = MoTa;
            result.TrangThai = TrangThai;
            return _Iallrepos.UpdateItem(result);
        }

        [HttpDelete("Delete")]
        public bool Delete(Guid id)
        {
            ChiTietSanPham result = _Iallrepos.GetAllItem().First(p => p.Id == id);
            return _Iallrepos.DeleteItem(result);
        }
    }
}
