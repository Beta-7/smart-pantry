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
    public bool Add(OpenProductDto productDto)
    {
        try
        {
            var openProduct = new OpenProduct
            {
                ProductId = productDto.ProductId,
                RemainingWeight = productDto.RemainingWeight,
                ExpirationDate = productDto.ExpirationDate,
                OpenDate = productDto.OpenDate
            };
            _context.OpenProducts.Add(openProduct);
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
    public OpenProductDto? GetDetails(Guid id)
    {
        var openProduct = _context.OpenProducts.FirstOrDefault(x => x.Id == id) 
            ?? throw new Exception("Not found");
        var product = _context.Products.FirstOrDefault(x => x.Id == openProduct.ProductId)
            ?? throw new Exception("Not found");
        return new OpenProductDto
        {
            Id = openProduct.Id,
            LastModified = openProduct.LastModified,
            Created = openProduct.Created,
            Deleted = openProduct.Deleted,
            ProductId = openProduct.ProductId,
            Name = product.Name,
            RemainingWeight = openProduct.RemainingWeight,
            ExpirationDate = openProduct.ExpirationDate,
            OpenDate = openProduct.OpenDate,
            Weight = product.Weight,
            DaysRemaining = 5
        };
    }

    public IEnumerable<OpenProductDto> GetAll()
    {
        var openProducts = new List<OpenProductDto>();
        foreach (var openProduct in _context.OpenProducts)
        {
            var product = _context.Products.Find(openProduct.ProductId);
            if (product is null)
            {
                continue;
            }
            var openProductDto = new OpenProductDto
            {
                Id = openProduct.Id,
                LastModified = openProduct.LastModified,
                Created = openProduct.Created,
                ProductId = openProduct.ProductId,
                Name = product.Name,
                RemainingWeight = openProduct.RemainingWeight,
                ExpirationDate = openProduct.ExpirationDate,
                OpenDate = openProduct.OpenDate,
                Weight = product.Weight,
                DaysRemaining = (openProduct.ExpirationDate.ToDateTime(TimeOnly.MinValue) - DateTime.Today).Days
            };
            openProducts.Add(openProductDto);
        }
        return openProducts;
    }

    public bool Update(Guid id, OpenProductDto updatedProductDto)
    {
        try
        {
            var product = _context.OpenProducts.Find(id);
            if (product is not null)
            {
                product.ExpirationDate = updatedProductDto.ExpirationDate;
                product.OpenDate = updatedProductDto.OpenDate;
                product.ProductId = updatedProductDto.ProductId;
                product.RemainingWeight = updatedProductDto.RemainingWeight;
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

    public OpenProductDto? GetByProductId(Guid productId)
    {
        var openProduct = _context.OpenProducts.FirstOrDefault(x => x.ProductId == productId);
        var product = _context.Products.Find(openProduct.ProductId);
        return new OpenProductDto
        {
            Id = openProduct.Id,
            LastModified = openProduct.LastModified,
            Created = openProduct.Created,
            Deleted = openProduct.Deleted,
            ProductId = openProduct.ProductId,
            Name = product.Name,
            RemainingWeight = openProduct.RemainingWeight,
            ExpirationDate = openProduct.ExpirationDate,
            OpenDate = openProduct.OpenDate,
            Weight = product.Weight,
            DaysRemaining = 5
        };
    }
}