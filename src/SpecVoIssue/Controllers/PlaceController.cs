using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpecVoIssue.Data;

namespace SpecVoIssue.Controllers;

[ApiController]
public class PlaceController : ControllerBase
{
    private readonly IRepository<Place> _repository;
    private readonly AppDbContext _dbContext;

    public PlaceController(IRepository<Place> repository, AppDbContext dbContext)
    {
        _repository = repository;
        _dbContext = dbContext;
    }

    [HttpGet("/places/ef")]
    public async Task<ActionResult<List<PlaceDto>>> GetPlacesWithEf(string street, CancellationToken cancellationToken)
    {
        var address = new Address(street);

        var places = await _dbContext.Set<Place>().Where(x => x.Address == address).ToListAsync();

        var result = places.Select(x => new PlaceDto
        {
            Id = x.Id,
            Name = x.Name,
            Street = x.Address.Street
        }).ToList();

        return result;
    }

    [HttpGet("/places/spec")]
    public async Task<ActionResult<List<PlaceDto>>> GetPlacesWithSpec(string street, CancellationToken cancellationToken)
    {
        var address = new Address(street);

        var spec = new PlaceSpec(address);

        var places = await _repository.ListAsync(spec, cancellationToken);

        var result = places.Select(x => new PlaceDto
        {
            Id = x.Id,
            Name = x.Name,
            Street = x.Address.Street
        }).ToList();

        return result;
    }
}
