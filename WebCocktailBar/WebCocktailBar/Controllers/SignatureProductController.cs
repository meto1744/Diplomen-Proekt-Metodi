using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebCocktailBar.Abstraction;
using WebCocktailBar.Models.SignatureProduct;

namespace WebCocktailBar.Controllers
{
    public class SignatureProductController : Controller
    {
        private readonly ISignatureProduct _signatureProductService;
        public SignatureProductController(ISignatureProduct signatureProductService)
        {
            this._signatureProductService = signatureProductService;
            

        }
        public ActionResult Index()
        {
            List<SignatureProductIndexVM> Signatureproducts = _signatureProductService.GetCocktails()
                .Select(product => new SignatureProductIndexVM
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
            return this.View(Signatureproducts);
        }
    }
}
