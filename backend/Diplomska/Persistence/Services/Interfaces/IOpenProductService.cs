using Diplomska.Persistence.Models;

namespace Diplomska.Persistence.Services.Interfaces;

public interface IOpenProductService
{
    public bool Add(OpenProductDto productDto);
    public bool Delete(Guid id);
    public OpenProductDto? GetDetails(Guid id);
    public IEnumerable<OpenProductDto> GetAll();
    public bool Update(Guid id, OpenProductDto updatedProductDto);
    public OpenProductDto? GetByProductId(Guid productId);
}