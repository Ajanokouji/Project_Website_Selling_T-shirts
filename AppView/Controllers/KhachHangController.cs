using AppData.Data;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace AppView.Controllers
{
    public class KhachHangController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7015/api");
        private readonly HttpClient _http;

        public KhachHangController()
        {
            _http = new HttpClient();
            _http.BaseAddress = baseAddress;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var respone = await _http.GetAsync(baseAddress + "/khachhang/get-all");
            string apiData = await respone.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<KhachHang>>(apiData);
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(KhachHang kh)
        {
            string apiURL = baseAddress + $"/khachhang/create?Ma={kh.Ma}&Ten={kh.Ten}&TenTaiKhoan={kh.TenTaiKhoan}&MatKhau={kh.MatKhau}&SDT={kh.SDT}&NgaySinh={kh.NgaySinh}&DiaChi={kh.DiaChi}&GioiTinh={kh.GioiTinh}&GhiChu={kh.GhiChu}&TrangThai={kh.TrangThai}";
            var content = new StringContent(JsonConvert.SerializeObject(kh), Encoding.UTF8, "application/json");
            var response = await _http.PostAsync(_http.BaseAddress + apiURL, content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(kh);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var response = await _http.GetAsync(baseAddress + $"/khachhang/{id}");

            string apiData = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<HoaDon>(apiData);
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, KhachHang kh)
        {
            string apiURL = baseAddress + $"/khachhang/edit?id={id}&Ma={kh.Ma}&Ten={kh.Ten}&TenTaiKhoan={kh.TenTaiKhoan}&MatKhau={kh.MatKhau}&SDT={kh.SDT}&NgaySinh={kh.NgaySinh}&DiaChi={kh.DiaChi}&GioiTinh={kh.GioiTinh}&GhiChu={kh.GhiChu}&TrangThai={kh.TrangThai}";
            var content = new StringContent(JsonConvert.SerializeObject(kh), Encoding.UTF8, "application/json");
            var response = await _http.PutAsync(apiURL, content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(kh);
        }
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _http.DeleteAsync(baseAddress + $"/khachhang/delete/?id={id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return BadRequest();
        }
    }
}
