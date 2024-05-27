namespace Diplomska.Persistence.Models;

public class OpenProduct: BaseEntity
{
    public Guid ProductId { get; set; }
    public decimal RemainingWeight { get; set; }
    public DateOnly ExpirationDate { get; set; }
    public DateOnly? OpenDate { get; set; }
    public bool IsOpen
    {
        get { return OpenDate.HasValue; }
    }
}