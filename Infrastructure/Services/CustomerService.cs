using Domain.Dtos.Customer;
using Domain.Entities;
using Infrastructure.Data;

namespace Infrastructure.Services;

public class CustomerService
{
    private readonly DataContext _context;

    public CustomerService(DataContext context)
    {
        _context = context;
    }

    public GetCustomer AddCustomer(AddCustomer customer)
    {
        var result = new Customer()
        {
            FirstName = customer.FirstName,
            LastName = customer.LastName,
            Email = customer.Email,
            Address = customer.Address,
            Phone = customer.Phone
        };
        _context.Customers.Add(result);
        _context.SaveChanges();
        return new GetCustomer()
        {
            Id = result.Id,
            LastName = result.LastName,
            FirstName = result.FirstName,
            Address = result.Address,
            Email = result.Email,
            Phone = result.Phone
        };
    }

    public GetCustomer UpdateCustomer(AddCustomer customer)
    {
        var find = _context.Customers.Find(customer.Id);
        if (find != null)
        {
            find.FirstName = customer.FirstName;
            find.LastName = customer.LastName;
            find.Email = customer.Email;
            find.Phone = customer.Phone;
            find.Address = customer.Address;
            _context.SaveChanges();
        }

        return new GetCustomer()
        {
            Id = customer.Id,
            FirstName = customer.FirstName,
            LastName = customer.LastName,
            Address = customer.Address,
            Email = customer.Email,
            Phone = customer.Phone
        };
    }

    public bool DeleteCustomer(int id)
    {
        var find = _context.Customers.Find(id);
        if (find != null)
        {
            _context.Customers.Remove(find);
            _context.SaveChanges();
            return true;
        }

        return false;
    }

    public GetCustomer GetCustomerById(int id)
    {
        var find = _context.Customers.Find(id);
        if (find == null)
        {
            return new GetCustomer();
        }

        return new GetCustomer()
        {
            Id = find.Id,
            FirstName = find.FirstName,
            LastName = find.LastName,
            Address = find.Address,
            Email = find.Email,
            Phone = find.Phone
        };
    }

    public List<GetCustomer> GetCustomers()
    {
        return _context.Customers.Select(e => new GetCustomer()
        {
            Id = e.Id,
            FirstName = e.FirstName,
            LastName = e.LastName,
            Address = e.Address,
            Email = e.Email,
            Phone = e.Phone
        }).ToList();
    }

    public List<GetCustomer> GetCustomerByName(string name)
    {
        return _context.Customers.Where(e => e.FirstName.ToLower() == name.ToLower() || e.LastName.ToLower() == name.ToLower()).Select(e =>
            new GetCustomer()
            {
                Id = e.Id,
                FirstName = e.FirstName,
                LastName = e.LastName,
                Address = e.Address,
                Email = e.Email,
                Phone = e.Phone
            }).ToList();
    }
}