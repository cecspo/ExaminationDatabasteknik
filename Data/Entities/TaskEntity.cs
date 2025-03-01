namespace Data.Entities;

public class TaskEntity
{
    public int Id { get; set; }

    public string Task { get; set; } = null!;

    public string Status { get; set; } = null!;
}
