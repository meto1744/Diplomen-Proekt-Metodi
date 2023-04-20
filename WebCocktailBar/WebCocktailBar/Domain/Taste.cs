using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebCocktailBar.Domain
{
    public class Taste
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]

        public string TasteName { get; set; }

        public virtual IEnumerable<Product> Products { get; set; } = new List<Product>();

    }
}
