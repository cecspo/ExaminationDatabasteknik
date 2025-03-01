using Business.Models;
using Data.Entities;

namespace Business.Factories;


public static class ServiceFactory
{
    public static ServiceEntity? Create(ServiceRegistrationForm form) => form == null ? null : new()
    {
        ServiceName = form.ServiceName
    };

    public static Service? Create(ServiceEntity entity)
    {
        if (entity == null)
            return null;

        var service = new Service()
        {
            Id = entity.Id,
            ServiceName = entity.ServiceName,
        };

        return service;
    }
}