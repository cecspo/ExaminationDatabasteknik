using Data.Repositories;
using Data.Tests.SeedData;

namespace Data.Tests.Repositories_Tests;

public class BranchTypeRepository_Tests
{
    [Fact]
    public async Task GetAllAsync_ShouldReturnAllBranchTypes()
    {
        var context = DataContextSeeder.GetDataContext();
        var branchTypeRepository = new BranchTypeRepository(context);

        await context.AddRangeAsync(TestData.BranchTypeTestData);
        await context.SaveChangesAsync();

        var result = await branchTypeRepository.GetAllAsync();

        Assert.Equal(TestData.BranchTypeTestData.Length, result.Count());
    }
}
