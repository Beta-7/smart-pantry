using Diplomska.Persistence.Models;
using Diplomska.Persistence.Services.Interfaces;

namespace Diplomska.Persistence.Services;

public class OpenProductService: IOpenProductService
{
    private readonly DataContext _context;
    public OpenProductService(DataContext context)
    {
        _context = context;
    }
    public bool Add(OpenProduct product)
    {
        try
        {
            _context.OpenProducts.Add(product);
            _context.SaveChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }
    public bool Delete(Guid id)
    {
        try
        {
            var product = _context.OpenProducts.FirstOrDefault(x => x.Id == id);
            if (product is not null)
            {
                product.Deleted = true;
                product.LastModified = DateTime.Now;
                _context.OpenProducts.Update(product);
                _context.SaveChanges();
                return true;
            }

            return false;
        }
        catch
        {
            return false;
        }
    }
    public OpenProduct? GetDetails(Guid id)
    {
        return _context.OpenProducts.FirstOrDefault(x => x.Id == id);
    }

    public bool Update(Guid id, OpenProduct updatedProduct)
    {
        try
        {
            var product = GetDetails(id);
            if (product is not null)
            {
                product.ExpirationDate = updatedProduct.ExpirationDate;
                product.OpenDate = updatedProduct.OpenDate;
                product.ProductId = updatedProduct.ProductId;
                product.RemainingWeight = updatedProduct.RemainingWeight;
                _context.OpenProducts.Update(product);
                _context.SaveChanges();
            }
            return true;
        }
        catch
        {
            return false;
        }
    }

    public OpenProduct? GetByProductId(Guid productId)
    {
        return _context.OpenProducts.FirstOrDefault(x => x.ProductId == productId);
    }
}