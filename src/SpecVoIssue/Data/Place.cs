namespace SpecVoIssue.Data;

public class Place
{
    private Place()
    {
        Name = default!;
        Address = default!;
    }

    public Place(string name, Address address)
    {
        Name = name;
        Address = address;
    }

    public int Id { get; private set; }
    public string Name { get; private set; }
    public Address Address { get; private set; }
}
