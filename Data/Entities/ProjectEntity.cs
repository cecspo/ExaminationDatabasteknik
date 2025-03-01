using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Data.Entities;

public class ProjectEntity
{
    [Key]
    public int ProjectNumber { get; set; }

    public string ProjectName { get; set; } = null!;

    public string? Notes { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public int CustomerId { get; set; }

    public int ProjectManagerId { get; set; }

    public int? PaymentId { get; set; }

    public int StatusCodeId { get; set; }

    public int ServiceId { get; set; }

    public CustomerEntity Customer { get; set; } = null!;

    public ProjectManagerEntity ProjectManager { get; set; } = null!;

    public StatusCodeEntity StatusCode { get; set; } = null!;

    public ServiceEntity Service { get; set; } = null!;
    
    public ICollection<ProjectCommentEntity> ProjectComment { get; set; } = [];

    public ICollection<ProjectDocumentEntity> ProjectDocument { get; set; } = [];
}
