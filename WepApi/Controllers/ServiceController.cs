using Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController(IServiceService serviceService) : ControllerBase
    {
        private readonly IServiceService _serviceService = serviceService;

        [HttpGet]

        public async Task<IActionResult> GetAllServices()
        {
            var result = await _serviceService.GetServicesAsync();
            return Ok(result);
        }
    }
}


