using Microsoft.EntityFrameworkCore;

namespace Data.Entities;

[Index(nameof(Email), IsUnique = true)]

public class EmployeeEntity
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateOnly StartedAt { get; set; }

    public ICollection<ProjectDocumentEntity> ProjectDocument { get; set; } = [];

    public ICollection<ProjectCommentEntity> ProjectComment { get; set; } = [];

    public ICollection<ProjectManagerEntity> ProjectManager { get; set; } = [];
}
