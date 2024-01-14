using HPPADotNetCore.MvcApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HPPADotNetCore.MvcApp.Controllers
{
    public class FamilyHttpClientController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public FamilyHttpClientController(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            //_httpClient.BaseAddress = new Uri(_configuration.GetSection("RestApiUrl").Value!);
        }

        public async Task<IActionResult> Index()
        {
            List<FamilyDataModel> model = new List<FamilyDataModel>();
            HttpResponseMessage response = await _httpClient.GetAsync("api/family");
            if (response.IsSuccessStatusCode)
            {
                string jsonStr = await response.Content.ReadAsStringAsync();
                model = JsonConvert.DeserializeObject<List<FamilyDataModel>>(jsonStr);
            }
            return View("~/Views/FamilyRefit/Index.cshtml", model);
        }
    }
}