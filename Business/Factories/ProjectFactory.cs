using Business.Models;
using Data.Entities;
using System.Diagnostics;

namespace Business.Factories;

public static class ProjectFactory
{
    public static Project? Create(ProjectEntity entity) => entity == null ? null : new Project
    {
        ProjectNumber = entity.ProjectNumber,
        ProjectName = entity.ProjectName,
        Notes = entity.Notes,
        StartDate = entity.StartDate,
        EndDate = entity.EndDate,
        Customer = CustomerFactory.Create(entity.Customer),
        StatusCode = StatusCodeFactory.Create(entity.StatusCode),
        Service = ServiceFactory.Create(entity.Service),
        ProjectManager = ProjectManagerFactory.Create(entity.ProjectManager),
    };

    public static ProjectEntity? Create(ProjectRegistrationForm form) => form == null ? null : new ProjectEntity
    {
        ProjectName = form.ProjectName,
        Notes = form.Notes,
        StartDate = form.StartDate,
        EndDate = form.EndDate,
        CustomerId = form.CustomerId,
        StatusCodeId = form.StatusCodeId,
        ServiceId = form.ServiceId,
        ProjectManagerId = form.ProjectManagerId
    };

    public static ProjectEntity? Create(Project project) => project == null ? null : new ProjectEntity
    {
        ProjectNumber = project.ProjectNumber,
        ProjectName = project.ProjectName,
        Notes = project.Notes,
        StartDate = project.StartDate,
        EndDate= project.EndDate,
        CustomerId = project.Customer!.Id,
        StatusCodeId = project.StatusCode!.Id,
        ServiceId = project.Service!.Id,
        ProjectManagerId = project.ProjectManager!.Id
    };

    public static ProjectEntity Update(Project project)
    {
        try
        {
            ArgumentNullException.ThrowIfNull(project);

            var entity = new ProjectEntity
            {
                ProjectNumber = project.ProjectNumber,
                ProjectName = project.ProjectName,
                Notes = project.Notes,
                StartDate = project.StartDate,
                EndDate = project.EndDate,
                CustomerId = project.Customer!.Id,
                StatusCodeId = project.StatusCode!.Id,
                ServiceId = project.Service!.Id,
                ProjectManagerId = project.ProjectManager!.Id
            };

            return entity;
        }

        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return null!;
        }
    }
}