using Business.Models;

namespace Business.Interfaces
{
    public interface IPaymentService
    {
        Task<IEnumerable<Payment?>> GetPaymentsAsync();
    }
}