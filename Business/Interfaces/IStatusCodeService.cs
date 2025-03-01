using Business.Models;

namespace Business.Interfaces;

public interface IStatusCodeService
{
    Task<IEnumerable<StatusCode?>> GetStatusCodesAsync();
}
