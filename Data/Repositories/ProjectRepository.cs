using Data.Contexts;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Data.Repositories;

public class ProjectRepository (DataContext context) : BaseRepository<ProjectEntity>(context), IProjectRepository
{
    public override async Task<IEnumerable<ProjectEntity>> GetAllAsync()
    {
        try
        {
            var entites = await _db
                .Include(c => c.Customer)
                .Include(p => p.ProjectManager)
                    .ThenInclude(e => e.Employee)
                .Include(s => s.StatusCode)
                .Include(s => s.Service)
                .Include(p => p.ProjectComment)
                .Include(p => p.ProjectDocument)
                .ToListAsync();
            return entites;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return [];
        }

    }

    public override async Task<ProjectEntity?> GetAsync(Expression<Func<ProjectEntity, bool>> expression)
    {
        try
        {
            var entity = await _db
                .Include(c => c.Customer)
                .Include(p => p.ProjectManager)
                    .ThenInclude(e => e.Employee)
                .Include(s => s.StatusCode)
                .Include(s => s.Service)
                .Include(p => p.ProjectComment)
                .Include(p => p.ProjectDocument)
                .FirstOrDefaultAsync(expression);
            return entity;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return null;
        }
    }
}
