using System.ComponentModel.DataAnnotations;

namespace WebCocktailBar.Models.SignatureProduct
{
    public class SignatureProductIndexVM
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Product Name")]

        public string ProductName { get; set; }

        public int TasteId { get; set; }
        [Display(Name = "Taste")]
        public string TasteName { get; set; }

        public int CategoryId { get; set; }
        [Display(Name = "Category")]
        public string CategoryName { get; set; }

        [Display(Name = "MethOfPrep")]

        public string MethodOfPreparation { get; set; }

        [Display(Name = "Picture")]

        public string Picture { get; set; }

        [Display(Name = "Quantity")]
        public int Quantity { get; set; }

        [Display(Name = "Price")]
        public decimal Price { get; set; }

        [Display(Name = "Discount")]
        public decimal Discount { get; set; }
    }
}
