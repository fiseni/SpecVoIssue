namespace SpecVoIssue.Data;

public static class DataInitializer
{
    public static async Task SeedTestData(this IServiceProvider services)
    {
        using (var scope = services.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            await dbContext.Database.EnsureDeletedAsync();
            await dbContext.Database.EnsureCreatedAsync();

            var places = new List<Place>
            {
                new Place("Place1", new Address("Street1")),
                new Place("Place2", new Address("Street2")),
                new Place("Place3", new Address("Street3"))
            };

            dbContext.AddRange(places);
            await dbContext.SaveChangesAsync();
        }
    }
}
