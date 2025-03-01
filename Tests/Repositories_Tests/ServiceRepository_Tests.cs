using Data.Repositories;
using Data.Tests.SeedData;

namespace Data.Tests.Repositories_Tests;

public class ServiceRepository_Tests
{
    [Fact]
    public async Task GetAllAsync_ShouldReturnAllServices()
    {
        var context = DataContextSeeder.GetDataContext();
        var serviceRepository = new ServiceRepository(context);

        await context.AddRangeAsync(TestData.ServiceTestData);
        await context.SaveChangesAsync();

        var result = await serviceRepository.GetAllAsync();

        Assert.Equal(TestData.ServiceTestData.Length, result.Count());
    }
}