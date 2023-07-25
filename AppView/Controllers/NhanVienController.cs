using AppData.Data;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using AppData.IAllrepository;
using AppData.AllRepository;
using System.Net.Http;
using System.Text;

namespace AppView.Controllers
{
    public class NhanVienController : Controller
    {
        private HttpClient httpClient;
        public NhanVienController() 
        {
            httpClient = new HttpClient();
        }
        public async Task<IActionResult> ShowAll()
        { 
            string apiUrl = "https://localhost:7015/api/NhanVien";
            var response = await httpClient.GetAsync(apiUrl);
            string apiData = await response.Content.ReadAsStringAsync();
            var nhanvien = JsonConvert.DeserializeObject<List<NhanVien>>(apiData);
            return View(nhanvien);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
            
        [HttpPost]
        public async Task<IActionResult> Create(NhanVien nv)
        {
            string apiURL = $"https://localhost:7015/api/NhanVien/Create?idcv={nv.IdCV}&ten={nv.Ten}&tentk={nv.TenTaiKhoan}&matkhau={nv.MatKhau}&anh={nv.Anh}&email={nv.Email}&trangthai={nv.TrangThai}";
            var content = new StringContent(JsonConvert.SerializeObject(nv), Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(apiURL, content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAll");     
            }

            return View(nv);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {

            string apiURL = $"https://localhost:7015/api/NhanVien/GetNVById?id={id}";

            var response = await httpClient.GetAsync(apiURL);

            string apiData = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<NhanVien>(apiData);
            return View(result);
        }

        public async Task<IActionResult> Edit(Guid id, NhanVien nv)
        {

            var httpClient = new HttpClient();
            string apiURL = $"https://localhost:7015/api/NhanVien/Edit?id={id}&idcv={nv.IdCV}&ten={nv.Ten}&tentk={nv.TenTaiKhoan}&matkhau={nv.MatKhau}&anh={nv.Anh}&email={nv.Email}&trangthai={nv.TrangThai}";
            var content = new StringContent(JsonConvert.SerializeObject(nv), Encoding.UTF8, "application/json");
            var response = await httpClient.PutAsync(apiURL, content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAll");
            }

            return View(nv);
        }

        public async Task<IActionResult> Delete(Guid id)
        {

            string apiURL = $"https://localhost:7015/api/NhanVien/Delete?id={id}";

            var response = await httpClient.DeleteAsync(apiURL);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAll");
            }
            return BadRequest();
        }
    }
}



