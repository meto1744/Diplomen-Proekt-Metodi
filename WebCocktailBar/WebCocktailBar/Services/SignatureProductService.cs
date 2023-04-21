using System.Collections.Generic;
using System.Linq;
using WebCocktailBar.Abstraction;
using WebCocktailBar.Data;
using WebCocktailBar.Domain;

namespace WebCocktailBar.Services
{
    public class SignatureProductService : ISignatureProduct
    {
        private readonly ApplicationDbContext _context;

        public SignatureProductService(ApplicationDbContext context)
        {
            _context = context;
        }
        public List<SignatureProduct> GetCocktails()
        {
            List<SignatureProduct> products = _context.SignatureProducts.ToList();
            return products;
        }
    }
}
