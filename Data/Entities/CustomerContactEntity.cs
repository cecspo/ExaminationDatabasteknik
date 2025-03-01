using Microsoft.EntityFrameworkCore;

namespace Data.Entities;


[Index(nameof(Email), IsUnique = true)]

public class CustomerContactEntity
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public ICollection<CustomerEntity> Customer { get; set; } = [];
}
