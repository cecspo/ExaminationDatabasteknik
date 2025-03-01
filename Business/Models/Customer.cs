using Data.Entities;

namespace Business.Models;

public class Customer
{
    public int Id { get; set; }

    public string CustomerName { get; set; } = null!;

    public int CustomerContactId { get; set; }

    public int CustomerTypeId { get; set; }

    public int BranchTypeId { get; set; }

    public IEnumerable<ProjectEntity> Project { get; set; } = [];
}
