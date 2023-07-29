using AppData.AllRepository;
using AppData.Data;
using AppData.IAllrepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private IAllrepositories<Role> _Iallrepos;
        private ShopDbContext _shopdb = new ShopDbContext();

        public RoleController()
        {
            var _Repos = new Allrepositories<Role>(_shopdb, _shopdb.roles);
            _Iallrepos = _Repos;
        }
        [HttpGet]
        public IEnumerable<Role> Get()
        {
            return _Iallrepos.GetAllItem();
        }
        [HttpPost("Create")]
        public bool Create( string TenRole, int TrangThai)
        {
            //ChucVu result = new ChucVu();
            //result.Id = Guid.NewGuid();
            //result.TenChucVu = TenChucVu;
            //result.TrangThai = TrangThai;
            //return _Iallrepos.CreateItem(result);

            if (string.IsNullOrEmpty(TenRole)) return false;
            var result = new Role();
            result.Id = Guid.NewGuid();
            result.TenRole = TenRole;
            result.TrangThai = TrangThai;
            // check ten trung nhau
            return _Iallrepos.CreateItem(result); // tạo mới
        }

        [HttpPut("Edit")]
        public bool Update(Guid id, string TenRole, int TrangThai)
        {
            Role result = _Iallrepos.GetAllItem().First(p => p.Id == id);
            result.Id = id;
            result.TenRole = TenRole;
            result.TrangThai = TrangThai;
            return _Iallrepos.UpdateItem(result);
        }

        [HttpDelete("Delete")]
        public bool Delete(Guid id)
        {
            Role result = _Iallrepos.GetAllItem().First(p => p.Id == id);
            return _Iallrepos.DeleteItem(result);
        }
        [HttpGet("GetbyId-Role")]
        public Role GetbyIdRole(Guid Id)
        {
            return _Iallrepos.GetById(Id);
        }
    }
}
