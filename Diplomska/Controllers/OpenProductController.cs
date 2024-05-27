using Diplomska.Persistence.Models;
using Diplomska.Persistence.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Diplomska.Controllers;

[ApiController]
[Route("[controller]")]
public class OpenProductController : ControllerBase
{

    private readonly ILogger<ProductController> _logger;
    private readonly IOpenProductService _openProductService;

    public OpenProductController(ILogger<ProductController> logger, IOpenProductService openProductService)
    {
        _logger = logger;
        _openProductService = openProductService;
    }

    [HttpPost]
    public void AddProduct(Guid productId, decimal remainingWeight, DateOnly expirationDate, DateOnly openDate)
    {
        var newProduct = new OpenProduct
        {
            ProductId = productId,
            RemainingWeight = remainingWeight,
            ExpirationDate = expirationDate,
            OpenDate = openDate
        };
        _openProductService.Add(newProduct);
    }
    
    [HttpGet]
    public IEnumerable<OpenProduct> GetAll()
    {
        return _openProductService.GetAll();
    }

    [HttpDelete]
    public void Delete(Guid productId)
    {
        _openProductService.Delete(productId);
    }

    [HttpPost("{productId}")]
    public void Update([FromRoute] Guid productId, decimal remainingWeight, DateOnly expirationDate, DateOnly openDate)
    {
        var product = new OpenProduct
        {
            RemainingWeight = remainingWeight,
            ExpirationDate = expirationDate,
            OpenDate = openDate
        };
        _openProductService.Update(productId, product);
    }
}