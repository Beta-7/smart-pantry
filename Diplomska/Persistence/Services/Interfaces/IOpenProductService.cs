using Diplomska.Persistence.Models;

namespace Diplomska.Persistence.Services.Interfaces;

public interface IOpenProductService
{
    public bool Add(OpenProduct product);
    public bool Delete(Guid id);
    public OpenProduct? GetDetails(Guid id);
    public IEnumerable<OpenProduct> GetAll();
    public bool Update(Guid id, OpenProduct updatedProduct);
    public OpenProduct? GetByProductId(Guid productId);
}