using Data.Repositories;
using Data.Tests.SeedData;

namespace Data.Tests.Repositories_Tests;

public class CustomerContactRepository_Tests
{
    [Fact]
    public async Task GetAllAsync_ShouldReturnAllCustomerContacs()
    {
        var context = DataContextSeeder.GetDataContext();
        var customerContactRepository = new CustomerContactRepository(context);

        await context.AddRangeAsync(TestData.CustomerContactTestData);
        await context.SaveChangesAsync();

        var result = await customerContactRepository.GetAllAsync();

        Assert.Equal(TestData.CustomerContactTestData.Length, result.Count());
    }
}
