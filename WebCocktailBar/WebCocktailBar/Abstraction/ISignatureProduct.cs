using System.Collections.Generic;
using WebCocktailBar.Domain;

namespace WebCocktailBar.Abstraction
{
    public interface ISignatureProduct
    {
        public bool SignatureCreate(string userId, string productName, int tasteId, int categoryId, string methodOfPreparation, string picture, int quantity, decimal price, decimal discount);
        
        List<SignatureProduct> GetCocktails();
       
    }
}
