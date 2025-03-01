using Data.Repositories;
using Data.Tests.SeedData;

namespace Data.Tests.Repositories_Tests;

public class TaskRepository_Tests
{
    [Fact]
    public async Task GetAllAsync_ShouldReturnAllTasks()
    {
        var context = DataContextSeeder.GetDataContext();
        var taskRepository = new TaskRepository(context);

        await context.AddRangeAsync(TestData.TaskTestData);
        await context.SaveChangesAsync();

        var result = await taskRepository.GetAllAsync();

        Assert.Equal(TestData.TaskTestData.Length, result.Count());
    }
}