namespace Business.Models;

public class Project
{
    public int ProjectNumber { get; set; }

    public string ProjectName { get; set; } = null!;

    public string? Notes { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public Customer? Customer { get; set; } 

    public ProjectManager? ProjectManager { get; set; } 

    public StatusCode? StatusCode { get; set; }

    public Service? Service { get; set; } 
}

