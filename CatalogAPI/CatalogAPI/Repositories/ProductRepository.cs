using CatalogAPI.Context;
using CatalogAPI.Models;
using CatalogAPI.Repositories.Interfaces;
namespace CatalogAPI.Repositories;

public class ProductRepository : Repository<Product>, IProductRepository
{
    public ProductRepository(AppDbContext context) : base(context)
    {
    }

    public IEnumerable<Product> GetProductByCategoryId(int categoryId)
    {
        return GetAll().Where(c => c.CategoryId == categoryId);
    }
}
