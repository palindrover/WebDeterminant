using Microsoft.AspNetCore.Mvc;
using WebApplication1.Context;


namespace WebApplication1.Controllers
{
	public class PlantController : Controller
	{
		private PlantContext _context;

		public IActionResult Index()
		{
			GetHttpContext();

			return View(_context.GetAllPlants());
		}

		private void GetHttpContext()
		{
			_context ??= HttpContext.RequestServices.GetService(typeof(WebApplication1.Context.PlantContext)) as PlantContext;
		}

		public IActionResult Details(int id)
		{
			GetHttpContext();

			return PartialView("Details", _context.GetPlantsByID(id));
		}
	}
}