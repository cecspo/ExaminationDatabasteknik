using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Contexts;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    protected DataContext()
    {
    }

    public DbSet<AddressEntity> Address { get; set; }
  
    public DbSet<BranchTypeEntity> BranchType { get; set; }
 
    public DbSet<CustomerContactEntity> CustomerContact { get; set; }
   
    public DbSet<CustomerEntity> Customer { get; set; }
  
    public DbSet<CustomerTypeEntity> CustomerType { get; set; }
   
    public DbSet<EmployeeEntity> Employee { get; set; }
   
    public DbSet<PaymentEntity> Payment { get; set; }

    public DbSet<PostalCodeEntity> PostalCode { get; set; }
 
    public DbSet<ProjectCommentEntity> ProjectComment { get; set; }
   
    public DbSet<ProjectDocumentEntity> ProjectDocument { get; set; }
 
    public DbSet<ProjectEntity> Project { get; set; }
  
    public DbSet<ProjectManagerEntity> ProjectManager { get; set; }  
  
    public DbSet<ServiceEntity> Service { get; set; }
   
    public DbSet<StatusCodeEntity> StatusCode { get; set; }

    public DbSet<TaskEntity> Task { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProjectCommentEntity>()
            .HasOne(pc => pc.Project)
            .WithMany(p => p.ProjectComment)
            .HasForeignKey(pc => pc.ProjectId)
            .OnDelete(DeleteBehavior.NoAction);  

        modelBuilder.Entity<ProjectCommentEntity>()
            .HasOne(pc => pc.Employee)
            .WithMany(e => e.ProjectComment)
            .HasForeignKey(pc => pc.EmployeeId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<ProjectDocumentEntity>()
            .HasOne(pc => pc.Project)
            .WithMany(p => p.ProjectDocument)
            .HasForeignKey(pc => pc.ProjectId)
            .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<ProjectDocumentEntity>()
            .HasOne(pc => pc.Employee)
            .WithMany(e => e.ProjectDocument)
            .HasForeignKey(pc => pc.EmployeeId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}

