using Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusCodeController(IStatusCodeService statusCodeService) : ControllerBase
    {
        private readonly IStatusCodeService _statusCodeService = statusCodeService;

        [HttpGet]

        public async Task<IActionResult> GetAllStatusCodeAsync()
        {
            var result = await _statusCodeService.GetStatusCodesAsync();
            return Ok(result);
        }
    }
}


