using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebCocktailBar.Abstraction;
using WebCocktailBar.Domain;
using WebCocktailBar.Models.Category;
using WebCocktailBar.Models.Product;
using WebCocktailBar.Models.Taste;
using WebShopDemo.Models.Product;

namespace WebCocktailBar.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly ITasteService _tasteService;

        public ProductController(IProductService productService, ICategoryService categoryService, ITasteService tasteService)
        {
            this._productService = productService;
            this._categoryService = categoryService;
            this._tasteService = tasteService;
        }

        public ActionResult Create()
        {
            var product = new ProductCreateVM();
            product.Tastes = _tasteService.GetTastes()
            .Select(x => new TastePairVM()
            {
                Id = x.Id,
                Name = x.TasteName
            }).ToList();
            product.Categories = _categoryService.GetCategories()
                .Select(x => new Models.Category.CategoryPairVM()
                {
                    Id = x.Id,
                    Name = x.CategoryName
                }).ToList();
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm] ProductCreateVM product)
        {
            if (ModelState.IsValid)
            {
                var createdId = _productService.Create(product.ProductName,
                    product.TasteId, product.CategoryId, product.MethodOfPreparation, product.Picture,
                    product.Quantity, product.Price, product.Discount);

                if (createdId)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View();
        }
        [AllowAnonymous]
        public ActionResult Index(string searchStringCategoryName, string searchStringTasteName, string searchStringProductName)
        {
            List<ProductIndexVM> products = _productService.GetProducts(searchStringCategoryName, searchStringTasteName, searchStringProductName)
                .Select(product => new ProductIndexVM
                {
                    Id = product.Id,
                    ProductName = product.ProductName,
                    TasteId = product.TasteId,
                    TasteName = product.Taste.TasteName,
                    CategoryId = product.CategoryId,
                    CategoryName = product.Category.CategoryName,
                    MethodOfPreparation = product.MethodOfPreparation,
                    Picture = product.Picture,
                    Quantity = product.Quantity,
                    Price = product.Price,
                    Discount = product.Discount,
                }).ToList();
            return this.View(products);
        }
        public ActionResult Edit(int id)
        {
            Product product = _productService.GetProductById(id);
            if (product == null)
            { return NotFound(); }

            ProductEditVM updatedProduct = new ProductEditVM()
            {
                Id = product.Id,
                ProductName = product.ProductName,
                TasteId = product.TasteId,
                CategoryId = product.CategoryId,
                MethodofPreparation = product.MethodOfPreparation,
                Picture = product.Picture,
                Quantity = product.Quantity,
                Price = product.Price,
                Discount = product.Discount
            };

            updatedProduct.Tastes = _tasteService.GetTastes()
                .Select(b => new TastePairVM()
                {
                    Id = b.Id,
                    Name = b.TasteName
                }).ToList();

            updatedProduct.Categories = _categoryService.GetCategories()
                .Select(c => new CategoryPairVM()
                {
                    Id = c.Id,
                    Name = c.CategoryName
                }).ToList();
            return View(updatedProduct);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ProductEditVM product)
        {
            if (ModelState.IsValid)
            {
                var updated = _productService.Update(id, product.ProductName, product.TasteId,
                    product.CategoryId,product.MethodofPreparation, product.Picture, product.Quantity,
                    product.Price, product.Discount);

                if (updated)
                {
                    return this.RedirectToAction("Index");
                }
            }
            return View(product);
        }
        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            Product item = _productService.GetProductById(id);
            if (item == null)
            {
                return NotFound();
            }
            ProductDetailsVM product = new ProductDetailsVM()
            {
                Id = item.Id,
                ProductName = item.ProductName,
                TasteId = item.TasteId,
                TasteName = item.Taste.TasteName,
                CategoryId = item.CategoryId,
                CategoryName = item.Category.CategoryName,
                MethodOfPreparation = item.MethodOfPreparation,
                Picture = item.Picture,
                Quantity = item.Quantity,
                Price = item.Price,
                Discount = item.Discount
            };
            return View(product);
        }
        public ActionResult Delete(int id)
        {
            Product product = _productService.GetProductById(id);
            if (product == null)
            { return NotFound(); }

            ProductDeleteVM productDelete = new ProductDeleteVM()
            {
                Id = product.Id,
                ProductName = product.ProductName,
                TasteId = product.TasteId,
                TasteName = product.Taste.TasteName,
                CategoryId = product.CategoryId,
                CategoryName = product.Category.CategoryName,
                MethodOfPreparation= product.MethodOfPreparation,
                Picture = product.Picture,
                Quantity = product.Quantity,
                Price = product.Price,
                Discount = product.Discount
            };
            return View(productDelete);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            var deleted = _productService.RemoveById(id);
            if (deleted)
            {
                return this.RedirectToAction("Success");
            }
            else { return View(); }
        }
        public IActionResult Success()
        {
            return View();
        }

    }
}
