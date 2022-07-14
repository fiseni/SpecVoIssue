using Microsoft.EntityFrameworkCore;

namespace SpecVoIssue.Data;

public class AppDbContext : DbContext
{
	public DbSet<Place> Places => Set<Place>();

	public AppDbContext(DbContextOptions options)
		: base(options)
	{
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Place>().OwnsOne(x => x.Address);
	}
}
