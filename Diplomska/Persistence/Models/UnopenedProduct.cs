namespace Diplomska.Persistence.Models;

public class UnopenedProduct: BaseEntity
{
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
    public DateOnly ExpirationDate { get; set; }
}