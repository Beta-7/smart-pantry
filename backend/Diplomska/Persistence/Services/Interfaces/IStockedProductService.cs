using Diplomska.Persistence.Models;

namespace Diplomska.Persistence.Services.Interfaces;

public interface IStockedProductService
{
    public bool Add(StockedProduct product);
    public bool Delete(Guid id);
    public StockedProduct? GetDetails(Guid id);
    public bool Update(Guid id, StockedProduct updatedProduct);

    public StockedProduct? GetStockedProduct(Guid productId);
    public void ConsumeStockedProduct(Guid stockedProductId);
    public IEnumerable<StockedProduct> GetAll();
}