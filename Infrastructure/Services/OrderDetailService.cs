using Domain.Dtos.OrderDetail;
using Domain.Entities;
using Infrastructure.Data;

namespace Infrastructure.Services;

public class OrderDetailService
{
    private readonly DataContext _context;

    public OrderDetailService(DataContext context)
    {
        _context = context;
    }

    public bool AddOrderDetail(OrderDetailBase orderDetail)
    {
        _context.OrderDetails.Add(new OrderDetail()
        {
            OrderId = orderDetail.OrderId,
            Quantity = orderDetail.Quantity,
            ProductId = orderDetail.ProductId
        });
        _context.SaveChanges();
        return true;
    }
}