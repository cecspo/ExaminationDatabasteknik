using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Interfaces;
using System.Diagnostics;

namespace Business.Services;

public class CustomerService(ICustomerRepository customerRepository) : ICustomerService
{
    private readonly ICustomerRepository _customerRepository = customerRepository;

    //public async Task<IEnumerable<Customer?>> GetCustomersAsync()
    //{
    //    try
    //    {
    //        var entities = await _customerRepository.GetAllAsync();
    //        return entities.Select(CustomerFactory.Create);
    //    }
    //    catch (Exception ex)
    //    {
    //        Debug.WriteLine(ex);
    //        return [];
    //    }
    //}

    //ANVÄNDS TILL FELSÖKNING
    public async Task<IEnumerable<Customer?>> GetCustomersAsync()
    {
        try
        {
            var entities = await _customerRepository.GetAllAsync();

            foreach (var customer in entities)
            {
                Console.WriteLine($"Customer ID: {customer.Id}, Name: {customer.CustomerName}, " +
                    $"CustomerContactId: {customer.CustomerContactId}, CustomerTypeId: {customer.CustomerTypeId}, " +
                    $"BranchTypeId: {customer.BranchTypeId}");
            }

            return entities.Select(CustomerFactory.Create);
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return [];
        }
    }

}