namespace Diplomska.Persistence.Services.Interfaces;

public interface IFridgeService
{
    public void StockProduct(Guid productId, int quantity, DateOnly expirationDate);
    public void OpenProduct(Guid productId);
    public void ThrowOutProduct(Guid openedProductId);
    public void UseProduct(Guid openedProductId, decimal weight);
    public void UseProduct(string barCode, decimal weight);
}