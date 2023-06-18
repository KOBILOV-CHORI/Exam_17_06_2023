using Domain.Dtos.Order;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

public class OrderController
{
    private readonly OrderService _orderService;

    public OrderController(OrderService orderService)
    {
        _orderService = orderService;
    }
    [HttpPost("AddOrder")]
    public GetOrder AddOrder(AddOrder order)
    {
        return _orderService.AddOrder(order);
    }
    [HttpPut("UpdateOrder")]
    public GetOrder UpdateOrder(AddOrder order)
    {
        return _orderService.UpdateOrder(order);
    }

    [HttpDelete("DeleteOrder")]
    public bool DeleteOrder(int id)
    {
        return _orderService.DeleteOrder(id);
    }

    [HttpGet("GetOrderById")]
    public GetOrder GetOrderById(int id)
    {
        return _orderService.GetOrderById(id);
    }
    [HttpGet("GetOrders")]
    public List<FullOrderInfo> GetOrders()
    {
        return _orderService.GetOrders();
    }

    [HttpGet("GetOrderByDate")]
    public List<GetOrder> GetOrderByDate(DateTime date)
    {
        return _orderService.GetOrderByDate(date);
    }
}