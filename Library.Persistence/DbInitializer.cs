using System;
namespace Library.Persistence
{
	public class DbInitializer
	{
		public static void Initialize(AuthorsDbContext context)
		{
			context.Database.EnsureCreated();
		}
	}
}

