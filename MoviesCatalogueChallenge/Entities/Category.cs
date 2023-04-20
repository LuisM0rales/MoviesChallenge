using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MoviesCatalogueChallenge.Entities
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryId { get; set; }
        [MaxLength(100)]
        public string Name { get; set; } = null!;
        public virtual ICollection<Movie> Movies { get; set; } = null!; // Category can have multiple movies
    }
}
