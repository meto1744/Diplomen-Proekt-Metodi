using System.Collections.Generic;
using WebCocktailBar.Domain;

namespace WebCocktailBar.Abstraction
{
    public interface ISignatureProduct
    {
        List<SignatureProduct> GetCocktails();
    }
}
