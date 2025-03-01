using Data.Repositories;
using Data.Tests.SeedData;

namespace Data.Tests.Repositories_Tests;

public class AddressRepository_Tests
{
    [Fact]
    public async Task GetAllAsync_ShouldReturnAllAddreses()
    {
        var context = DataContextSeeder.GetDataContext();
        var addressRepository = new AddressRepository(context);

        await context.AddRangeAsync(TestData.AddressTestData);
        await context.SaveChangesAsync();

        var result = await addressRepository.GetAllAsync();

        Assert.Equal(TestData.AddressTestData.Length, result.Count());
    }
}
