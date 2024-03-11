public interface ICategoryRepository {
    IEnumerable<Category> GetCategories();
    Category GetCategoryById(int id);
    Category Create(Category category);
}