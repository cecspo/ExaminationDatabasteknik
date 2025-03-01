using Data.Repositories;
using Data.Tests.SeedData;

namespace Data.Tests.Repositories_Tests;

public class PostalCodeRepository_Tests
{
    [Fact]
    public async Task GetAllAsync_ShouldReturnAllPostalCodes()
    {
        var context = DataContextSeeder.GetDataContext();
        var postalCodeRepository = new PostalCodeRepository(context);

        await context.AddRangeAsync(TestData.PostalCodeTestData);
        await context.SaveChangesAsync();

        var result = await postalCodeRepository.GetAllAsync();

        Assert.Equal(TestData.PostalCodeTestData.Length, result.Count());
    }
}
