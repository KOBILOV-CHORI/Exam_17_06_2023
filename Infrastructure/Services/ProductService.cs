using Domain.Dtos.Product;
using Domain.Entities;
using Infrastructure.Data;

namespace Infrastructure.Services;

public class ProductService
{
    private readonly DataContext _context;

    public ProductService(DataContext context)
    {
        _context = context;
    }

    public GetProduct AddProduct(AddProduct product)
    {
        var model = new Product()
        {
            Name = product.Name,
            Price = product.Price
        };
        _context.Products.Add(model);
        _context.SaveChanges();
        return new GetProduct()
        {
            Id = model.Id,
            Name = model.Name,
            Price = model.Price
        };
    }

    public GetProduct UpdateProduct(AddProduct product)
    {
        var find = _context.Products.Find(product.Id);
        if (find == null) return new GetProduct();
        find.Name = product.Name;
        find.Price = product.Price;
        _context.SaveChanges();
        return new GetProduct()
        {
            Id = find.Id,
            Name = find.Name,
            Price = find.Price
        };
    }

    public bool DeleteProduct(int id)
    {
        var find = _context.Products.Find(id);
        if (find != null)
        {
            _context.Products.Remove(find);
            _context.SaveChanges();
            return true;
        }
        return false;
    }

    public GetProduct GetProductById(int id)
    {
        var find = _context.Products.Find(id);
        if (find == null) return new GetProduct();
        return new GetProduct()
        {
            Id = find.Id,
            Name = find.Name,
            Price = find.Price
        };
    }

    public List<GetProduct> GetProducts()
    {
        return _context.Products.Select(p => new GetProduct()
        {
            Id = p.Id,
            Name = p.Name,
            Price = p.Price
        }).ToList();
    }

    public List<GetProduct> GetProductByName(string name)
    {
        return _context.Products.Where(p => p.Name.ToLower() == name.ToLower()).Select(p => new GetProduct()
        {
            Id = p.Id,
            Name = p.Name,
            Price = p.Price
        }).ToList();
    }
}