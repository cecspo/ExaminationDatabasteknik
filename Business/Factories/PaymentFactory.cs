using Business.Models;
using Data.Entities;

namespace Business.Factories;

public static class PaymentFactory
{
    public static PaymentEntity? Create(PaymentRegistrationForm form) => form == null ? null : new()
    {
        PaymentMethod = form.PaymentMethod
    };

    public static Payment? Create(PaymentEntity entity)
    {
        if (entity == null)
            return null;

        var payment = new Payment()
        {
            Id = entity.Id,
            PaymentMethod = entity.PaymentMethod,
            PayedAt = entity.PayedAt
        };

        return payment;
    }
}
