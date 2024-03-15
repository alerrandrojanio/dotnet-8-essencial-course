using CatalogAPI.Models;

namespace CatalogAPI.Repositories.Interfaces;

public interface IProductRepository : IRepository<Product>
{
    IEnumerable<Product> GetProductByCategoryId(int categoryId);
}
