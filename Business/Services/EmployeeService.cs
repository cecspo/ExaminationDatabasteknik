using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Interfaces;
using System.Diagnostics;

namespace Business.Services;

public class EmployeeService(IEmployeeRepository employeeRepository) : IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository = employeeRepository;

    public async Task<IEnumerable<Employee?>> GetEmployeesAsync()
    {
        try
        {
            var entities = await _employeeRepository.GetAllAsync();
            return entities.Select(EmployeeFactory.Create);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return [];
        }
    }
}
