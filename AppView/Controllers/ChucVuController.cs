using AppData.Data;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace AppView.Controllers
{
    public class ChucVuController : Controller
    {
        private HttpClient httpClient;
        public ChucVuController()
        {
            httpClient = new HttpClient();
        }
        public async Task<IActionResult> ShowAll()
        {
            string apiURL = "https://localhost:7015/api/ChucVu/";

            var response = await httpClient.GetAsync(apiURL);
            string apiData = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<ChucVu>>(apiData);
            return View(result);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ChucVu chucVu)
        {
            string apiURL = $"https://localhost:7015/api/ChucVu/Create?TenChucVu={chucVu.TenChucVu}&TrangThai={chucVu.TrangThai}";

            var content = new StringContent(JsonConvert.SerializeObject(chucVu), Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync(apiURL, content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAll");
            }

            return View(chucVu);
        }
        
        public async Task<IActionResult> Edit(Guid id)
        {
            string apiURL = $"https://localhost:7015/api/ChucVu/GetbyId-ChucVu?Id={id}";

            var response = await httpClient.GetAsync(apiURL);

            string apiData = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ChucVu>(apiData);
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Guid id , ChucVu chucVu)
        {
            string apiURL = $"https://localhost:7015/api/ChucVu/Edit?id={id}&TenChucVu={chucVu.TenChucVu}&TrangThai={chucVu.TrangThai}";
            var content = new StringContent(JsonConvert.SerializeObject(chucVu), Encoding.UTF8, "application/json");
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
            string apiURL = $"https://localhost:7015/api/ChucVu/Delete?id={id}";

            var response = await httpClient.DeleteAsync(apiURL);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAll");
            }

            return BadRequest();
        }
    }
}
