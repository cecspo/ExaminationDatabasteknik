using Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController(IPaymentService paymentService) : ControllerBase
    {
        private readonly IPaymentService _paymentService = paymentService;

        [HttpGet]

        public async Task<IActionResult> GetAllPayments()
        {
            var result = await _paymentService.GetPaymentsAsync();
            return Ok(result);
        }
    }
}


