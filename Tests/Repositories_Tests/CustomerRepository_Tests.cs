using Data.Repositories;
using Data.Tests.SeedData;
using Microsoft.EntityFrameworkCore;

namespace Data.Tests.Repositories_Tests;

public class CustomerRepository_Tests
{
    [Fact]
    public async Task GetAllAsync_ShouldReturnAllCustomers()
    {
        var context = DataContextSeeder.GetDataContext();
        await DataContextSeeder.SeedAsync(context);
        var customerRepository = new CustomerRepository(context);

        await context.Customer.ToListAsync();
        var result = await customerRepository.GetAllAsync();

        Assert.Equal(TestData.CustomerTestData.Length, result.Count());
    }
}
