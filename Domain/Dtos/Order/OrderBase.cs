namespace Domain.Dtos.Order;

public class OrderBase
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public DateTime OrderPlaced { get; set; }
    public DateTime OrderFullFilled { get; set; }
}