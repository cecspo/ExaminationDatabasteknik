using Data.Repositories;
using Data.Tests.SeedData;

namespace Data.Tests.Repositories_Tests;

public class EmployeeRepository_Tests
{
    [Fact]
    public async Task GetAllAsync_ShouldReturnAllEmployees()
    {
        var context = DataContextSeeder.GetDataContext();
        var employeeRepository = new EmployeeRepository(context);

        await context.AddRangeAsync(TestData.EmployeeTestData);
        await context.SaveChangesAsync();

        var result = await employeeRepository.GetAllAsync();

        Assert.Equal(TestData.EmployeeTestData.Length, result.Count());
    }
}
