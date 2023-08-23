using Microsoft.AspNetCore.Mvc;
using TimezonesMVC.Models;
using System.Text.Json;

namespace TimezonesMVC.Controllers
{
    public class TimezonesController : Controller
    {
        public async Task<IActionResult> Index(int? page = 1, int? size = 9)
        {  
            string url = $"https://localhost:7244/Timezone?page={page}&size={size}";
            TimezoneResponseModelPagination pagination = new TimezoneResponseModelPagination();
            using (HttpClient client = new HttpClient())
            {
                var httpResponse = await client.GetAsync(url);
                var json = await httpResponse.Content.ReadAsStringAsync();
                pagination = JsonSerializer.Deserialize<TimezoneResponseModelPagination>(json);
            }
            return View(pagination);
        }

        public async Task<IActionResult> Search(string? name, int? page = 1, int? size = 9)
        {
            string url = $"https://localhost:7244/Timezone/Name?name={name}&page={page}&size={size}";
            TimezoneResponseModelPagination pagination = new TimezoneResponseModelPagination();
            using (HttpClient client = new HttpClient())
            {
                var httpResponse = await client.GetAsync(url);
                var json = await httpResponse.Content.ReadAsStringAsync();
                pagination = JsonSerializer.Deserialize<TimezoneResponseModelPagination>(json);
            }
            ViewBag.Name = name;
            return View(pagination);
        }
    }
}
