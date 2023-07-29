using AppData.Data;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace AppView.Controllers
{
    public class UserController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7015/api");
        private readonly HttpClient _http;

        public UserController()
        {
            _http = new HttpClient();
            _http.BaseAddress = baseAddress;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var respone = await _http.GetAsync(baseAddress + "/User/get-all");
            string apiData = await respone.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<User>>(apiData);
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            string apiURL = baseAddress + $"/User/create?Id={user.IdRole}&Ma={user.Ma}&Ten={user.Ten}&Anh={user.Anh}&TenTaiKhoan={user.TenTaiKhoan}&MatKhau={user.MatKhau}&SDT={user.SDT}&NgaySinh={user.NgaySinh}&DiaChi={user.DiaChi}&GioiTinh={user.GioiTinh}&GhiChu={user.GhiChu}&TrangThai={user.TrangThai}";
            var content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
            var response = await _http.PostAsync(_http.BaseAddress + apiURL, content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(user);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var response = await _http.GetAsync(baseAddress + $"/User/{id}");

            string apiData = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<HoaDon>(apiData);
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, User user)
        {
            string apiURL = baseAddress + $"/User/edit?id={id}&Id={user.IdRole}&Ma={user.Ma}&Ten={user.Ten}&Anh={user.Anh}&TenTaiKhoan={user.TenTaiKhoan}&MatKhau={user.MatKhau}&SDT={user.SDT}&NgaySinh={user.NgaySinh}&DiaChi={user.DiaChi}&GioiTinh={user.GioiTinh}&GhiChu={user.GhiChu}&TrangThai={user.TrangThai}";
            var content = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
            var response = await _http.PutAsync(apiURL, content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(user);
        }
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _http.DeleteAsync(baseAddress + $"/User/delete/?id={id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return BadRequest();
        }
    }
}
