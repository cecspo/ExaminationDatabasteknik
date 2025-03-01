using Data.Repositories;
using Data.Tests.SeedData;

namespace Data.Tests.Repositories_Tests;

public class ProjectDocumentRepository_Tests
{
    [Fact]
    public async Task GetAllAsync_ShouldReturnAllProjectDocuments()
    {
        var context = DataContextSeeder.GetDataContext();
        var projectDocumentRepository = new ProjectDocumentRepository(context);

        await context.AddRangeAsync(TestData.ProjectDocumentTestData);
        await context.SaveChangesAsync();

        var result = await projectDocumentRepository.GetAllAsync();

        Assert.Equal(TestData.ProjectDocumentTestData.Length, result.Count());
    }
}
