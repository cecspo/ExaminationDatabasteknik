namespace Data.Entities;

public class ProjectManagerEntity
{
    public int Id { get; set; }

    public ICollection<ProjectEntity> Project { get; set; } = [];

    public int EmployeeId { get; set; }

    public EmployeeEntity Employee { get; set; } = null!;
}
