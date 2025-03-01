namespace Data.Entities;

public class AddressEntity
{
    public int Id { get; set; }

    public string StreetName { get; set; } = null!;

    public int PostalCodeId { get; set; }

    public PostalCodeEntity PostalCode { get; set; } = null!;

    public ICollection<CustomerEntity> Customer { get; set; } = [];
}
