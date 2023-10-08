using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
	public class TestController : Controller
	{
		private int Id = 1, prevId;

		private readonly List<Question> questions = new()
		{
			new Question(1, "Вопрос 1", 3, 2, null),
            new Question(2, "Вопрос 2", 3, 4, null),
            new Question(3, "Вопрос 3", 5, 4, null),
			new Question(4, "Вопрос 4", -1, 5, null),
			new Question(5, "Вопрос 5", -1, -1, null)
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

		public IActionResult Result(bool Answer)
		{
			prevId = Id;

			if (Answer)
			{
				Id = questions[prevId - 1].IfTrue;
			}
			else
			{
				Id = questions[prevId - 1].IfFalse;
			}

			return RedirectToAction("Index", new { id = Id });
		}

		public string End()
		{
			return "Вы ответили на все вопросы";
		}
	}
}