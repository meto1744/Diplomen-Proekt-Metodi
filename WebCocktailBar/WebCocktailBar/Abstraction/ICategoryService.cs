using System.Collections.Generic;
using WebCocktailBar.Domain;

namespace WebCocktailBar.Abstraction
{
    public interface ICategoryService
    {
        List<Category> GetCategories();

        Category GetCategoryById(int categoryId);

        List<Product> GetProductsByCategory(int categoryId);
    }
}
