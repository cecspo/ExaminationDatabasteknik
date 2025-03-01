namespace Data.Entities;

public class CustomerTypeEntity
{
    public int Id { get; set; }

    public string CustomerTypeName { get; set; } = null!;

    public ICollection<CustomerEntity> Customer { get; set; } =[];
}
