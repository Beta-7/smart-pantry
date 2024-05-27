using Diplomska.Persistence.Models;
using Diplomska.Persistence.Services;
using Diplomska.Persistence.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Diplomska.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{

    private readonly ILogger<ProductController> _logger;
    private readonly IProductService _productService;

    public ProductController(ILogger<ProductController> logger, IProductService productService)
    {
        _logger = logger;
        _productService = productService;
    }

    [HttpPost]
    public void AddProduct(string name, string barcode, int expirationDaysAfterOpen, decimal packagingWeight, decimal weight)
    {
        var newProduct = new Product
        {
            Name = name,
            Barcode = barcode,
            ExpirationDaysAfterOpen = expirationDaysAfterOpen,
            PackagingWeight = packagingWeight,
            Weight = weight
        };
        _productService.Add(newProduct);
    }
    
    [HttpGet(Name = "all")]
    public IEnumerable<Product> GetAll()
    {
        return _productService.GetAll();
    }

    [HttpDelete]
    public void Delete(Guid productId)
    {
        _productService.Delete(productId);
    }

    [HttpPost]
    public void Update(Guid productId, string name, string barcode, int expirationDaysAfterOpen,
        decimal packagingWeight, decimal weight)
    {
        var product = new Product
        {
            Name = name,
            Barcode = barcode,
            ExpirationDaysAfterOpen = expirationDaysAfterOpen,
            PackagingWeight = packagingWeight,
            Weight = weight
        };
        _productService.Update(productId, product);
    }
}