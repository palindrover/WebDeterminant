using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Controllers.UtilityControllers;

namespace WebApplication1.Controllers
{
	public class TestController : Controller
	{
		private readonly List<Question> questions = new()
		{
			new Question(1, "Вопрос 1", 3, 2),
            new Question(2, "Вопрос 2", 3, 4),
            new Question(3, "Вопрос 3", 5, 4),
			new Question(4, "Вопрос 4", -1, 5),
			new Question(5, "Вопрос 5", -1, -1)
        };

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
	}
}