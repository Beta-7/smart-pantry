using Diplomska.Persistence.Models;
using Diplomska.Persistence.Services.Interfaces;

namespace Diplomska.Persistence.Services;

public class StockedProductService: IStockedProductService
{
    private readonly DataContext _context;
    public StockedProductService(DataContext context)
    {
        _context = context;
    }
    public bool Add(StockedProduct product)
    {
        try
        {
            _context.StockedProducts.Add(product);
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
            var product = _context.StockedProducts.FirstOrDefault(x => x.Id == id);
            if (product is not null)
            {
                product.Deleted = true;
                product.LastModified = DateTime.Now;
                _context.StockedProducts.Update(product);
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
    public StockedProduct? GetDetails(Guid id)
    {
        return _context.StockedProducts.FirstOrDefault(x => x.Id == id);
    }

    public bool Update(Guid id, StockedProduct updatedProduct)
    {
        try
        {
            var product = GetDetails(id);
            if (product is not null)
            {
                product.Quantity = updatedProduct.Quantity;
                product.ExpirationDate = updatedProduct.ExpirationDate;
                product.ProductId = updatedProduct.ProductId;
                _context.StockedProducts.Update(product);
                _context.SaveChanges();
            }
            return true;
        }
        catch
        {
            return false;
        }
    }

    public StockedProduct? GetStockedProduct(Guid productId)
    {
        return _context.StockedProducts.OrderByDescending(x => x.ExpirationDate).FirstOrDefault(x => x.ProductId == productId && !x.Deleted);
    }

    public void ConsumeStockedProduct(Guid stockedProductId)
    {
        var product = GetDetails(stockedProductId);
        if (product is null)
        {
            throw new Exception($"No stocked products with productId {stockedProductId}");
        }

        product.Quantity--;
        if (product.Quantity == 0)
        {
            product.Deleted = true;
        }

        _context.SaveChanges();
    }

    public IEnumerable<StockedProduct> GetAll()
    {
        return _context.StockedProducts;
    }
}