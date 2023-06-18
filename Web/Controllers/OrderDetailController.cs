using Domain.Dtos.OrderDetail;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

public class OrderDetailController
{
    private readonly OrderDetailService _orderDetailService;

    public OrderDetailController(OrderDetailService orderDetailService)
    {
        _orderDetailService = orderDetailService;
    }

    [HttpPost("AddOrderDetail")]
    public bool AddOrderDetail(OrderDetailBase orderDetail)
    {
        return _orderDetailService.AddOrderDetail(orderDetail);
    }
}