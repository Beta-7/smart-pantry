using Diplomska.Persistence.Models;
using Diplomska.Persistence.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Diplomska.Controllers;

[ApiController]
[Route("[controller]")]
public class FridgeController : ControllerBase
{
    private readonly ILogger<FridgeController> _logger;
    private readonly IFridgeService _fridgeService;

    public FridgeController(ILogger<FridgeController> logger, IFridgeService fridgeService)
    {
        _logger = logger;
        _fridgeService = fridgeService;
    }

    [HttpGet("stock")]
    public void StockProduct(Guid productId, int quantity, DateOnly expirationDate)
    {
        _fridgeService.StockProduct(productId, quantity, expirationDate);
    }

    [HttpGet("openProduct")]
    public void OpenProduct(Guid productId)
    {
        _fridgeService.OpenProduct(productId);
    }

    [HttpGet("throwOut")]
    public void ThrowOutProduct(Guid openedProductId)
    {
        _fridgeService.ThrowOutProduct(openedProductId);
    }

    [HttpGet("useProduct/id/")]
    public void UseProduct(Guid openedProductId, decimal weight)
    {
        _fridgeService.UseProduct(openedProductId, weight);
    }
    [HttpGet("useProduct/barcode")]
    public void UseProduct(string barcode, decimal weight)
    {
        _fridgeService.UseProduct(barcode, weight);
    }

}