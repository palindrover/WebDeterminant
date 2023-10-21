using Microsoft.AspNetCore.Mvc;
using WebApplication1.Context;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
	public class ShowController : Controller
	{
		public IActionResult Index()
		{
			List<Question> questions = new List<Question>();



			return View();
		}
	}
}
