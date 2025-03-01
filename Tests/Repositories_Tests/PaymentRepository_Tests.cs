using Data.Repositories;
using Data.Tests.SeedData;

namespace Data.Tests.Repositories_Tests;

public class PaymentRepository_Tests
{
    [Fact]
    public async Task GetAllAsync_ShouldReturnAllPayments()
    {
        var context = DataContextSeeder.GetDataContext();
        var paymentRepository = new PaymentRepository(context);

        await context.AddRangeAsync(TestData.PaymentTestData);
        await context.SaveChangesAsync();

        var result = await paymentRepository.GetAllAsync();

        Assert.Equal(TestData.PaymentTestData.Length, result.Count());
    }
}
