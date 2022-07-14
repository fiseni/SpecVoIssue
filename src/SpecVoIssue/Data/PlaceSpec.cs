using Ardalis.Specification;

namespace SpecVoIssue.Data;

public class PlaceSpec : Specification<Place>
{
	public PlaceSpec(Address address)
	{
		Query.Where(x => x.Address == address);
	}
}
