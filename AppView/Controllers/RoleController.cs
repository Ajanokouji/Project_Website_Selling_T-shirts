using AppData.Data;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace AppView.Controllers
{
    public class RoleController : Controller
    {
        private HttpClient httpClient;
        public RoleController()
        {
            httpClient = new HttpClient();
        }
        public async Task<IActionResult> ShowAll()
        {
            string apiURL = "https://localhost:7015/api/Role";

            var response = await httpClient.GetAsync(apiURL);
            string apiData = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<Role>>(apiData);
            return View(result);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Role role)
        {
            string apiURL = $"https://localhost:7015/api/Role/Create?TenRole={role.TenRole}&TrangThai={role.TrangThai}";

            var content = new StringContent(JsonConvert.SerializeObject(role), Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync(apiURL, content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAll");
            }

            return View(role);
        }
        
        public async Task<IActionResult> Edit(Guid id)
        {
            string apiURL = $"https://localhost:7015/api/Role/GetbyId-Role?Id={id}";

            var response = await httpClient.GetAsync(apiURL);

            string apiData = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Role>(apiData);
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Guid id , Role role)
        {
            string apiURL = $"https://localhost:7015/api/Role/Edit?id={id}&TenRole={role.TenRole}&TrangThai={role.TrangThai}";
            var content = new StringContent(JsonConvert.SerializeObject(role), Encoding.UTF8, "application/json");
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
            string apiURL = $"https://localhost:7015/api/Role/Delete?id={id}";

            var response = await httpClient.DeleteAsync(apiURL);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAll");
            }

            return BadRequest();
        }
    }
}
