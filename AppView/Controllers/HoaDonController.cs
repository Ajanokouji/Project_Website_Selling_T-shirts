using AppData.Data;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace AppView.Controllers
{
    public class HoaDonController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7015/api");
        private readonly HttpClient _http;

        public HoaDonController()
        {
            _http = new HttpClient();
            _http.BaseAddress = baseAddress;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var respone = await _http.GetAsync(baseAddress + "/hoadon/get-all");
            string apiData = await respone.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<HoaDon>>(apiData);
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(HoaDon hd)
        {
            string apiData = baseAddress + $"/HoaDon/create?IdKH={hd.IdKH}&IdNV={hd.IdNV}&Ma={hd.Ma}&TenNV={hd.TenNV}&TenKH={hd.TenKH}&NgayTao={hd.NgayTao}&NgayNhan={hd.NgayNhan}&NgayShip={hd.NgayShip}&NgayThanhToan={hd.NgayThanhToan}&DiaChi={hd.DiaChi}&TongTien={hd.TongTien}&TrangThai={hd.TrangThai}&SDTNguoiNhan={hd.SDTNguoiNhan}&SDTNguoiShip={hd.SDTNguoiShip}&TienShip={hd.TienShip}";
            var content = new StringContent(JsonConvert.SerializeObject(hd), Encoding.UTF8, "application/json");
            var response = await _http.PostAsync(apiData, content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(hd);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var response = await _http.GetAsync(baseAddress + $"/hoadon/{id}");

            string apiData = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<HoaDon>(apiData);
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, HoaDon hd)
        {
            string apiURL = baseAddress + $"/HoaDon/edit?id={id}&IdKH={hd.IdKH}&IdNV={hd.IdNV}&Ma={hd.Ma}&TenNV={hd.TenNV}&TenKH={hd.TenKH}&NgayTao={hd.NgayTao}&NgayNhan={hd.NgayNhan}&NgayShip={hd.NgayShip}&NgayThanhToan={hd.NgayThanhToan}&DiaChi={hd.DiaChi}&TongTien={hd.TongTien}&TrangThai={hd.TrangThai}&SDTNguoiNhan={hd.SDTNguoiNhan}&SDTNguoiShip={hd.SDTNguoiShip}&TienShip={hd.TienShip}";
            var content = new StringContent(JsonConvert.SerializeObject(hd), Encoding.UTF8, "application/json");
            var response = await _http.PutAsync(apiURL, content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View(hd);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _http.DeleteAsync(_http.BaseAddress + $"/HoaDon/Delete/?id={id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return BadRequest();
        }
    }
}
