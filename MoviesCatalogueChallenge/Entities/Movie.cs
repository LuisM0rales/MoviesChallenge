using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoviesCatalogueChallenge.Entities
{
    public class Movie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MovieId { get; set; }
        [MaxLength(200)]
        public string Name { get; set; } = null!;
        public int ReleaseYear { get; set; }
        [MaxLength(600)]
        public string Synopsis { get; set; } = null!;
        public byte[] Poster { get; set; } = null!; // Store image as byte array
        public DateTime CreatedDate { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; } = null!; // Movie can have multiple categories
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; } = null!; // Movie created by user
        public virtual ICollection<Rating> Ratings { get; set; } = null!;
    }
}
