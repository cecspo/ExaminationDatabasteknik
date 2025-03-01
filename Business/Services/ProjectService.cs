using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Interfaces;
using System.Diagnostics;

namespace Business.Services;

public class ProjectService(IProjectRepository projectRepository) : IProjectService
{
    private readonly IProjectRepository _projectRepository = projectRepository;

    public async Task<Project?> CreateProjectAsync(ProjectRegistrationForm form)
    {
        try
        {
            ArgumentNullException.ThrowIfNull(form);

            var projectEntity = ProjectFactory.Create(form);

            if (projectEntity == null)
                return null;

            projectEntity = await _projectRepository.CreateAsync(projectEntity);

            if (projectEntity == null)
                return null;

            var project = ProjectFactory.Create(projectEntity);
            return project;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return null;
        }
    }

    public async Task<Project?> GetProjectAsync(int id)
    {
        try
        {
            var projectEntity = await _projectRepository.GetAsync(x => x.ProjectNumber == id);
            if (projectEntity == null)
                return null;

            var project = ProjectFactory.Create(projectEntity);
            return project;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return null;
        }
    }

    public async Task<IEnumerable<Project?>> GetProjectsAsync()
    {
        try
        {
            var entities = await _projectRepository.GetAllAsync();
            return entities.Select(ProjectFactory.Create);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return [];
        }
    }

    public async Task<bool> RemoveProjectAsync(Project project)
    {
        try
        {
            ArgumentNullException.ThrowIfNull(project);

            var projectEntity = ProjectFactory.Create(project);

            if (projectEntity == null)
                return false;

            var result = await _projectRepository.RemoveAsync(projectEntity);
            return result;

        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return false;
        }
    }

    public async Task<bool> UpdateProjectAsync(Project project)
    {
        try
        {
            ArgumentNullException.ThrowIfNull(project);

            var projectEntity = await _projectRepository.GetAsync(x => x.ProjectNumber == project.ProjectNumber);
            if (projectEntity == null)
                return false;

            projectEntity.StartDate = project.StartDate;
            projectEntity.EndDate = project.EndDate;
            projectEntity.ProjectName = project.ProjectName;
            projectEntity.Notes = project.Notes;

            var result = await _projectRepository.UpdateAsync(projectEntity);
            return result;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return false;
        }
    }

}

