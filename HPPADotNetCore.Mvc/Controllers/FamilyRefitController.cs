using HPPADotNetCore.MvcApp.RefitExamples1;
using Microsoft.AspNetCore.Mvc;

namespace HPPADotNetCore.MvcApp.Controllers
{
	public class FamilyRefitController : Controller
	{
		private readonly IFamilyApi _familyApi;

		public FamilyRefitController(IFamilyApi familyApi)
		{
			_familyApi = familyApi;
		}

		public async Task<IActionResult> Index()
		{
			var model = await _familyApi.GetFamilies();
			return View(model);
		}
	}
}
