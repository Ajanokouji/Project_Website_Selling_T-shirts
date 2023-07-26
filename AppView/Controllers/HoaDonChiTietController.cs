using AppData.Data;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace AppView.Controllers
{
    public class HoaDonChiTietController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7015/api");
        private readonly HttpClient _http;

        public HoaDonChiTietController()
        {
            _http = new HttpClient();
            _http.BaseAddress = baseAddress;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var respone = await _http.GetAsync(baseAddress + "/hoadonchitiet/get-all");
            string apiData = await respone.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<HoaDonChiTiet>>(apiData);
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(HoaDonChiTiet hd)
        {
            string apiData = baseAddress + $"/hoadonchitiet/create?IdHD={hd.IdHD}&IdCTSP={hd.IdCTSP}&IdGiamGia={hd.IdGiamGia}&SoLuong={hd.SoLuong}&DonGia={hd.DonGia}";
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
            var response = await _http.GetAsync(baseAddress + $"/hoadonchitiet/{id}");

            string apiData = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<HoaDon>(apiData);
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, HoaDonChiTiet hd)
        {
            string apiURL = baseAddress + $"/hoadonchitiet/edit?id={id}&IdHD={hd.IdHD}&IdCTSP={hd.IdCTSP}&IdGiamGia={hd.IdGiamGia}&SoLuong={hd.SoLuong}&DonGia={hd.DonGia}";
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
            var response = await _http.DeleteAsync(_http.BaseAddress + $"/hoadonchitiet/Delete/?id={id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return BadRequest();
        }
    }
}
