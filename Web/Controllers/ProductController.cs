using Domain.Dtos.Product;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

public class ProductController
{
    private readonly ProductService _productService;

    public ProductController(ProductService productService)
    {
        _productService = productService;
    }
    [HttpPost("AddProduct")]
    public GetProduct AddProduct(AddProduct product)
    {
        return _productService.AddProduct(product);
    }
    [HttpPut("UpdateProduct")]
    public GetProduct UpdateProduct(AddProduct product)
    {
        return _productService.UpdateProduct(product);
    }

    [HttpDelete("DeleteProduct")]
    public bool DeleteProduct(int id)
    {
        return _productService.DeleteProduct(id);
    }

    [HttpGet("GetProductById")]
    public GetProduct GetProductById(int id)
    {
        return _productService.GetProductById(id);
    }

    [HttpGet("GetProductByName")]
    public List<GetProduct> GetProductByName(string name)
    {
        return _productService.GetProductByName(name);
    }

    [HttpGet("GetProducts")]
    public List<GetProduct> GetProducts()
    {
        return _productService.GetProducts();
    }
}