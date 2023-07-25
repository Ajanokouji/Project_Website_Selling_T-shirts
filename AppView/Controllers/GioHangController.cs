using AppData.Data;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using AppData.IAllrepository;
using AppData.AllRepository;
using System.Net.Http;
using System.Text;

namespace AppView.Controllers
{
    public class GioHangController : Controller
    {
        private HttpClient httpClient;
        public GioHangController()
        {
            httpClient = new HttpClient();
        }
        public async Task<IActionResult> ShowAll()
        {
            string apiUrl = "https://localhost:7015/api/GioHang/Get-All";
            var response = await httpClient.GetAsync(apiUrl);
            string apiData = await response.Content.ReadAsStringAsync();
            var giohang = JsonConvert.DeserializeObject<List<GioHang>>(apiData);
            return View(giohang);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(GioHang gh)
        {
            string apiURL = $"https://localhost:7015/api/GioHang/Create?idkh={gh.IdKH}&mota={gh.Mota}&trangthai={gh.TrangThai}";
            var content = new StringContent(JsonConvert.SerializeObject(gh), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(apiURL, content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAll");
            }

            return View(gh);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {

            string apiURL = $"https://localhost:7015/api/GioHang/GetGHById?id={id}";

            var response = await httpClient.GetAsync(apiURL);

            string apiData = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<GioHang>(apiData);
            return View(result);
        }

        public async Task<IActionResult> Edit(Guid id, GioHang gh)
        {

            var httpClient = new HttpClient();
            string apiURL = $"https://localhost:7015/api/GioHang/Edit?id={id}&idkh={gh.IdKH}&mota={gh.Mota}&trangthai={gh.TrangThai}";
            var content = new StringContent(JsonConvert.SerializeObject(gh), Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync(apiURL, content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAll");
            }

            return View(gh);
        }

        public async Task<IActionResult> Delete(Guid id)
        {

            string apiURL = $"https://localhost:7015/api/GioHang/Delete?id={id}";

            var response = await httpClient.DeleteAsync(apiURL);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAll");
            }
            return BadRequest();
        }
    }
}
