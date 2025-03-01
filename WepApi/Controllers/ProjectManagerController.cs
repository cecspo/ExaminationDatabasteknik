using Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectManagerController(IProjectManagerService projectManagerService) : ControllerBase
    {
        private readonly IProjectManagerService _projectManagerService = projectManagerService;

        [HttpGet]

        public async Task<IActionResult> GetAllProjectManagers()
        {
            var result = await _projectManagerService.GetProjectManagersAsync();
            return Ok(result);
        }
    }
}
