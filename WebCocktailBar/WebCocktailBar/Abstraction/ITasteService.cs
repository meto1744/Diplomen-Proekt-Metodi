using System.Collections.Generic;
using WebCocktailBar.Domain;

namespace WebCocktailBar.Abstraction
{
    public interface ITasteService
    {
        List<Taste> GetTastes();

        Taste GetTasteById(int tasteId);

        List<Product> GetProductsByTaste(int tasteId);
    }
}
