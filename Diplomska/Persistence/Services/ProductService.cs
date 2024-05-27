using Diplomska.Persistence.Models;
using Diplomska.Persistence.Services.Interfaces;

namespace Diplomska.Persistence.Services;

public class ProductService: IProductService
{
    private readonly DataContext _context;
    public ProductService(DataContext context)
    {
        _context = context;
    }
    public bool Add(Product product)
    {
        try
        {
            _context.Products.Add(product);
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
            var product = _context.Products.FirstOrDefault(x => x.Id == id);
            if (product is not null)
            {
                product.Deleted = true;
                product.LastModified = DateTime.Now;
                _context.Products.Update(product);
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
    public Product? GetDetails(Guid id)
    {
        return _context.Products.FirstOrDefault(x => x.Id == id);
    }

    public bool Update(Guid id, Product updatedProduct)
    {
        try
        {
            var product = GetDetails(id);
            if (product is not null)
            {
                product.Barcode = updatedProduct.Barcode;
                product.Name = updatedProduct.Name;
                product.Weight = updatedProduct.Weight;
                product.PackagingWeight = updatedProduct.Weight;
                product.ExpirationDaysAfterOpen = updatedProduct.ExpirationDaysAfterOpen;
                _context.Products.Update(product);
                _context.SaveChanges();
            }
            return true;
        }
        catch
        {
            return false;
        }
    }

    public Product? GetByBarcode(string barcode)
    {
        return _context.Products.FirstOrDefault(x => x.Barcode == barcode);
    }

    public IEnumerable<Product> GetAll()
    {
        return _context.Products.Where(x => !x.Deleted);
    }
}