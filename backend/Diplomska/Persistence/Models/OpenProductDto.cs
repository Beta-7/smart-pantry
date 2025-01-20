namespace Diplomska.Persistence.Models;

public class OpenProductDto: BaseEntity
{
    public Guid ProductId { get; set; }
    public string Name { get; set; }
    public decimal RemainingWeight { get; set; }
    public DateOnly ExpirationDate { get; set; }
    public DateOnly? OpenDate { get; set; }
    public decimal Weight { get; set; }
    public int DaysRemaining { get; set; }
    public bool IsOpen
    {
        get { return OpenDate.HasValue; }
    }
}