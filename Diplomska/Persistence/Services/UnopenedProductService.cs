using Diplomska.Persistence.Models;
using Diplomska.Persistence.Services.Interfaces;

namespace Diplomska.Persistence.Services;

public class UnopenedProductService: IUnopenedProductService
{
    private readonly DataContext _context;
    public UnopenedProductService(DataContext context)
    {
        _context = context;
    }
    public bool Add(UnopenedProduct product)
    {
        try
        {
            _context.UnopenedProducts.Add(product);
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
            var product = _context.UnopenedProducts.FirstOrDefault(x => x.Id == id);
            if (product is not null)
            {
                product.Deleted = true;
                product.LastModified = DateTime.Now;
                _context.UnopenedProducts.Update(product);
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
    public UnopenedProduct? GetDetails(Guid id)
    {
        return _context.UnopenedProducts.FirstOrDefault(x => x.Id == id);
    }

    public bool Update(Guid id, UnopenedProduct updatedProduct)
    {
        try
        {
            var product = GetDetails(id);
            if (product is not null)
            {
                product.Quantity = updatedProduct.Quantity;
                product.ExpirationDate = updatedProduct.ExpirationDate;
                product.ProductId = updatedProduct.ProductId;
                _context.UnopenedProducts.Update(product);
                _context.SaveChanges();
            }
            return true;
        }
        catch
        {
            return false;
        }
    }

    public UnopenedProduct? GetUnopenedProduct(Guid productId)
    {
        return _context.UnopenedProducts.FirstOrDefault(x => x.ProductId == productId && !x.Deleted);
    }

    public void ConsumeUnopenedProduct(Guid unopenedProductId)
    {
        var product = GetDetails(unopenedProductId);
        if (product is null)
        {
            throw new Exception($"No unopened products with productId {unopenedProductId}");
        }

        product.Quantity--;
        if (product.Quantity == 0)
        {
            product.Deleted = true;
        }

        _context.SaveChanges();
    }
}