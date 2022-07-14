using Ardalis.Specification;

namespace SpecVoIssue.Data;

public interface IRepository<T> : IRepositoryBase<T> where T : class
{
}
