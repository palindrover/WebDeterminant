using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
	public class TestController : Controller
	{
		List<Question> questions = new List<Question>
		{
			new Question(1, "2 + 2 = 4?", true),
			new Question(2, "Доделает ли Петя змейку", false),
			new Question(3, "Геншин импакт - хорошая игра?", false)
		};
		[HttpGet]
		public IActionResult Index()
		{
			return View(questions);
		}

		[HttpPost]
		public IActionResult Index(bool answer1, bool answer2, bool answer3) 
		{
			List<bool> answers = new List<bool>{answer1, answer2, answer3 };
			string result = "";
			int correct = 0, wrong = 0;

			for(int i = 0; i < answers.Count; i++) 
			{ 
				if (answers[i] == questions[i].Answ)
				{
					correct++;
				}
				else
				{
					wrong++;
				}
			}

			result = $"Правильно: {correct}\nНеправильно: {wrong}";
		
			return Content(result);
		}
	}
}