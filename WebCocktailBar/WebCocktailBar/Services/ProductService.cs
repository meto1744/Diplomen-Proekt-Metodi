using System;
using System.Collections.Generic;
using System.Linq;
using WebCocktailBar.Abstraction;
using WebCocktailBar.Data;
using WebCocktailBar.Domain;

namespace WebCocktailBar.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;

        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Create(string name, int tasteId, int categoryId, string methodofprep, string picture, int quantity, decimal price, decimal discount)
        {
            Product item = new Product
            {
                ProductName = name,
                Taste = _context.Tastes.Find(tasteId),
                Category = _context.Categories.Find(categoryId),
                MethodOfPreparation = methodofprep,
                Picture = picture,
                Quantity = quantity,
                Price = price,
                Discount = discount
            };

            _context.Products.Add(item);
            return _context.SaveChanges() != 0;
        }
            public Product GetProductById(int productId)
            {
                return _context.Products.Find(productId);
            }

            public List<Product> GetProducts()
            {
                List<Product> products = _context.Products.ToList();
                return products;
            }

            public List<Product> GetProducts(string searchStringCategoryName, string searchStringTasteName, string searchStringProductName)
            {
                List<Product> products = _context.Products.ToList();

                if (!string.IsNullOrEmpty(searchStringCategoryName) && !String.IsNullOrEmpty(searchStringTasteName))
                {
                    products = products.Where(x => x.Category.CategoryName.ToLower().Contains(searchStringCategoryName.ToLower())
                    && x.Taste.TasteName.ToLower().Contains(searchStringTasteName.ToLower())).ToList();
                }
                else if (!String.IsNullOrEmpty(searchStringProductName))
                {
                      products = products.Where(x => x.ProductName.ToLower().Contains(searchStringProductName.ToLower())).ToList();
                }
                else if (!String.IsNullOrEmpty(searchStringCategoryName))
                {
                    products = products.Where(x => x.Category.CategoryName.ToLower().Contains(searchStringCategoryName.ToLower())).ToList();
                }
                else if (!String.IsNullOrEmpty(searchStringTasteName))
                {
                    products = products.Where(x => x.Taste.TasteName.ToLower().Contains(searchStringTasteName.ToLower())).ToList();
                }

                return products;
            }

            public bool RemoveById(int productId)
            {
            var product = GetProductById(productId);
            if (product == default(Product))
            { return false; }

            _context.Remove(product);
            return _context.SaveChanges() != 0;
        }

            public bool Update(int productId, string name, int tasteId, int categoryId, string methodofprep, string picture, int quantity, decimal price, decimal discount)
        {
            var product = GetProductById(productId);
            if (product == default(Product))
            { return false; }
            product.ProductName = name;

            product.TasteId = tasteId;
            product.CategoryId = categoryId;

            product.Taste = _context.Tastes.Find(tasteId);
            product.Category = _context.Categories.Find(categoryId);

            product.MethodOfPreparation = methodofprep;
            product.Picture = picture;
            product.Quantity = quantity;
            product.Price = price;
            product.Discount = discount;

            _context.Update(product);
            return _context.SaveChanges() != 0;
        }
        }
    
    }
