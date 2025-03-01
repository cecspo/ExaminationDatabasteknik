using Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController(IEmployeeService employeeService) : ControllerBase
    {
        private readonly IEmployeeService _employeeService = employeeService;

        [HttpGet]

        public async Task<IActionResult> GetAllEmployees()
        {
            var result = await _employeeService.GetEmployeesAsync();
            return Ok(result);
        }
    }
}
