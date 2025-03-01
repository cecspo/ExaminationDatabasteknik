using Business.Interfaces;
using Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController(IProjectService projectService) : ControllerBase
    {
        private readonly IProjectService _projectService = projectService;

        [HttpPost]
        public async Task<IActionResult> CreateProject(ProjectRegistrationForm form)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState
                    .Where(x => x.Value!.Errors.Count > 0)
                    .Select(x => new { Field = x.Key, Errors = x.Value!.Errors.Select(e => e.ErrorMessage) })
                    .ToList();

                Console.WriteLine($"ModelState errors: {System.Text.Json.JsonSerializer.Serialize(errors)}");
                return BadRequest(errors);
            }

            var project = await _projectService.CreateProjectAsync(form);
            return project == null ? BadRequest() : Ok(project);
        }


        [HttpGet]

        public async Task<IActionResult> GetAllProjects()
        {
            var result = await _projectService.GetProjectsAsync();
            return Ok(result);
        }

        [HttpGet("{projectNumber}")]

        public async Task<IActionResult> GetProject(int projectNumber)
        {
            var project = await _projectService.GetProjectAsync(projectNumber);
            return project == null ? NotFound() : Ok(project);
        }

        [HttpPut("{projectNumber}")]
        public async Task<IActionResult> UpdateProject(int projectNumber, [FromBody] Project project)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingProject = await _projectService.GetProjectAsync(projectNumber);
            if (existingProject == null)
                return NotFound(new { error = "Project not found" }); 

            existingProject.ProjectName = project.ProjectName;
            existingProject.StartDate = project.StartDate;
            existingProject.EndDate = project.EndDate;
            existingProject.Notes = project.Notes;

            var result = await _projectService.UpdateProjectAsync(existingProject);

            if (!result)
            {
                return BadRequest(new { error = "Failed to update project" });
            }

            return Ok(new { message = "Project updated successfully", updatedProject = existingProject });
        }

        [HttpDelete("{projectNumber}")]

        public async Task<IActionResult> RemoveProject(int projectNumber)
        {
            var project = await _projectService.GetProjectAsync(projectNumber);

            if (project == null)
                return NotFound();

            var deleted = await _projectService.RemoveProjectAsync(project);
            return deleted ? Ok() : BadRequest();
        }
    }
}
