using System.Collections.Generic;
using WebCocktailBar.Domain;

namespace WebCocktailBar.Abstraction
{
    public interface ISignatureProduct
    {
        bool SignatureCreate(string name, int tasteId, int categoryId, string methodofprep, string picture, int quantity, decimal price, decimal discount);
        List<SignatureProduct> GetCocktails();
    }
}
