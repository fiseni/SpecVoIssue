namespace SpecVoIssue.Data;

public class Address : ValueObject
{
    public string? Street { get; private set; }
    public string? City { get; private set; }
    public string? State { get; private set; }
    public string? Country { get; private set; }
    public string? ZipCode { get; private set; }
    public string? Other { get; private set; }

    private Address()
    {
    }

    public Address(string street)
    {
        Street = street;
    }

    public Address(string street, string city, string state, string country, string zipCode, string? other)
    {
        Street = street;
        City = city;
        State = state;
        Country = country;
        ZipCode = zipCode;
        Other = other;
    }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Street;
        yield return City;
        yield return State;
        yield return Country;
        yield return ZipCode;
        yield return Other;
    }
}
