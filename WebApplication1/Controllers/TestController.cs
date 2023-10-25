using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Controllers.UtilityControllers;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Context;
using WebApplication1.Controllers.UtilityControllers;

namespace WebApplication1.Controllers
{
	public class TestController : Controller
	{
		QuestionContext _context;

		List<Question> questions = new();

		public IActionResult Index(int id = 1)
		{
			if (id > 0)
			{
				return View(questions[id - 1]);
			}
			else
			{
				return RedirectToAction("End");
			}
		}

		public IActionResult Result(bool Answer, int Id)
		{
			QuestionStack.AddTransitionNode(Id);

			if (Answer)
			{
				Id = questions[Id - 1].IfTrue;
			}
			else
			{
				Id = questions[Id - 1].IfFalse;
			}

			return RedirectToAction("Index", new { id = Id });
		}

		public string End()
		{
			return "Вы ответили на все вопросы";
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