using WebApplication1.Controllers.UtilityControllers;
using MySql.Data.MySqlClient;

namespace WebApplication1.Context
{
	public class BaseContext
	{
		protected string ConnectionString { get; set; }
		protected SafeGetDataController _sd;
		public BaseContext(string connectionString)
		{
			ConnectionString = connectionString;
			_sd = new SafeGetDataController();
		}

		protected MySqlConnection GetConnection()
		{
			return new MySqlConnection(ConnectionString);
		}
	}
}
