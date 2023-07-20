using AppData.AllRepository;
using AppData.Data;
using AppData.IAllrepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatLieuController : ControllerBase
    {
        private IAllrepositories<ChatLieu> _Iallrepos;
        private ShopDbContext _shopdb = new ShopDbContext();
        
        public ChatLieuController()
        {
            var _Repos = new Allrepositories<ChatLieu>(_shopdb, _shopdb.chatLieus);
            _Iallrepos = _Repos;
        }
        [HttpGet]
        public IEnumerable<ChatLieu> Get()
        {
            return _Iallrepos.GetAllItem();
        }
        [HttpPost("Create")]
        public bool Create( string TenChatLieu, int TrangThai)
        {
            //ChatLieu result = new ChatLieu( );
            //result.Id = Guid.NewGuid();
            //result.TenChatLieu = TenChatLieu;
            //result.TrangThai = TrangThai;
            //return _Iallrepos.CreateItem(result);

            if (string.IsNullOrEmpty(TenChatLieu)) return false;
            var result = new ChatLieu();
            result.Id = Guid.NewGuid();
            result.TenChatLieu = TenChatLieu;
            result.TrangThai = TrangThai;
            // check ten trung nhau
            return _Iallrepos.CreateItem(result); // tạo mới
        }

        [HttpPut("Edit")]
        public bool Update(Guid id, string TenChatLieu, int TrangThai)
        {
            ChatLieu result = _Iallrepos.GetAllItem().First(p => p.Id == id);
            result.Id = id;
            result.TenChatLieu = TenChatLieu;
            result.TrangThai = TrangThai;
            return _Iallrepos.UpdateItem(result);
        }

        [HttpDelete("Delete")]
        public bool Delete(Guid id)
        {
            ChatLieu result = _Iallrepos.GetAllItem().First(p => p.Id == id);
            return _Iallrepos.DeleteItem(result);
        }

    }
}
