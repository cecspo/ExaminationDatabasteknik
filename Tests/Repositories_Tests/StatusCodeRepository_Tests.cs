using Data.Repositories;
using Data.Tests.SeedData;

namespace Data.Tests.Repositories_Tests;

public class StatusCodeRepository_Tests
{
    [Fact]
    public async Task GetAllAsync_ShouldReturnAllStatusCodes()
    {
        var context = DataContextSeeder.GetDataContext();
        var statusCodeRepository = new StatusCodeRepository(context);

        await context.AddRangeAsync(TestData.StatusCodeTestData);
        await context.SaveChangesAsync();

        var result = await statusCodeRepository.GetAllAsync();

        Assert.Equal(TestData.StatusCodeTestData.Length, result.Count());
    }
}
