
using Library.App.Common;
using Library.App.Interfaces;
using Library.Persistence.EntityTypeConfiguration;
using Microsoft.EntityFrameworkCore;

namespace Library.Persistence
{
    public class AuthorsDbContext : DbContext, IAuthorDbContext
	{
		public DbSet<Author> Authors { get; set; }

		public AuthorsDbContext(DbContextOptions<AuthorsDbContext> options)
			: base(options) { }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.ApplyConfiguration(new AuthorConfiguration());
			base.OnModelCreating(builder);
		}

	}
}

