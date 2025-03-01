using Data.Repositories;
using Data.Tests.SeedData;

namespace Data.Tests.Repositories_Tests;

public class ProjectCommentRepository_Tests
{
    [Fact]
    public async Task GetAllAsync_ShouldReturnAllProjectComments()
    {
        var context = DataContextSeeder.GetDataContext();
        var projectCommentRepository = new ProjectCommentRepository(context);

        await context.AddRangeAsync(TestData.ProjectCommentTestData);
        await context.SaveChangesAsync();

        var result = await projectCommentRepository.GetAllAsync();

        Assert.Equal(TestData.ProjectCommentTestData.Length, result.Count());
    }
}
