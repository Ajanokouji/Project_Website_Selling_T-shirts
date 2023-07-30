using AppData.Data;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace AppView.Controllers
{
    public class HoaDonController : Controller
    {
        private HttpClient httpClient;
        public HoaDonController()
        {
            httpClient = new HttpClient();
        }
        public async Task<IActionResult> ShowAll()
        {

            string apiURL = "https://localhost:7015/api/HoaDon/get-all";


            var response = await httpClient.GetAsync(apiURL);
            string apiData = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<HoaDon>>(apiData);
            return View(result);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(HoaDon hoaDon)
        {
            string apiURL = $"https://localhost:7015/api/HoaDon/create?IdUser={hoaDon.IdUser}&Ma={hoaDon.Ma}&TenUser={hoaDon.TenUser}&NgayTao={hoaDon.NgayTao}&NgayNhan={hoaDon.NgayNhan}&NgayShip={hoaDon.NgayShip}&NgayThanhToan={hoaDon.NgayThanhToan}&DiaChi={hoaDon.DiaChi}&TongTien={hoaDon.TongTien}&TrangThai={hoaDon.TrangThai}&SDTNguoiNhan={hoaDon.SDTNguoiNhan}&SDTNguoiShip={hoaDon.SDTNguoiShip}&TienShip={hoaDon.TienShip}";
            var content = new StringContent(JsonConvert.SerializeObject(hoaDon), Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync(apiURL, content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAll");
            }

            return View(hoaDon);

        }
        //[HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {

            string apiURL = $"https://localhost:7015/api/HoaDon/id?id={id}";

            var response = await httpClient.GetAsync(apiURL);

            string apiData = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<HoaDon>(apiData);
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Guid Id, HoaDon hoaDon)
        {

            string apiURL = $"https://localhost:7015/api/HoaDon/edit?id={Id}&IdUser={hoaDon.IdUser}&Ma={hoaDon.Ma}&TenUser={hoaDon.TenUser}&NgayTao={hoaDon.NgayTao}&NgayNhan={hoaDon.NgayNhan}&NgayShip={hoaDon.NgayShip}&NgayThanhToan={hoaDon.NgayThanhToan}&DiaChi={hoaDon.DiaChi}&TongTien={hoaDon.TongTien}&TrangThai={hoaDon.TrangThai}&SDTNguoiNhan={hoaDon.SDTNguoiNhan}&SDTNguoiShip={hoaDon.SDTNguoiShip}&TienShip={hoaDon.TienShip}";
            var content = new StringContent(JsonConvert.SerializeObject(hoaDon), Encoding.UTF8, "application/json");

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
            string apiURL = $"https://localhost:7015/api/HoaDon/delete?id={id}";

            var response = await httpClient.DeleteAsync(apiURL);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAll");
            }

            return RedirectToAction("ShowAll");
        }
    }
}
