using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

public class CustomerEntity
{
    public int Id { get; set; }

    public string CustomerName { get; set; } = null!;

    public int CustomerContactId { get; set; }

    public int CustomerTypeId { get; set; }

    public int BranchTypeId { get; set; }

    public ICollection<ProjectEntity> Project { get; set; } = [];

    public BranchTypeEntity BranchType {get; set;} = null!;

    public CustomerContactEntity CustomerContact { get; set; } = null!;

    public CustomerTypeEntity CustomerType { get; set; } = null!;
}
