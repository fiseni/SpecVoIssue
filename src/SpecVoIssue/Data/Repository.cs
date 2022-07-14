using Ardalis.Specification.EntityFrameworkCore;

namespace SpecVoIssue.Data;

public class Repository<T> : RepositoryBase<T>, IRepository<T> where T : class
{
	public Repository(AppDbContext dbContext)
		: base(dbContext)
	{
	}
}
