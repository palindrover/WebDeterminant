using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
	public class TestController : Controller
	{
		private int Id = 1, prevId;

		private List<Question> questions = new List<Question>
		{
			new Question(1, "Вопрос 1", 3, 2, null),
            new Question(2, "Вопрос 2", 3, 4, null),
            new Question(3, "Вопрос 3", 4, 4, null),
			new Question(4, "Вопрос 4", -1, -1, null)
        };

		public IActionResult Index(int id = 1)
		{
			if (id < 0)
			{
				return RedirectToAction("End", "Test");
			}
			else
			{
				return View(questions[id - 1]);
			}
		}

		public IActionResult Result(bool Answer)
		{
			if (Answer == true)
			{
				prevId = Id;

				Id = questions[prevId - 1].IfTrue;
			}
			else
			{
				prevId = Id;

				Id = questions[prevId - 1].IfFalse;
			}

			return RedirectToAction("Index", "Test", new { id = Id });
		}

		public string End()
		{
			return "Вы ответили на все вопросы";
		}
	}
}