using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using WebCocktailBar.Abstraction;
using WebCocktailBar.Data;
using WebCocktailBar.Models.Product;
using WebCocktailBar.Models.SignatureProduct;
using WebCocktailBar.Models.Taste;
using WebCocktailBar.Services;

namespace WebCocktailBar.Controllers
{
    public class SignatureProductController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ISignatureProduct _signatureProductService;
        private readonly IProductService _productService;
        private readonly ICategoryService _Signaturecategory;
        private readonly ITasteService _Signaturetaste;
        public SignatureProductController(ISignatureProduct signatureProductService, ApplicationDbContext context, ICategoryService signatureCategory, ITasteService signatureTaste, IProductService productService)
        {
            this._signatureProductService = signatureProductService;
            this._context = context;
            this._Signaturecategory = signatureCategory;
            this._Signaturetaste = signatureTaste;
            this._productService = productService;
        }
        public ActionResult Index(string searchString)
        {
            string userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _context.Users.SingleOrDefault(u => u.Id == userId);

            List<SignatureProductIndexVM> Signatureproducts = _signatureProductService.GetCocktails()
                .Select(product => new SignatureProductIndexVM
                {
                    UserId = userId,
                    User = product.User.UserName,
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
            if (!String.IsNullOrEmpty(searchString))
            {
                Signatureproducts = Signatureproducts.Where(o => o.Product.ToLower().Contains(searchString.ToLower())).ToList();
            }
            return this.View(Signatureproducts);
        }
        public ActionResult Create()
        {

            var Signatureproduct = new ProductCreateVM();
            Signatureproduct.Tastes = _Signaturetaste.GetTastes()
            .Select(x => new TastePairVM()
            {
                Id = x.Id,
                Name = x.TasteName
            }).ToList();
            Signatureproduct.Categories = _Signaturecategory.GetCategories()
                .Select(x => new Models.Category.CategoryPairVM()
                {
                    Id = x.Id,
                    Name = x.CategoryName
                }).ToList();
            return View(Signatureproduct);
        }

        [HttpPost]
[ValidateAntiForgeryToken]
public ActionResult Create([FromForm] ProductCreateVM product)
{
    if (ModelState.IsValid)
    {
        string userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier); // get the UserId value from the current user

        var SignaturecreatedId = _signatureProductService.SignatureCreate(userId, product.ProductName,
            product.TasteId, product.CategoryId, product.MethodOfPreparation, product.Picture,
            product.Quantity, product.Price, product.Discount);

        if (SignaturecreatedId)
        {
            return RedirectToAction(nameof(Index));
        }
    }
    return View();
}


    }
}
