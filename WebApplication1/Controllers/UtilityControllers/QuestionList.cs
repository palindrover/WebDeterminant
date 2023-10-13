using WebApplication1.Models;

namespace WebApplication1.Controllers.UtilityControllers
{
	public class QuestionList
	{
		public static List<Question> questions;

		public static void Init()
		{
			questions = new List<Question>();
		}
	}
}
