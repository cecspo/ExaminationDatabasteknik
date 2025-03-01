using Data.Entities;

namespace Business.Models;

public class ProjectManagerRegistrationForm
{
    public string FullName => $"{Employees.FirstName} {Employees.LastName}";

    public Employee Employees { get; set; } = null!;
}
