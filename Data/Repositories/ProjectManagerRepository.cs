using Data.Contexts;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Data.Repositories;

public class ProjectManagerRepository(DataContext context) : BaseRepository<ProjectManagerEntity>(context), IProjectManagerRepository
{
    public override async Task<IEnumerable<ProjectManagerEntity>> GetAllAsync()
    {
        try
        {
            var entites = await _db
                .Include(p => p.Project)
                .Include(e => e.Employee)
                .ToListAsync();
            return entites;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return null!;
        }
    }

    public override async Task<ProjectManagerEntity?> GetAsync(Expression<Func<ProjectManagerEntity, bool>> expression)
    {
        try
        {
            var entity = await _db
                .Include(p => p.Project)
                .Include(e => e.Employee)
                .FirstOrDefaultAsync(expression);
            return entity;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return null!;
        }
    }
}
