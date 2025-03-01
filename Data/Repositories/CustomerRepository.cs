using Data.Contexts;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq.Expressions;

namespace Data.Repositories;

public class CustomerRepository(DataContext context) : BaseRepository<CustomerEntity>(context), ICustomerRepository
{
    public override async Task<CustomerEntity?> GetAsync(Expression<Func<CustomerEntity, bool>> expression)
    {
        try
        {
            var entity = await _db
                .Include(p => p.Project)
                    .ThenInclude(pm => pm.ProjectManager)
                        .ThenInclude(e => e.Employee)
                .Include(b => b.BranchType)
                .Include(c => c.CustomerContact)
                .Include(t => t.CustomerType)
                .FirstOrDefaultAsync(expression);
            return entity;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return null;
        }
    }


    public override async Task<IEnumerable<CustomerEntity>> GetAllAsync()
    {
        try
        {
            var entities = await _db
                .Include(p => p.Project)
                    .ThenInclude(pm => pm.ProjectManager)
                .Include(b => b.BranchType)
                .Include(c => c.CustomerContact)
                .Include(t => t.CustomerType)
                .ToListAsync();

            //RADERA?!
            // Ladda relationer manuellt om de fortfarande är null
            //foreach (var customer in entities)
            //{
            //    if (customer.CustomerContact != null)
            //        customer.CustomerContactId = customer.CustomerContact.Id;
            //    if (customer.CustomerType != null)
            //        customer.CustomerTypeId = customer.CustomerType.Id;
            //    if (customer.BranchType != null)
            //        customer.BranchTypeId = customer.BranchType.Id;
            //}

            return entities;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return [];
        }
    }
}
