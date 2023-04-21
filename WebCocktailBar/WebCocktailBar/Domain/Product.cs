using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebCocktailBar.Domain
{
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }
        [Required]
        [MaxLength(30)]

        public string ProductName { get; set; }
        [Required]

        public int TasteId { get; set; }

        public virtual Taste Taste { get; set; }
        [Required]

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public string MethodOfPreparation { get; set; }

        public string Picture { get; set; }
        [Required]
        [Range(0, 5000)]

        public int Quantity { get; set; }
        [Required]

        public decimal Price { get; set; }
        public decimal Discount { get; set; }

        public virtual IEnumerable<Order> Orders { get; set; } = new List<Order>();

        public int UserId   { get; set; }
    }
}
