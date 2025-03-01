using Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController(ICustomerService customerService) : ControllerBase
    {
        private readonly ICustomerService _customerService = customerService;

        [HttpGet]

        public async Task<IActionResult> GetAllCustomers()
        {
            var result = await _customerService.GetCustomersAsync();
            return Ok(result);
        }
    }
}
