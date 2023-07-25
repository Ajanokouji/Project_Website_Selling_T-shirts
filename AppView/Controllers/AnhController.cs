using AppData.Data;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using AppData.IAllrepository;
using AppData.AllRepository;
using System.Net.Http;
using System.Text;

namespace AppView.Controllers
{
    public class AnhController : Controller
    {
        private HttpClient httpClient;
        public AnhController()
        {
            httpClient = new HttpClient();
        }
        public async Task<IActionResult> ShowAll()
        {
            string apiUrl = "https://localhost:7015/api/Anh";
            var response = await httpClient.GetAsync(apiUrl);
            string apiData = await response.Content.ReadAsStringAsync();
            var anh = JsonConvert.DeserializeObject<List<Anh>>(apiData);
            return View(anh);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Anh anh)
        {
            string apiURL = $"https://localhost:7015/api/Anh/Create?duongdan={anh.DuongDan}&trangthai={anh.TrangThai}";
            var content = new StringContent(JsonConvert.SerializeObject(anh), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(apiURL, content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAll");
            }

            return View(anh);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {

            string apiURL = $"https://localhost:7015/api/Anh/GetAnhById?id={id}";

            var response = await httpClient.GetAsync(apiURL);

            string apiData = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Anh>(apiData);
            return View(result);
        }

        public async Task<IActionResult> Edit(Guid id, Anh anh)
        {

            var httpClient = new HttpClient();
            string apiURL = $"https://localhost:7015/api/Anh/Edit?id={id}&duongdan={anh.DuongDan}&trangthai={anh.TrangThai}";
            var content = new StringContent(JsonConvert.SerializeObject(anh), Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync(apiURL, content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAll");
            }

            return View(anh);
        }

        public async Task<IActionResult> Delete(Guid id)
        {

            string apiURL = $"https://localhost:7015/api/Anh/Delete?id={id}";

            var response = await httpClient.DeleteAsync(apiURL);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAll");
            }
            return BadRequest();
        }
    }
}
