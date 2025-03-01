using Data.Repositories;
using Data.Tests.SeedData;
using Microsoft.EntityFrameworkCore;

namespace Data.Tests.Repositories_Tests;

public class ProjectRepository_Tests
{
    [Fact]
    public async Task CreateAsync_ShouldCreateAndReturnProject()
    {
        var context = DataContextSeeder.GetDataContext();
        var projectRepository = new ProjectRepository(context);

        var projectEntity = TestData.ProjectTestData[0];

        var result = await projectRepository.CreateAsync(projectEntity);

        Assert.NotEqual(0, result!.ProjectNumber);
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnAllProjects()
    {
        var context = DataContextSeeder.GetDataContext();

        await DataContextSeeder.SeedAsync(context);
        var projectRepository = new ProjectRepository(context);

        await context.Project.ToListAsync();
        var result = await projectRepository.GetAllAsync();

        Assert.Equal(TestData.ProjectTestData.Length, result.Count());
    }

    [Fact]
    public async Task GetAsync_ShouldReturnProject()
    {
        var context = DataContextSeeder.GetDataContext();

        await DataContextSeeder.SeedAsync(context);

        var projectRepository = new ProjectRepository(context);

        var projects = await context.Project.ToListAsync();
        var result = await projectRepository.GetAsync(x => x.ProjectNumber == 1);

        Assert.NotNull(result);
        Assert.Equal(1, result!.ProjectNumber);
    }

    [Fact]
    public async Task UpdateAsync_ShouldReturnTrue()
    {
        var context = DataContextSeeder.GetDataContext();
        await context.AddRangeAsync(TestData.ProjectTestData);
        await context.SaveChangesAsync();

        var projectRepository = new ProjectRepository(context);
        var projectEntity = TestData.ProjectTestData[0];

        var result = await projectRepository.UpdateAsync(projectEntity);

        Assert.True(result);
    }

    [Fact]
    public async Task RemoveAsync_ShouldReturnTrue()
    {
        var context = DataContextSeeder.GetDataContext();
        await context.AddRangeAsync(TestData.ProjectTestData);
        await context.SaveChangesAsync();

        var projectRepository = new ProjectRepository(context);
        var projectEntity = TestData.ProjectTestData[0];

        var result = await projectRepository.RemoveAsync(projectEntity);

        Assert.True(result);
    }
}
