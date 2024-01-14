using HPPADotNetCore.MvcApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;

namespace HPPADotNetCore.MvcApp.Controllers
{
    public class FamilyRestClientController : Controller
    {
        private readonly RestClient _restClient;

        public FamilyRestClientController(RestClient restClient)
        {
            _restClient = restClient;
        }

        public async Task<IActionResult> Index()
        {
            List<FamilyDataModel> model = new List<FamilyDataModel>();
            RestRequest request = new RestRequest("api/family", Method.Get);
            var response = await _restClient.ExecuteAsync(request);
            if (response.IsSuccessStatusCode)
            {
                string jsonStr = response.Content!;
                model = JsonConvert.DeserializeObject<List<FamilyDataModel>>(jsonStr);
            }
            return View("~/Views/FamilyRefit/Index.cshtml", model);
        }
    }
}
