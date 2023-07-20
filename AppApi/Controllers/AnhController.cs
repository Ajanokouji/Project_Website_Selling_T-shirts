using AppData.AllRepository;
using AppData.Data;
using AppData.IAllrepository;
using Microsoft.AspNetCore.Mvc;

namespace AppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnhController : Controller
    {
        private IAllrepositories<Anh> irepos;
        private ShopDbContext context = new ShopDbContext();
        public AnhController()
        {
            Allrepositories<Anh> repos = new Allrepositories<Anh>(context, context.anhs);
            irepos = repos;
        }
        [HttpGet]
        public IEnumerable<Anh> Get()
        {
            return irepos.GetAllItem();
        }

        [HttpPost("Create")]
        public bool Create(string duongdan, int trangthai)
        {
            Anh anh = new Anh();
            anh.DuongDan= duongdan;
            anh.TrangThai = trangthai;
            return irepos.CreateItem(anh);
        }

        [HttpPut("Edit")]
        public bool Update(Guid id, string duongdan, int trangthai)
        {
            Anh anh = irepos.GetAllItem().First(p => p.Id == id);
            anh.DuongDan = duongdan;
            anh.TrangThai = trangthai;
            return irepos.UpdateItem(anh);
        }

        [HttpDelete("Delete")]
        public bool Delete(Guid id)
        {
            Anh anh = irepos.GetAllItem().First(p => p.Id == id);
            return irepos.DeleteItem(anh);
        }
    }
}
