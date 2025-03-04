using Diplomska.Persistence.Models;
using Diplomska.Persistence.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Diplomska.Controllers;

[ApiController]
[Route("[controller]")]
public class StockedProductController : ControllerBase
{

    private readonly ILogger<StockedProductController> _logger;
    private readonly IStockedProductService _stockedProductService;
    public StockedProductController(ILogger<StockedProductController> logger, IStockedProductService stockedProductService)
    {
        _logger = logger;
        _stockedProductService = stockedProductService;
    }

    [HttpPost]
    public void AddProduct(Guid productId, int quantity, DateOnly expirationDate)
    {
        var newProduct = new StockedProduct
        {
            ProductId = productId,
            Quantity = quantity,
            ExpirationDate = expirationDate
        };
        _stockedProductService.Add(newProduct);
    }
    
    [HttpGet]
    public IEnumerable<StockedProduct> GetAll()
    {
        return _stockedProductService.GetAll();
    }

    [HttpDelete]
    public void Delete(Guid productId)
    {
        _stockedProductService.Delete(productId);
    }

    [HttpPost("{productId}")]
    public void Update([FromRoute] Guid productId, int quantity, DateOnly expirationDate)
    {
        var product = new StockedProduct
        {
            Quantity = quantity,
            ExpirationDate = expirationDate
        };
        _stockedProductService.Update(productId, product);
    }
}