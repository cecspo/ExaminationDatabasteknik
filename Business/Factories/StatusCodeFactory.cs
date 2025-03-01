using Business.Models;
using Data.Entities;

namespace Business.Factories;

public static class StatusCodeFactory
{
    public static StatusCodeEntity? Create(StatusCodeRegistrationForm form) => form == null ? null : new()
    {
        StatusCodeName = form.StatusCodeName
    };

    public static StatusCode? Create(StatusCodeEntity entity)
    {
        if (entity == null)
            return null;

        var statusCode = new StatusCode()
        {
            Id = entity.Id,
            StatusCodeName = entity.StatusCodeName,
        };

        return statusCode;
    }
}

