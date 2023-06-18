namespace Domain.Dtos.Order;

public class FullOrderInfo
{
    public int Id { get; set; }
    public DateTime OrderPlaced { get; set; }
    public DateTime OrderFullFilled { get; set; }
    public int CustomerId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }   
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public decimal ProductPrice { get; set; }
}