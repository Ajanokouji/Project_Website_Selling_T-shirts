using AppData.Data;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace AppView.Controllers
{
	public class MauSacController : Controller
	{
		public MauSacController()
		{

		}
		public async Task<IActionResult> ShowAllMauSac()
		{
			string apiURL = $"https://localhost:7015/api/MauSac/get-all-mausac";
            // Sau khi có URL thì thực hiện việc lấy dữ liệu trả về từ nó
            var httpClient = new HttpClient();// Tại 1 httpClient để call API
            var response = await httpClient.GetAsync(apiURL);// Lấy kết quả
                                                             // Đọc ra string Json
            string apiData = await response.Content.ReadAsStringAsync(); 
            // Lấy kết quả thu được bằng cách bóc dữ liệu Json
            var result = JsonConvert.DeserializeObject<List<MauSac>>(apiData);
			return View(result);
		}

		public async Task<IActionResult> Create()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create(MauSac ms)
		{
			//if (!ModelState.IsValid)
			//{
			//	return View(ms);
			//}
            var httpClient = new HttpClient();
            string apiURL = $"https://localhost:7015/api/MauSac/create-mausac?tenMauSac={ms.TenMauSac}&TrangThai={ms.TrangThai}";
			
			var json = JsonConvert.SerializeObject(ms);
			var content = new StringContent(json, Encoding.UTF8, "application/json");
			var response = await httpClient.PostAsync(apiURL, content);
			if (response.IsSuccessStatusCode)
			{
				return RedirectToAction("ShowAllMauSac");
			}

			//ModelState.AddModelError("", "Error");
			return View(ms);
		}

        //[HttpGet]
        public async Task<IActionResult> Edit(Guid id)
		{
			var httpCLient = new HttpClient();
            string apiURL = $"https://localhost:7015/api/MauSac/get-mausac-by-id?id={id}";
			var response = await httpCLient.GetAsync(apiURL);
			string apiData = await response.Content.ReadAsStringAsync();
			var result = JsonConvert.DeserializeObject<MauSac>(apiData);
			return View(result);
        }

		[HttpPost]
		public async Task<IActionResult> Edit(Guid id, MauSac ms)
		{
			//if (!ModelState.IsValid)
			//{
			//	return View(ms);
			//}

			string apiURL = $"https://localhost:7015/api/MauSac/update-mausac?Id={id}&TenMauSac={ms.TenMauSac}&TrangThai={ms.TrangThai}";
			var httpClient = new HttpClient();
			var json = JsonConvert.SerializeObject(ms);
			var content = new StringContent(json, Encoding.UTF8, "application/json");
			var response = await httpClient.PutAsync(apiURL, content);
			if (response.IsSuccessStatusCode)
			{
				return RedirectToAction("ShowAllMauSac");
			}
			//ModelState.AddModelError("", "Error!");
			return View();
		}

		public async Task<IActionResult> Delete(Guid id)
		{
			string apiURL = $"https://localhost:7015/api/MauSac?id={id}";
			var httpClient = new HttpClient();
			var response = await httpClient.DeleteAsync(apiURL);
			if (response.IsSuccessStatusCode)
			{
				return RedirectToAction("ShowAllMauSac");
			}
			return BadRequest();
		}
	}
}
