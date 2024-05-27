namespace Diplomska.Persistence.Models;

public class Product : BaseEntity
{
    public string Name { get; set; }
    public string Barcode { get; set; }
    public int ExpirationDaysAfterOpen { get; set; }
    public decimal PackagingWeight { get; set; }
    public decimal Weight { get; set; }
}