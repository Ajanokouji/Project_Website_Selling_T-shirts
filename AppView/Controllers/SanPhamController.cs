using AppData.Data;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace AppView.Controllers
{
    public class SanPhamController : Controller
    {
        private HttpClient httpClient;
        public SanPhamController()
        {
            httpClient = new HttpClient();
        }
        public async Task<IActionResult> ShowAll()
        {
            
            string apiURL = "https://localhost:7015/api/SanPham/";
            var response = await httpClient.GetAsync(apiURL);
            string apiData = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<SanPham>>(apiData);
            return View(result);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(SanPham sanPham)
        {
            string apiURL = $"https://localhost:7015/api/SanPham/Create?Ten={sanPham.Ten}&TrangThai={sanPham.TrangThai}";
            var content = new StringContent(JsonConvert.SerializeObject(sanPham), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(apiURL, content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAll");
            }


            return View(sanPham);
        }


        public async Task<IActionResult> Edit(Guid id)
        {
            
            string apiURL = $"https://localhost:7015/api/SanPham/GetbyId-SanPham?Id={id}";

            var response = await httpClient.GetAsync(apiURL);

            string apiData = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<SanPham>(apiData);
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Guid id , SanPham sanPham)
        {


            string apiURL = $"https://localhost:7015/api/SanPham/Edit?id={id}&Ten={sanPham.Ten}&TrangThai={sanPham.TrangThai}";

            var content = new StringContent(JsonConvert.SerializeObject(sanPham), Encoding.UTF8, "application/json");
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
            
            string apiURL = $"https://localhost:7015/api/SanPham/Delete?id={id}";

            var response = await httpClient.DeleteAsync(apiURL);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAll");
            }

            return BadRequest();
        }
    }
}
