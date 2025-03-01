namespace Business.Models;

public class Payment
{
    public int Id { get; set; }

    public string PaymentMethod { get; set; } = null!;

    public DateTime PayedAt { get; set; }
}
