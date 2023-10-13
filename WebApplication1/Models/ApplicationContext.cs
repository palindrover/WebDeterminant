using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace WebApplication1.Models
{
	public class ApplicationContext : DbContext
	{
		public DbSet<Question> Questions { get; set; }

		public ApplicationContext() 
		{
			Database.EnsureCreated();
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseMySql("server=localhost;user=root;password=Tel007845;database=webd;",
				ServerVersion.AutoDetect("server=localhost;user=root;password=Tel007845;database=webd;"));
		}
	}
}