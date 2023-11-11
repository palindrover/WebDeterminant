using WebApplication1.Models;
using MySql.Data.MySqlClient;

namespace WebApplication1.Controllers.UtilityControllers
{
    public class QuestionList
    {
        public static List<Question> _questions;

        public static void Init(int size)
        {
            _questions = new List<Question>(size);
        }

        public static void FillList()
        {
            string conStr = "server=localhost;user=root;database=webd;password=12345678;";
            MySqlConnection con = new MySqlConnection(conStr);
            con.Open();
            string sql = "SELECT * FROM questions";
            MySqlCommand command = new MySqlCommand(sql, con);
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read()) 
            {
                var question = new Question()
                {
                    Id = Int32.Parse(reader[0].ToString()),
                    QuestionText = reader[1].ToString(),
                    ImageLink1 = reader[2].ToString(),
                    ImageLink2 = reader[3].ToString(),
                    IfTrue = Int32.Parse(reader[4].ToString()),
                    IfFalse = Int32.Parse(reader[5].ToString()),
                    IsDefinding = reader[6].ToString() == "1" ? (true) : (false),
                    LiveFormID = Int32.Parse(reader[7].ToString()),
                    LeafModificationID = Int32.Parse(reader[8].ToString()),
                    LeafStructureID = Int32.Parse(reader[9].ToString()),
                    LeafArangementID = Int32.Parse(reader[10].ToString()),
                };

                _questions.Add(question);
            }

            reader.Close();
            con.Close();
        }

        public static int Count()
        {
            int j = 0;

            string conStr = "server=localhost;user=root;database=webd;password=12345678;";
            MySqlConnection con = new MySqlConnection(conStr);
            con.Open();
            string sql = "SELECT * FROM questions";
            MySqlCommand command = new MySqlCommand(sql, con);
            MySqlDataReader reader = command.ExecuteReader();

            for (int i = 0; reader.Read(); i++) 
            {
                var question = new Question()
                {
                    Id = Int32.Parse(reader[0].ToString()),
                    QuestionText = reader[1].ToString(),
                    ImageLink1 = reader[2].ToString(),
                    ImageLink2 = reader[3].ToString(),
                    IfTrue = Int32.Parse(reader[4].ToString()),
                    IfFalse = Int32.Parse(reader[5].ToString()),
                    IsDefinding = reader[6].ToString() == "1" ? (true) : (false),
                    LiveFormID = Int32.Parse(reader[7].ToString()),
                    LeafModificationID = Int32.Parse(reader[8].ToString()),
                    LeafStructureID = Int32.Parse(reader[9].ToString()),
                    LeafArangementID = Int32.Parse(reader[10].ToString()),
                };

                j = i;
            }

            reader.Close();
            con.Close();

            return j;
        }
    }
}