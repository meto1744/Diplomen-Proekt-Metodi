using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebCocktailBar.Domain
{
    public class Order
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }
        [Required]

        public DateTime OrderDate { get; set; }
        [Required]

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }
        [Required]

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
        [Required]

        public int Quantity { get; set; }

        public decimal Price { get; set; }
        public decimal Discount { get; set; }

        public decimal TotalPrice
        {
            get
            {
                return Quantity * Price - Quantity * Price * Discount / 100;
                    //return Quantity * Price
            }
        }
    }
}
