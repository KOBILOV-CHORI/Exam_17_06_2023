using Domain.Dtos.Customer;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomerController : ControllerBase
{
    private readonly CustomerService _customerService;

    public CustomerController(CustomerService customerService)
    {
        _customerService = customerService;
    }

    [HttpPost("AddCustomer")]
    public GetCustomer AddCustomer(AddCustomer customer)
    {
        return _customerService.AddCustomer(customer);
    }
    [HttpPut("UpdateCustomer")]
    public GetCustomer UpdateCustomer(AddCustomer customer)
    {
        return _customerService.UpdateCustomer(customer);
    }

    [HttpDelete("DeleteCustomer")]
    public bool DeleteCustomer(int id)
    {
        return _customerService.DeleteCustomer(id);
    }

    [HttpGet("GetCustomerById")]
    public GetCustomer GetCustomerById(int id)
    {
        return _customerService.GetCustomerById(id);
    }

    [HttpGet("GetCustomerByName")]
    public List<GetCustomer> GetCustomerByName(string name)
    {
        return _customerService.GetCustomerByName(name);
    }

    [HttpGet("GetCustomers")]
    public List<GetCustomer> GetCustomers()
    {
        return _customerService.GetCustomers();
    }
}