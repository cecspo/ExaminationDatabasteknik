using Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Data.Tests.SeedData;

public class DataContextSeeder
{
    public static DataContext GetDataContext()
    {
        var options = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        var context = new DataContext(options);
        context.Database.EnsureCreated();

        return context;
    }

    public static async Task SeedAsync(DataContext context)
    {    
        context.Address.AddRange(TestData.AddressTestData);

        context.BranchType.AddRange(TestData.BranchTypeTestData);

        context.CustomerContact.AddRange(TestData.CustomerContactTestData);

        context.Customer.AddRange(TestData.CustomerTestData);

        context.CustomerType.AddRange(TestData.CustomerTypeTestData);

        context.Employee.AddRange(TestData.EmployeeTestData);

        context.Payment.AddRange(TestData.PaymentTestData);

        context.PostalCode.AddRange(TestData.PostalCodeTestData);

        context.ProjectComment.AddRange(TestData.ProjectCommentTestData);

        context.ProjectDocument.AddRange(TestData.ProjectDocumentTestData);

        context.Project.AddRange(TestData.ProjectTestData);

        context.ProjectManager.AddRange(TestData.ProjectManagerTestData);

        context.Service.AddRange(TestData.ServiceTestData);

        context.StatusCode.AddRange(TestData.StatusCodeTestData);

        context.Task.AddRange(TestData.TaskTestData);

        await context.SaveChangesAsync();
    }


    public static async Task SeedWithProjectAsync(DataContext context)
    {
        context.Address.AddRange(TestData.AddressTestData);

        context.BranchType.AddRange(TestData.BranchTypeTestData);

        context.CustomerContact.AddRange(TestData.CustomerContactTestData);

        context.Customer.AddRange(TestData.CustomerTestData);

        context.CustomerType.AddRange(TestData.CustomerTypeTestData);

        context.Employee.AddRange(TestData.EmployeeTestData);

        context.Payment.AddRange(TestData.PaymentTestData);

        context.PostalCode.AddRange(TestData.PostalCodeTestData);

        context.ProjectComment.AddRange(TestData.ProjectCommentTestData);

        context.ProjectDocument.AddRange(TestData.ProjectDocumentTestData);

        context.Project.AddRange(TestData.ProjectTestData);

        context.ProjectManager.AddRange(TestData.ProjectManagerTestData);

        context.Service.AddRange(TestData.ServiceTestData);

        context.StatusCode.AddRange(TestData.StatusCodeTestData);

        context.Task.AddRange(TestData.TaskTestData);

        await context.SaveChangesAsync();
    }
}
