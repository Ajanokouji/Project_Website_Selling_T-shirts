using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using AppData.Data;
using System.Text;

namespace AppView.Controllers
{
    public class CTSanPhamController : Controller
    {
        private HttpClient httpClient;
        public CTSanPhamController()
        {
            httpClient = new HttpClient();
        }
        public async Task<IActionResult> ShowAll()
        {
            
            string apiURL = "https://localhost:7015/api/CTSanPham";

            var response = await httpClient.GetAsync(apiURL);
            string apiData = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<ChiTietSanPham>>(apiData);
            return View(result);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(ChiTietSanPham chiTietSanPham)
        {
            string apiURL = $"https://localhost:7015/api/CTSanPham/Create?IdSP={chiTietSanPham.IdSP}&IdAnh={chiTietSanPham.IdAnh}&IdKC={chiTietSanPham.IdKC}&IdMS={chiTietSanPham.IdMS}&IdLoai={chiTietSanPham.IdLoai}&IdCL={chiTietSanPham.IdCL}&GiaNhap={chiTietSanPham.GiaNhap}&GiaBan={chiTietSanPham.GiaBan}&MoTa={chiTietSanPham.Mota}&SoLuongTon={chiTietSanPham.SoLuongTon}&TrangThai={chiTietSanPham.TrangThai}";
            var content = new StringContent(JsonConvert.SerializeObject(chiTietSanPham), Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync(apiURL, content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAll");
            }

            return View(chiTietSanPham);

        }
        //[HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {

            string apiURL = $"https://localhost:7015/api/CTSanPham/GetbyId-CTSanPham?Id={id}";

            var response = await httpClient.GetAsync(apiURL);

            string apiData = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ChiTietSanPham>(apiData);
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Guid Id, ChiTietSanPham chiTietSanPham)
        {

            string apiURL = $"https://localhost:7015/api/CTSanPham/Edit?id={Id}&IdSP={chiTietSanPham.IdSP}&IdAnh={chiTietSanPham.IdAnh}&IdKC={chiTietSanPham.IdKC}&IdMS={chiTietSanPham.IdMS}&IdLoai={chiTietSanPham.IdLoai}&IdCL={chiTietSanPham.IdCL}&GiaNhap={chiTietSanPham.GiaNhap}&GiaBan={chiTietSanPham.GiaBan}&SoLuongTon={chiTietSanPham.SoLuongTon}&MoTa={chiTietSanPham.Mota}&TrangThai={chiTietSanPham.TrangThai}";
            var content = new StringContent(JsonConvert.SerializeObject(chiTietSanPham), Encoding.UTF8, "application/json");

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
            string apiURL = $"https://localhost:7015/api/CTSanPham/Delete?id={id}";

            var response = await httpClient.DeleteAsync(apiURL);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAll");
            }

            return RedirectToAction("ShowAll");
        }
    }
}
