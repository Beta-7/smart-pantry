using Diplomska.Persistence.Models;
using Diplomska.Persistence.Services.Interfaces;

namespace Diplomska.Persistence.Services;

public class FridgeService: IFridgeService  
{
    private readonly DataContext _context;
    private readonly IOpenProductService _openProductService;
    private readonly IUnopenedProductService _unopenedProductService;
    private readonly IProductService _productService;

    public FridgeService(DataContext context, IOpenProductService openProductService,
        IUnopenedProductService unopenedProductService, IProductService productService)
    {
        _context = context;
        _openProductService = openProductService;
        _unopenedProductService = unopenedProductService;
        _productService = productService;
    }

    /// <summary>
    /// A product is stocked when it has been bought and is stored unopened.
    /// </summary>
    /// <param name="productId"></param>
    public void StockProduct(Guid productId, int quantity, DateOnly expirationDate)
    {
        var product = _productService.GetDetails(productId);
        var unopenedProduct = new UnopenedProduct
        {
            ProductId = productId,
            Quantity = quantity,
            ExpirationDate = expirationDate
        };
        _unopenedProductService.Add(unopenedProduct);
    }

    public void OpenProduct(Guid productId)
    {
        var product = _productService.GetDetails(productId);
        var unopenedProduct = _unopenedProductService.GetUnopenedProduct(productId);
        if (unopenedProduct is null)
        {
            throw new Exception($"No unopened products with productId {productId}");
        }

        _unopenedProductService.ConsumeUnopenedProduct(unopenedProduct.Id);
        _openProductService.Add(new OpenProduct
        {
            ProductId = unopenedProduct.ProductId,
            RemainingWeight = product.Weight,
            ExpirationDate = unopenedProduct.ExpirationDate,
            OpenDate = DateOnly.FromDateTime(DateTime.Now)
        });
    }

    public void ThrowOutProduct(Guid openedProductId)
    {
        _openProductService.Delete(openedProductId);
    }

    public void UseProduct(Guid openedProductId, decimal weight)
    {
        var product = _openProductService.GetDetails(openedProductId);
        if (product is null)
        {
            throw new Exception("No product with such id");
        }
        product.RemainingWeight -= weight;
        if (product.RemainingWeight <= 0)
        {
            _openProductService.Delete(openedProductId);
            return;
        }

        _openProductService.Update(product.Id, product);
    }

    public void UseProduct(string barCode, decimal weight)
    {
        var product = _productService.GetByBarcode(barCode);
        if (product is null)
        {
            throw new Exception($"No product with barcode {barCode}");
        }

        var openedProduct = _openProductService.GetByProductId(product.Id);
        if (openedProduct is null)
        {
            throw new Exception($"No opened product with id {openedProduct.Id}");
        }

        openedProduct.RemainingWeight -= weight;
        if (openedProduct.RemainingWeight <= 0)
        {
            _openProductService.Delete(openedProduct.Id);
            return;
        }

        _openProductService.Update(openedProduct.Id, openedProduct);
    }
}