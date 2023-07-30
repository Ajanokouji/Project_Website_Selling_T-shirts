using AppData.Data;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace AppView.Controllers
{
    public class GiamGiaController : Controller
    {
        private HttpClient httpClient;
        public GiamGiaController()
        {
            httpClient = new HttpClient();
        }
        public async Task<IActionResult> ShowAll()
        {

            string apiURL = "https://localhost:7015/api/GiamGia/get-all";


            var response = await httpClient.GetAsync(apiURL);
            string apiData = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<GiamGia>>(apiData);
            return View(result);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(GiamGia giamGia)
        {
            string apiURL = $"https://localhost:7015/api/GiamGia/create?Ma={giamGia.Ma}&Ten={giamGia.Ten}&NgayBatDau={giamGia.NgayBatDau}&NgayKetThuc={giamGia.NgayKetThuc}&MucGiamGiaPhanTram={giamGia.MucGiamGiaPhanTram}&MucGiamGiaTienMat={giamGia.MucGiamGiaTienMat}&TrangThai={giamGia.TrangThai}";
            var content = new StringContent(JsonConvert.SerializeObject(giamGia), Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync(apiURL, content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAll");
            }

            return View(giamGia);

        }
        //[HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {

            string apiURL = $"https://localhost:7015/api/GiamGia/GetbyId-GiamGia?Id={id}";

            var response = await httpClient.GetAsync(apiURL);

            string apiData = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<GiamGia>(apiData);
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Guid Id, GiamGia giamGia)
        {

            string apiURL = $"https://localhost:7015/api/GiamGia/edit?id={Id}&Ma={giamGia.Ma}&Ten={giamGia.Ten}&NgayBatDau={giamGia.NgayBatDau}&NgayKetThuc={giamGia.NgayKetThuc}&MucGiamGiaPhanTram={giamGia.MucGiamGiaPhanTram}&MucGiamGiaTienMat={giamGia.MucGiamGiaTienMat}&TrangThai={giamGia.TrangThai}";
            var content = new StringContent(JsonConvert.SerializeObject(giamGia), Encoding.UTF8, "application/json");

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
            string apiURL = $"https://localhost:7015/api/GiamGia/delete?id={id}";

            var response = await httpClient.DeleteAsync(apiURL);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAll");
            }

            return RedirectToAction("ShowAll");
        }
    }
}
