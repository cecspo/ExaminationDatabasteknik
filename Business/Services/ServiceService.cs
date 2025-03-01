using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Interfaces;
using System.Diagnostics;

namespace Business.Services;

public class ServiceService(IServiceRepository serviceRepository) : IServiceService
{
    private readonly IServiceRepository _serviceRepository = serviceRepository;

    public async Task<IEnumerable<Service?>> GetServicesAsync()
    {
        try
        {
            var entities = await _serviceRepository.GetAllAsync();
            return entities.Select(ServiceFactory.Create);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return [];
        }
    }
}
