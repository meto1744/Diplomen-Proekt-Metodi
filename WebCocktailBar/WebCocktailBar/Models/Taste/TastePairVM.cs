using System.ComponentModel.DataAnnotations;

namespace WebCocktailBar.Models.Taste
{
    public class TastePairVM
    {
        public int Id { get; set; }

        [Display(Name = "Taste")]

        public string Name { get; set; }
    }
}
