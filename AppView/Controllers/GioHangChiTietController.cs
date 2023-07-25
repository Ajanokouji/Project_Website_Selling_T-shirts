using AppData.Data;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using AppData.IAllrepository;
using AppData.AllRepository;
using System.Text;

namespace AppView.Controllers
{
    public class GioHangChiTietController : Controller
    {
        private HttpClient httpClient;
        public GioHangChiTietController()
        {
            httpClient = new HttpClient();
        }
        public async Task<IActionResult> ShowAll()
        {
            string apiUrl = "https://localhost:7015/api/GioHangChiTiet/Get-All";
            var response = await httpClient.GetAsync(apiUrl);
            string apiData = await response.Content.ReadAsStringAsync();
            var giohangct = JsonConvert.DeserializeObject<List<GioHangChiTiet>>(apiData);
            return View(giohangct);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(GioHangChiTiet ghct)
        {
            string apiURL = $"https://localhost:7015/api/GioHangChiTiet/Create?idctsp={ghct.IdCTSP}&soluong={ghct.SoLuong}";
            var content = new StringContent(JsonConvert.SerializeObject(ghct), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(apiURL, content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAll");
            }

            return View(ghct);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {

            string apiURL = $"https://localhost:7015/api/GioHangChiTiet/GetGHCTById?id={id}";

            var response = await httpClient.GetAsync(apiURL);

            string apiData = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<GioHangChiTiet>(apiData);
            return View(result);
        }

        public async Task<IActionResult> Edit(Guid id, GioHangChiTiet ghct)
        {

            var httpClient = new HttpClient();
            string apiURL = $"https://localhost:7015/api/GioHangChiTiet/Update?id={id}&soluong={ghct.SoLuong}";
            var content = new StringContent(JsonConvert.SerializeObject(ghct), Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync(apiURL, content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAll");
            }

            return View(ghct);
        }

        public async Task<IActionResult> Delete(Guid id)
        {

            string apiURL = $"https://localhost:7015/api/GioHangChiTiet/Delete?id={id}";

            var response = await httpClient.DeleteAsync(apiURL);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAll");
            }
            return BadRequest();
        }
    }
}
