using Diplomska.Persistence.Models;
using Diplomska.Persistence.Services.Interfaces;

namespace Diplomska.Persistence.Services;

public class FridgeService: IFridgeService  
{
    private readonly DataContext _context;
    private readonly IOpenProductService _openProductService;
    private readonly IStockedProductService _stockedProductService;
    private readonly IProductService _productService;

    public FridgeService(DataContext context, IOpenProductService openProductService,
        IStockedProductService stockedProductService, IProductService productService)
    {
        _context = context;
        _openProductService = openProductService;
        _stockedProductService = stockedProductService;
        _productService = productService;
    }

    /// <summary>
    /// A product is stocked when it has been bought and is stored unopened.
    /// </summary>
    /// <param name="productId"></param>
    public void StockProduct(Guid productId, int quantity, DateOnly expirationDate)
    {
        var product = _productService.GetDetails(productId);
        var stockedProduct = new StockedProduct
        {
            ProductId = productId,
            Quantity = quantity,
            ExpirationDate = expirationDate
        };
        _stockedProductService.Add(stockedProduct);
    }

    public void OpenProduct(Guid productId)
    {
        var product = _productService.GetDetails(productId);
        var stockedProduct = _stockedProductService.GetStockedProduct(productId);
        if (stockedProduct is null)
        {
            throw new Exception($"No stocked products with productId {productId}");
        }

        _stockedProductService.ConsumeStockedProduct(stockedProduct.Id);
        _openProductService.Add(new OpenProductDto
        {
            ProductId = stockedProduct.ProductId,
            RemainingWeight = product.Weight,
            ExpirationDate = stockedProduct.ExpirationDate,
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