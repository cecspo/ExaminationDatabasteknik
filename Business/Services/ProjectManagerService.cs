using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Interfaces;
using System.Diagnostics;

namespace Business.Services;

public class ProjectManagerService(IProjectManagerRepository projectManagerRepository) : IProjectManagerService
{
    private readonly IProjectManagerRepository _projectManagerRepository = projectManagerRepository;

    public async Task<IEnumerable<ProjectManager?>> GetProjectManagersAsync()
    {
        try
        {
            var entities = await _projectManagerRepository.GetAllAsync();
            return entities.Select(ProjectManagerFactory.Create);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return [];
        }
    }
}
