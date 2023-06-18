using Domain.Dtos.Order;
using Domain.Entities;
using Infrastructure.Data;

namespace Infrastructure.Services;

public class OrderService
{
    private readonly DataContext _context;

    public OrderService(DataContext context)
    {
        _context = context;
    }

    public List<FullOrderInfo> GetOrders()
    {
        var result = from o in _context.Orders
            join c in _context.Customers on o.CustomerId equals c.Id
            join od in _context.OrderDetails on o.Id equals od.OrderId
            join p in _context.Products on od.ProductId equals p.Id
            select new FullOrderInfo()
            {
                Id = o.Id,
                OrderPlaced = o.OrderPlaced,
                OrderFullFilled = o.OrderFullFilled,
                CustomerId = o.CustomerId,
                FirstName = c.FirstName,
                LastName = c.LastName,
                Address = c.Address,
                Phone = c.Phone,
                Email = c.Email,
                ProductId = od.ProductId,
                ProductName = p.Name,
                ProductPrice = p.Price
            };
        return result.ToList();
    }

    public GetOrder AddOrder(AddOrder order)
    {
        order.OrderPlaced = DateTime.SpecifyKind(order.OrderPlaced, DateTimeKind.Utc);
        order.OrderFullFilled = DateTime.SpecifyKind(order.OrderFullFilled, DateTimeKind.Utc);
        var model = new Order()
        {
            CustomerId = order.CustomerId,
            OrderPlaced = order.OrderPlaced,
            OrderFullFilled = order.OrderFullFilled
        };
        _context.Orders.Add(model);
        _context.SaveChanges();
        return new GetOrder()
        {
            Id = model.Id,
            OrderPlaced = order.OrderPlaced,
            OrderFullFilled = order.OrderFullFilled,
            CustomerId = model.CustomerId
        };
    }

    public GetOrder UpdateOrder(AddOrder order)
    {
        order.OrderPlaced = DateTime.SpecifyKind(order.OrderPlaced, DateTimeKind.Utc);
        order.OrderFullFilled = DateTime.SpecifyKind(order.OrderFullFilled, DateTimeKind.Utc);
        var find = _context.Orders.Find(order.Id);
        if (find == null) return new GetOrder();
        find.CustomerId = order.CustomerId;
        find.OrderFullFilled = order.OrderFullFilled;
        find.OrderPlaced = order.OrderPlaced;
        _context.SaveChanges();
        return new GetOrder()
        {
            Id = find.Id,
            OrderPlaced = find.OrderPlaced,
            OrderFullFilled = find.OrderFullFilled,
            CustomerId = find.CustomerId
        };
    }

    public bool DeleteOrder(int id)
    {
        var find = _context.Orders.Find(id);
        if (find != null)
        {
            _context.Orders.Remove(find);
            _context.SaveChanges();
            return true;
        }

        return false;
    }

    public GetOrder GetOrderById(int id)
    {
        var find = _context.Orders.Find(id);
        if (find == null) return new GetOrder();
        return new GetOrder()
        {
            Id = find.Id,
            OrderPlaced = find.OrderPlaced,
            OrderFullFilled = find.OrderFullFilled,
            CustomerId = find.CustomerId
        };
    }

    public List<GetOrder> GetOrderByDate(DateTime date)
    {
        date = DateTime.SpecifyKind(date, DateTimeKind.Utc);
        var result = from o in _context.Orders
            where o.OrderPlaced == date || o.OrderFullFilled == date
            select new GetOrder()
            {
                Id = o.Id,
                OrderPlaced = o.OrderPlaced,
                OrderFullFilled = o.OrderFullFilled,
                CustomerId = o.CustomerId
            };
        return result.ToList();
    }
}