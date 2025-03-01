namespace Data.Entities;

public class PaymentEntity
{
    public int Id { get; set; }

    public string PaymentMethod { get; set; } = null!;

    public DateTime PayedAt { get; set; }
}
