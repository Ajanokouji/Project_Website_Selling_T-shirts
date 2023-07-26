using AppData.Data;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace AppView.Controllers
{
    public class GiamGiaController : Controller
    {
        Uri baseAddress = new Uri("https://localhost:7015/api");
        private readonly HttpClient _http;

        public GiamGiaController()
        {
            _http = new HttpClient();
            _http.BaseAddress = baseAddress;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var respone = await _http.GetAsync(baseAddress + "/giamgia/get-all");
            string apiData = await respone.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<GiamGia>>(apiData);
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(GiamGia gg)
        {
            string apiData = baseAddress + $"/GiamGia/create?Ma={gg.Ma}&Ten={gg.Ten}&NgayBatDau={gg.NgayBatDau}&NgayKetThuc={gg.NgayKetThuc}&MucGiamGiaPhanTram={gg.MucGiamGiaPhanTram}&MucGiamGiaTienMat={gg.MucGiamGiaTienMat}&TrangThai={gg.TrangThai}";
            var content = new StringContent(JsonConvert.SerializeObject(gg), Encoding.UTF8, "application/json");
            var response = await _http.PostAsync(apiData, content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(gg);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var response = await _http.GetAsync(baseAddress + $"/giamgia/{id}");

            string apiData = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<HoaDon>(apiData);
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, GiamGia gg)
        {
            string apiURL = baseAddress + $"/GiamGia/edit?id={id}&Ma={gg.Ma}&Ten={gg.Ten}&NgayBatDau={gg.NgayBatDau}&NgayKetThuc={gg.NgayKetThuc}&MucGiamGiaPhanTram={gg.MucGiamGiaPhanTram}&MucGiamGiaTienMat={gg.MucGiamGiaTienMat}&TrangThai={gg.TrangThai}";
            var content = new StringContent(JsonConvert.SerializeObject(gg), Encoding.UTF8, "application/json");
            var response = await _http.PutAsync(apiURL, content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View(gg);
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
