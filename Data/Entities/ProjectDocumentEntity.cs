namespace Data.Entities;

public class ProjectDocumentEntity
{
    public int Id { get; set; }

    public string DocumentName { get; set; } = null!;

    public string FilePath { get; set; } = null!;

    public int ProjectId { get; set; }

    public int EmployeeId { get; set; }

    public DateTime UpdatedAt { get; set; }

    public ProjectEntity Project { get; set; } = null!;

    public EmployeeEntity Employee { get; set; } = null!;
}
