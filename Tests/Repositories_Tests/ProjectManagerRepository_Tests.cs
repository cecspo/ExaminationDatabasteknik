using Data.Repositories;
using Data.Tests.SeedData;
using Microsoft.EntityFrameworkCore;

namespace Data.Tests.Repositories_Tests;

public class ProjectManagerRepository_Tests
{
    [Fact]
    public async Task GetAllAsync_ShouldReturnAllProjectManagers()
    {
        var context = DataContextSeeder.GetDataContext();
        await DataContextSeeder.SeedAsync(context);
        var projectManagerRepository = new ProjectManagerRepository(context);

        await context.Project.ToListAsync();
        var result = await projectManagerRepository.GetAllAsync();

        Assert.Equal(TestData.ProjectManagerTestData.Length, result.Count());
    }
}
