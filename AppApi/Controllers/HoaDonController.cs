using AppData.AllRepository;
using AppData.Data;
using AppData.IAllrepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HoaDonController : ControllerBase
    {
        IAllrepositories<HoaDon> _repo;
        private ShopDbContext _context = new ShopDbContext();
        public HoaDonController()
        {
            Allrepositories<HoaDon> repos = new Allrepositories<HoaDon>(_context, _context.hoaDons);
            _repo = repos;
        }


        [HttpGet("get-all")]
        public IEnumerable<HoaDon> GetAll()
        {  
           var hoadons = _repo.GetAllItem();        
           return hoadons;
        }
        [HttpGet("{id}")]
        public HoaDon GetById(Guid id) 
        {
            var hoadon = _repo.GetById(id);
            return hoadon;
        }


        [HttpPost("create")]
        public bool CreateHoaDon(
            Guid IdKH,
            Guid IdNV,
            string Ma,
            string TenNV,
            string TenKH,
            DateTime NgayTao,
            DateTime NgayNhan,
            DateTime NgayShip,
            DateTime NgayThanhToan,
            string DiaChi,
            decimal TongTien,
            int TrangThai,
            string SDTNguoiNhan,
            string SDTNguoiShip,
            decimal TienShip
            )
        {
            var hoadon = new HoaDon
            {
                Id = Guid.NewGuid(),
                IdKH = IdKH,
                IdNV = IdNV,
                Ma = Ma,
                TenNV = TenNV,
                TenKH = TenKH,
                NgayTao = NgayTao,
                NgayNhan = NgayNhan,
                NgayShip = NgayShip,
                NgayThanhToan = NgayThanhToan,
                DiaChi = DiaChi,
                TongTien = TongTien,
                TrangThai = TrangThai,
                SDTNguoiNhan = SDTNguoiNhan,
                SDTNguoiShip = SDTNguoiShip,
                TienShip = TienShip
            };
            return _repo.CreateItem(hoadon);
        }


        [HttpPut("edit")]
        public bool UpdateHoaDon(
            Guid id,
            Guid IdKH,
            Guid IdNV,
            string Ma,
            string TenNV,
            string TenKH,
            DateTime NgayTao,
            DateTime NgayNhan,
            DateTime NgayShip,
            DateTime NgayThanhToan,
            string DiaChi,
            decimal TongTien,
            int TrangThai,
            string SDTNguoiNhan,
            string SDTNguoiShip,
            decimal TienShip
            )
        {
            var hoadon = _repo.GetHDByID(id);
            if(hoadon == null )
                return false;

            hoadon.IdKH = IdKH;
            hoadon.IdNV = IdNV;
            hoadon.Ma = Ma;
            hoadon.TenNV = TenNV;
            hoadon.TenKH = TenKH;
            hoadon.NgayTao = NgayTao;
            hoadon.NgayNhan = NgayNhan;
            hoadon.NgayShip = NgayShip;
            hoadon.NgayThanhToan = NgayThanhToan;
            hoadon.DiaChi = DiaChi;
            hoadon.TongTien = TongTien;
            hoadon.TrangThai = TrangThai;
            hoadon.SDTNguoiNhan = SDTNguoiNhan;
            hoadon.SDTNguoiShip = SDTNguoiShip;
            hoadon.TienShip = TienShip;
            return _repo.UpdateItem(hoadon);
        }

        [HttpDelete("delete")]
        public bool DeleteKichCo(Guid id)
        {
            var hoadon = _repo.GetHDByID(id);
            return _repo.DeleteItem(hoadon);
        }
    }
}

