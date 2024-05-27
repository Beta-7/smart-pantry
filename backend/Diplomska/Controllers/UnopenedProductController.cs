using Diplomska.Persistence.Models;
using Diplomska.Persistence.Services;
using Diplomska.Persistence.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Diplomska.Controllers;

[ApiController]
[Route("[controller]")]
public class UnopenProductController : ControllerBase
{

    private readonly ILogger<UnopenProductController> _logger;
    private readonly IUnopenedProductService _unopenedProductService;
    public UnopenProductController(ILogger<UnopenProductController> logger, IUnopenedProductService unopenedProductService)
    {
        _logger = logger;
        _unopenedProductService = unopenedProductService;
    }

    [HttpPost]
    public void AddProduct(Guid productId, int quantity, DateOnly expirationDate)
    {
        var newProduct = new UnopenedProduct
        {
            ProductId = productId,
            Quantity = quantity,
            ExpirationDate = expirationDate
        };
        _unopenedProductService.Add(newProduct);
    }
    
    [HttpGet]
    public IEnumerable<UnopenedProduct> GetAll()
    {
        return _unopenedProductService.GetAll();
    }

    [HttpDelete]
    public void Delete(Guid productId)
    {
        _unopenedProductService.Delete(productId);
    }

    [HttpPost("{productId}")]
    public void Update([FromRoute] Guid productId, int quantity, DateOnly expirationDate)
    {
        var product = new UnopenedProduct
        {
            Quantity = quantity,
            ExpirationDate = expirationDate
        };
        _unopenedProductService.Update(productId, product);
    }
}