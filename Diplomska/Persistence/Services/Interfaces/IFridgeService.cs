namespace Diplomska.Persistence.Services.Interfaces;

public interface IFridgeService
{
    /// <summary>
    /// Use this method to notify the system that a product has been bought.
    /// </summary>
    /// <param name="productId">Id of the product</param>
    /// <param name="quantity">Number of items. Use this only if the expiration date is the same for all items</param>
    /// <param name="expirationDate">Expiration date</param>
    public void StockProduct(Guid productId, int quantity, DateOnly expirationDate);
    /// <summary>
    /// Use this method to notify the system that a stocked item has been opened. This starts the timer before the item has to be thrown
    /// out because it's expired. This method picks the product with the nearest expiry date.
    /// </summary>
    /// <param name="productId">Id of the product</param>
    public void OpenProduct(Guid productId);
    
    /// <summary>
    /// Use this method to notify the system that the opened item is no longer present.
    /// </summary>
    /// <param name="openedProductId">Id of the opened product</param>
    public void ThrowOutProduct(Guid openedProductId);
    /// <summary>
    /// Use this method to notify the system  that an opened item's weight has been altered.
    /// </summary>
    /// <param name="openedProductId">Id of the opened product</param>
    /// <param name="weight">The remaining weight of the opened product. Packaging included</param>
    public void UseProduct(Guid openedProductId, decimal weight);
    /// <summary>
    /// Use this method to notify the system  that an opened item's weight has been altered.
    /// </summary>
    /// <param name="barCode">Barcode of the opened product</param>
    /// <param name="weight">The remaining weight of the opened product. Packaging included</param>
    public void UseProduct(string barCode, decimal weight);
}   