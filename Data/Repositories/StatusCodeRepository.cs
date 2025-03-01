using Data.Contexts;
using Data.Entities;
using Data.Interfaces;

namespace Data.Repositories;

public class StatusCodeRepository(DataContext context) : BaseRepository<StatusCodeEntity>(context), IStatusCodeRepository
{

}