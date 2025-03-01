namespace Business.Models;

public class PaymentRegistrationForm
{
    public string PaymentMethod { get; set; } = null!;

    public DateTime PayedAt { get; set; }
}
