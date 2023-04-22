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

        public bool SignatureCreate(string UserId, string name, int tasteId, int categoryId, string methodofprep, string picture, int quantity, decimal price, decimal discount)
        {
            SignatureProduct item = new SignatureProduct
            {
                UserId = UserId,
                ProductName = name,
                Taste = _context.Tastes.Find(tasteId),
                Category = _context.Categories.Find(categoryId),
                MethodOfPreparation = methodofprep,
                Picture = picture,
                Quantity = quantity,
                Price = price,
                Discount = discount
            };

            _context.SignatureProducts.Add(item);
            return _context.SaveChanges() != 0;
        }
    }
}
