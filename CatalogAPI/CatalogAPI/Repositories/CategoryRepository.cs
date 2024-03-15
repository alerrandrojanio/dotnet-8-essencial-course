using CatalogAPI.Context;
using CatalogAPI.Models;
using CatalogAPI.Repositories.Interfaces;

namespace CatalogAPI.Repositories;
public class CategoryRepository : Repository<Category>, ICategoryRepository
{
    public CategoryRepository(AppDbContext context) : base(context)
    {
    }
}