using AppApi.Controllers;
using AppData.Data;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace AppView.Controllers
{
    public class LoaiController : Controller
    {
        public LoaiController()
        {

        }
        public async Task<IActionResult> ShowAllLoai()
        {
            string apiURL = $"https://localhost:7015/api/Loai/get-all-loai";
            // Sau khi có URL thì thực hiện việc lấy dữ liệu trả về từ nó
            var httpClient = new HttpClient();// Tại 1 httpClient để call API
            var response = await httpClient.GetAsync(apiURL);// Lấy kết quả
                                                             // Đọc ra string Json
            string apiData = await response.Content.ReadAsStringAsync();
            // Lấy kết quả thu được bằng cách bóc dữ liệu Json
            var result = JsonConvert.DeserializeObject<List<Loai>>(apiData);
            return View(result);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Loai loai)
        {
            //if (!ModelState.IsValid)
            //{
            //	return View(ms);
            //}
            var httpClient = new HttpClient();
            string apiURL = $"https://localhost:7015/api/Loai/create-loai?tenLoai={loai.TenLoai}&TrangThai={loai.TrangThai}";

            var json = JsonConvert.SerializeObject(loai);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(apiURL, content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAllLoai");
            }

            //ModelState.AddModelError("", "Error");
            return View(loai);
        }

        //[HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var httpCLient = new HttpClient();
            string apiURL = $"https://localhost:7015/api/Loai/get-loai-by-id?id={id}";
            var response = await httpCLient.GetAsync(apiURL);
            string apiData = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Loai>(apiData);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, Loai loai)
        {
            //if (!ModelState.IsValid)
            //{
            //	return View(ms);
            //}

            string apiURL = $"https://localhost:7015/api/Loai/update-loai?id={id}&TenLoai={loai.TenLoai}&TrangThai={loai.TrangThai}";
            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(loai);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync(apiURL, content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAllLoai");
            }
            //ModelState.AddModelError("", "Error!");
            return View();
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            string apiURL = $"https://localhost:7015/api/Loai?id={id}";
            var httpClient = new HttpClient();
            var response = await httpClient.DeleteAsync(apiURL);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAllLoai");
            }
            return BadRequest();
        }
    }
}
