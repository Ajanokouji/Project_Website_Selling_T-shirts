using AppData.Data;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using System.Net.Http;
using System.Text;

namespace AppView.Controllers
{
    public class ChatLieuController : Controller
    {
        private HttpClient httpClient;
        public ChatLieuController()
        {
            httpClient = new HttpClient();
        }
        public async Task<IActionResult> ShowAll()
        {
            
            string apiURL = "https://localhost:7015/api/ChatLieu";

            
            var response = await httpClient.GetAsync(apiURL);
            string apiData = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<ChatLieu>>(apiData);
            return View(result);
        }
        public async Task< IActionResult> Create()
        {
            return View();
        }

        
        [HttpPost]
        public async Task<IActionResult> Create(ChatLieu chatLieu)  
        {
            string apiURL = $"https://localhost:7015/api/ChatLieu/Create?TenChatLieu={chatLieu.TenChatLieu}&TrangThai={chatLieu.TrangThai}";
            var content = new StringContent(JsonConvert.SerializeObject(chatLieu), Encoding.UTF8, "application/json");
            
            var response = await httpClient.PostAsync(apiURL, content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAll");
            }

            return View(chatLieu);

        }
        //[HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {

            string apiURL = $"https://localhost:7015/api/ChatLieu/GetbyId-ChatLieu?Id={id}";
            
            var response = await httpClient.GetAsync(apiURL);

            string apiData = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ChatLieu>(apiData);
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> Edit( Guid Id ,ChatLieu chatLieu)
        {

            string apiURL = $"https://localhost:7015/api/ChatLieu/Edit?id={Id}&TenChatLieu={chatLieu.TenChatLieu}&TrangThai={chatLieu.TrangThai}";
            var content = new StringContent(JsonConvert.SerializeObject(chatLieu), Encoding.UTF8, "application/json");
            
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
            string apiURL = $"https://localhost:7015/api/ChatLieu/Delete?id={id}";
            
            var response = await httpClient.DeleteAsync(apiURL);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("ShowAll");
            }

            return RedirectToAction("ShowAll");
        }
    }
}
