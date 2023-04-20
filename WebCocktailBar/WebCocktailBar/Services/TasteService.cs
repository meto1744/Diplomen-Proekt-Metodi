using System.Collections.Generic;
using System.Linq;
using WebCocktailBar.Abstraction;
using WebCocktailBar.Data;
using WebCocktailBar.Domain;

namespace WebCocktailBar.Services
{
    public class TasteService : ITasteService

    {
        private readonly ApplicationDbContext _context;

        public TasteService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Taste GetTasteById(int tasteId)
        {
            return _context.Tastes.Find(tasteId);
        }

        public List<Taste> GetTastes()
        {
            List<Taste> tastes = _context.Tastes.ToList();
            return tastes;
        }

        public List<Product> GetProductsByTaste(int tasteId)
        {
            return _context.Products
                .Where(x => x.TasteId == tasteId)
                .ToList();
        }
    }
}
