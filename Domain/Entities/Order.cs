namespace Domain.Entities;

public class Order
{
    public int Id { get; set; }
    public DateTime OrderPlaced { get; set; }
    public DateTime OrderFullFilled { get; set; }
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }
    public List<OrderDetail> OrderDeatails { get; set; }
}