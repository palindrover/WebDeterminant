using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
	public class TestController : Controller
	{
		List<Question> questions = new List<Question>
		{
			new Question(1, "2 + 2 = 4?", true),
			new Question(2, "Петя доделает змейку?", false),
			new Question(3, "Геншин импакт - хорошая игра?", false)
		};

		public IActionResult Index()
		{
			return View(questions);
		}

		public IActionResult Result(bool answer1, bool answer2, bool answer3) 
		{
			List<bool> answers = new List<bool>{answer1, answer2, answer3 };
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

			ViewBag.correct = correct;
			ViewBag.wrong = wrong;

			return View();
		}
	}
}