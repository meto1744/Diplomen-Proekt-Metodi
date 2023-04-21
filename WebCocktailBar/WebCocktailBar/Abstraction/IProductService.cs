using System.Collections.Generic;
using WebCocktailBar.Domain;

namespace WebCocktailBar.Abstraction
{
    public interface IProductService
    {

        bool Create(string name, int tasteId, int categoryId,string methodofprep, string picture, int quantity, decimal price, decimal discount);
        bool Update(int productId, string name, int tasteId, int categoryId, string methodofprep, string picture, int quantity, decimal price, decimal discount);
        List<Product> GetProducts();
        Product GetProductById(int productId);
        bool RemoveById(int productId);
        List<Product> GetProducts(string searchStringCategoryName, string searchStringTasteName, string searchStringProductName);

    }
}
