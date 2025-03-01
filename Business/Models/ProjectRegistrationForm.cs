using Data.Entities;

namespace Business.Models;

public class ProjectRegistrationForm
{
    public string ProjectName { get; set; } = null!;

    public string? Notes { get; set; }

    public int CustomerId { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public int ProjectManagerId { get; set; }

    public int StatusCodeId { get; set; }

    public int ServiceId { get; set; }
}
