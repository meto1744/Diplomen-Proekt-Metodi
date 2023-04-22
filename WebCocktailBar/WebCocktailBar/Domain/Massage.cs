using System.ComponentModel.DataAnnotations;

namespace WebCocktailBar.Domain
{
    public class Message
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(100)]
        public string Email { get; set; }

        [Required]
        [MaxLength(500)]
        public string Comment { get; set; }
    }
}
