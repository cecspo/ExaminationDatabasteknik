using Business.Models;
using Data.Entities;

namespace Business.Factories;

public class ProjectManagerFactory
{
    public static ProjectManagerEntity? Create(ProjectManagerRegistrationForm form) => form == null ? null : new()
    {
        EmployeeId = form.Employees.Id
    };

    public static ProjectManager? Create(ProjectManagerEntity entity)
    {
        if (entity == null)
            return null;

        var projectManager = new ProjectManager()
        {
            Id = entity.Id,
            FirstName = entity.Employee.FirstName,
            LastName = entity.Employee.LastName,
            Email = entity.Employee.Email
        };

        return projectManager;
    }
}