using Data.Repositories;
using Data.Tests.SeedData;

namespace Data.Tests.Repositories_Tests;

public class CustomerTypeRepository_Tests
{
    [Fact]
    public async Task GetAllAsync_ShouldReturnAllCustomerTypes()
    {
        var context = DataContextSeeder.GetDataContext();
        var customerTypeRepository = new CustomerTypeRepository(context);

        await context.AddRangeAsync(TestData.CustomerTypeTestData);
        await context.SaveChangesAsync();

        var result = await customerTypeRepository.GetAllAsync();

        Assert.Equal(TestData.CustomerTypeTestData.Length, result.Count());
    }
}