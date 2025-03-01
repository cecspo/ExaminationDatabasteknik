using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Interfaces;
using System.Diagnostics;

namespace Business.Services;

public class StatusCodeService(IStatusCodeRepository statusCodeRepository) : IStatusCodeService
{
    private readonly IStatusCodeRepository _statusCodeRepository = statusCodeRepository;

    public async Task<IEnumerable<StatusCode?>> GetStatusCodesAsync()
    {
        try
        {
            var entities = await _statusCodeRepository.GetAllAsync();
            return entities.Select(StatusCodeFactory.Create);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return [];
        }
    }
}