using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MoviesCatalogueChallenge.Entities
{
    public class Rating
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RatingId { get; set; }
        public int Value { get; set; }
        public int MovieId { get; set; }
        [ForeignKey("MovieId")]
        public virtual Movie Movies { get; set; } = null!;
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User Users { get; set; } = null!;
    }
}
