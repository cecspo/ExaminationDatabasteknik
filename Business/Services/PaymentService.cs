using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Interfaces;
using System.Diagnostics;

namespace Business.Services;

public class PaymentService(IPaymentRepository paymentRepository) : IPaymentService
{
    private readonly IPaymentRepository _paymentRepository = paymentRepository;

    public async Task<IEnumerable<Payment?>> GetPaymentsAsync()
    {
        try
        {
            var entities = await _paymentRepository.GetAllAsync();
            return entities.Select(PaymentFactory.Create);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return [];
        }
    }
}
