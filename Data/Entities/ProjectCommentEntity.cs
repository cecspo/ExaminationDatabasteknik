namespace Data.Entities;

public class ProjectCommentEntity
{
    public int Id { get; set; }

    public string CommentText { get; set; } = null!;

    public int ProjectId { get; set; }

    public int EmployeeId { get; set; }

    public DateTime CreatedAt { get; set; }

    public ProjectEntity Project { get; set; } = null!;

    public EmployeeEntity Employee { get; set; } = null!;
}
