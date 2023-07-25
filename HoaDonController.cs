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


        [HttpPost("add")]
        public bool AddHoaDon(HoaDon item)
        {
            var hoadon = new HoaDon
            {
                Id = Guid.NewGuid(),
                IdKH = item.IdKH,
                IdNV = item.IdNV,
                Ma = item.Ma,
                TenNV = item.TenNV,
                TenKH = item.TenKH,
                NgayTao = item.NgayTao,
                NgayNhan = item.NgayNhan,
                NgayShip = item.NgayShip,
                NgayThanhToan = item.NgayThanhToan,
                DiaChi = item.DiaChi,
                TongTien = item.TongTien,
                TrangThai = item.TrangThai,
                SDTNguoiNhan = item.SDTNguoiNhan,
                SDTNguoiShip = item.SDTNguoiShip,
                TienShip = item.TienShip
            };
            return _repo.CreateItem(hoadon);
        }


        [HttpPut("update")]
        public bool UpdateHoaDon(HoaDon item)
        {
            var hoadon = _repo.GetById(item.Id);
            if(hoadon == null )
                return false;

            hoadon.IdKH = item.IdKH;
            hoadon.IdNV = item.IdNV;
            hoadon.Ma = item.Ma;
            hoadon.TenNV = item.TenNV;
            hoadon.TenKH = item.TenKH;
            hoadon.NgayTao = item.NgayTao;
            hoadon.NgayNhan = item.NgayNhan;
            hoadon.NgayShip = item.NgayShip;
            hoadon.NgayThanhToan = item.NgayThanhToan;
            hoadon.DiaChi = item.DiaChi;
            hoadon.TongTien = item.TongTien;
            hoadon.TrangThai = item.TrangThai;
            hoadon.SDTNguoiNhan = item.SDTNguoiNhan;
            hoadon.SDTNguoiShip = item.SDTNguoiShip;
            hoadon.TienShip = item.TienShip;
            return _repo.UpdateItem(hoadon);
        }

        [HttpDelete("delete")]
        public bool DeleteKichCo(Guid id)
        {
            var hoadon = _repo.GetById(id);
            return _repo.DeleteItem(hoadon);
        }
    }
}

