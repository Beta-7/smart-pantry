using Diplomska.Persistence.Models;

namespace Diplomska.Persistence.Services.Interfaces;

public interface IUnopenedProductService
{
    public bool Add(UnopenedProduct product);
    public bool Delete(Guid id);
    public UnopenedProduct? GetDetails(Guid id);
    public bool Update(Guid id, UnopenedProduct updatedProduct);

    public UnopenedProduct? GetUnopenedProduct(Guid productId);
    public void ConsumeUnopenedProduct(Guid unopenedProductId);
    public IEnumerable<UnopenedProduct> GetAll();
}