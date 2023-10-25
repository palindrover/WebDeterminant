using WebApplication1.Models;

namespace WebApplication1.Controllers.UtilityControllers
{
    public class QuestionList
    {
        private static List<Question> _questions;

        public static void Init(int size)
        {
            _questions = new List<Question>(size);
        }

        public void AddQuestion(Question question) 
        { 
            _questions.Append(question);
        }
    }
}