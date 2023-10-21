using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using Microsoft.Data.SqlClient;
using WebApplication1.Models;

namespace WebApplication1.Context
{
	public class QuestionContext : BaseContext
	{
		public QuestionContext(string connectionString) : base(connectionString) { }

		public Question GetQuestion(int id)
		{
			using MySqlConnection conn = GetConnection();
			conn.Open();
			var cmd = new MySqlCommand($"select * from questioons where id = {id}", conn);
			using MySqlDataReader reader = cmd.ExecuteReader();
			reader.Read();
			var result = new Question()
			{
				Id = _sd.SafeGetNumericData(reader, "id"),
				QuestionText = _sd.SafeGetStringData(reader, "question"),
				ImageLink1 = _sd.SafeGetStringData(reader, "imagelink1"),
				ImageLink2 = _sd.SafeGetStringData(reader, "imagelink2"),

				IfTrue = _sd.SafeGetNumericData(reader, "ifTrue"),
				IfFalse = _sd.SafeGetNumericData(reader, "ifFalse"),

				IsDefinding = reader.GetBoolean("isDefinding"),

				LiveFormID = _sd.SafeGetNumericData(reader, "liveformid"),
				LeafModificationID = _sd.SafeGetNumericData(reader, "leafmodificationid"),
				LeafStructureID = _sd.SafeGetNumericData(reader, "leafstructureid"),
				LeafArangementID = _sd.SafeGetNumericData(reader, "leafarrangementid"),
			};

			return result;
		}
	}
}
