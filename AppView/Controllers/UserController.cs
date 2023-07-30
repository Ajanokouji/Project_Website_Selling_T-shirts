using AppData.Data;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace AppView.Controllers
{
    public class UserController : Controller
    {
        private HttpClient httpClient;
        public UserController()
        {
            httpClient = new HttpClient();
        }
        public async Task<IActionResult> ShowAll()
        {

            string apiURL = "https://localhost:7015/api/User/get-all";


            var response = await httpClient.GetAsync(apiURL);
            string apiData = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<User>>(apiData);
            return View(result);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            string apiURL = $"https://localhost:7015/api/User/create?IdRole={user.IdRole}&Ma={user.Ma}&Ten={user.Ten}&Anh={user.Anh}&TenTaiKhoan={user.TenTaiKhoan}&MatKhau={user.MatKhau}&SDT={user.SDT}&NgaySinh={user.NgaySinh}&DiaChi={user.DiaChi}&GioiTinh={user.GioiTinh}&GhiChu={user.GhiChu}&TrangThai={user.TrangThai}";
            var content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync(apiURL, content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAll");
            }

            return View(user);

        }
        //[HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {

            string apiURL = $"https://localhost:7015/api/User/id?id={id}";

            var response = await httpClient.GetAsync(apiURL);

            string apiData = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<User>(apiData);
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Guid Id, User user)
        {

            string apiURL = $"https://localhost:7015/api/User/edit?id={user.Id}&IdRole={user.IdRole}&Ma={user.Ma}&Ten={user.Ten}&Anh={user.Anh}&TenTaiKhoan={user.TenTaiKhoan}&MatKhau={user.MatKhau}&SDT={user.SDT}&NgaySinh={user.NgaySinh}&DiaChi={user.DiaChi}&GioiTinh={user.GioiTinh}&GhiChu={user.GhiChu}&TrangThai={user.TrangThai}";
            var content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");

            var response = await httpClient.PutAsync(apiURL, content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAll");
            }


            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            string apiURL = $"https://localhost:7015/api/User/delete?id={id}";

            var response = await httpClient.DeleteAsync(apiURL);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAll");
            }

            return RedirectToAction("ShowAll");
        }
    }
}
