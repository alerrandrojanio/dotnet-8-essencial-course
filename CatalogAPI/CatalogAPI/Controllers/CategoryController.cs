using CatalogAPI.Models;
using CatalogAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CatalogAPI.Controllers;

[Route("[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    private readonly ILogger<CategoryController> _logger;

    public CategoryController(IUnitOfWork unitOfWork, ILogger<CategoryController> logger)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Category>> Get()
    {
        var categories = _unitOfWork.CategoryRepository.GetAll();
        
        return Ok(categories);
    }

    [HttpGet("{id:int}", Name = "GetCategoryById")]
    public ActionResult<Category> Get(int categoryId)
    {
        var category = _unitOfWork.CategoryRepository.Get(c => c.CategoryId == categoryId);

        if (category is null)
        {
            _logger.LogWarning($"Categoria com id= {categoryId} não encontrada...");

            return NotFound($"Categoria com id= {categoryId} não encontrada...");
        }

        return Ok(category);
    }

    [HttpPost]
    public ActionResult Post(Category category)
    {
        if (category is null)
        {
            _logger.LogWarning($"Dados inválidos...");

            return BadRequest("Dados inválidos");
        }

        Category newCategory = _unitOfWork.CategoryRepository.Create(category);
        _unitOfWork.Commit();

        return new CreatedAtRouteResult("GetCategoryById", new { categoryId = newCategory.CategoryId }, newCategory);
    }

    [HttpPut("{id:int}")]
    public ActionResult Put(int categoryId, Category category)
    {
        if (categoryId != category.CategoryId)
        {
            _logger.LogWarning($"Dados inválidos...");

            return BadRequest("Dados inválidos");
        }

        _unitOfWork.CategoryRepository.Update(category);
        _unitOfWork.Commit();

        return Ok(category);
    }

    [HttpDelete("{id:int}")]
    public ActionResult Delete(int categoryId)
    {
        Category category = _unitOfWork.CategoryRepository.Get(c => c.CategoryId == categoryId);

        if (category is null)
        {
            _logger.LogWarning($"Categoria com id={categoryId} não encontrada...");
            return NotFound($"Categoria com id={categoryId} não encontrada...");
        }

        Category deletedCategory = _unitOfWork.CategoryRepository.Delete(category);
        _unitOfWork.Commit();

        return Ok(deletedCategory);
    }
}
