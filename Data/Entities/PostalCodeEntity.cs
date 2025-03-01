namespace Data.Entities;

public class PostalCodeEntity
{
    public int Id { get; set; }

    public string PostalCode { get; set; } = null!;

    public string City { get; set; } = null!;

    public ICollection<AddressEntity> Address { get; set; } = [];
}
