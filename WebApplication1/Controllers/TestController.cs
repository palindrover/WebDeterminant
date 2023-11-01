using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Controllers.UtilityControllers;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Context;

namespace WebApplication1.Controllers
{
	public class TestController : Controller
	{
		QuestionContext _context;

		public IActionResult Index(int id = 1)
		{
			GetHttpContext();

			if (id > 0)
			{
				return View(QuestionList._questions[id - 1]);
			}
			else
			{
				return RedirectToAction("End", new {Id = id});
			}
		}

		public IActionResult Result(bool Answer, int Id)
		{
			GetHttpContext();

			QuestionStack.AddTransitionNode(Id);

			if (Answer)
			{
				Id = QuestionList._questions[Id - 1].IfTrue;
			}
			else
			{
				Id = QuestionList._questions[Id - 1].IfFalse;
			}

			return RedirectToAction("Index", new { id = Id });
		}

		public IActionResult End(int Id)
		{

			return View();
		}

		public IActionResult Back()
		{
			return RedirectToAction("Index", new { id = QuestionStack.GetLastNode() });
		}

		private void GetHttpContext()
		{
            _context ??= HttpContext.RequestServices.GetService(typeof(WebApplication1.Context.QuestionContext)) as QuestionContext;
        }
	}
}