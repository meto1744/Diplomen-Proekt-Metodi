using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WebCocktailBar.Models.Category;
using WebCocktailBar.Models.Taste;

namespace WebCocktailBar.Models.Product
{
    public class ProductCreateVM
    {
        public ProductCreateVM()
        {
            Tastes = new List<TastePairVM>();
            Categories = new List<CategoryPairVM>();
        }
        [Key]

        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        [Display(Name = "Product Name")]

        public string ProductName { get; set; }

        [Required]
        [Display(Name ="Taste")]

        public int TasteId { get; set; }

        public virtual List<TastePairVM> Tastes { get; set; }

       [Required]
       [Display(Name = "Category")]

       public int CategoryId { get; set; } 
        [Display(Name ="Method Of Prep")]
        public string MethodOfPreparation { get; set; }

        public virtual List<CategoryPairVM> Categories { get; set; }

        [Display(Name = "Picture")]
        public string Picture { get; set; }
        [Required]
        [Range(0, 5000)]
        [Display(Name = "Quantity")]

        public int Quantity { get; set; }
        [Required]
        [Display(Name ="Price")]

        public decimal Price { get; set; }
        [Display(Name ="Discount")]

        public decimal Discount { get; set; }
    }
}
