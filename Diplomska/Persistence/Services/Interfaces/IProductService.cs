using Diplomska.Persistence.Models;

namespace Diplomska.Persistence.Services.Interfaces;

public interface IProductService
{
    public bool Add(Product product);
    public bool Delete(Guid id);
    public Product? GetDetails(Guid id);
    public bool Update(Guid id, Product updatedProduct);
    public Product? GetByBarcode(string barcode);
    public IEnumerable<Product> GetAll();
}