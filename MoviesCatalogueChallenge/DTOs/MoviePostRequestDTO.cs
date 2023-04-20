using System.ComponentModel.DataAnnotations;

namespace MoviesCatalogueChallenge.DTOs
{
    public class MoviePostRequestDTO
    {
        [StringLength(maximumLength: 200)]
        public string Name { get; set; } = null!;
        public int ReleaseYear { get; set; }
        [StringLength(maximumLength: 600)]
        public string Synopsis { get; set; } = null!;
        public byte[] Poster { get; set; } = null!; // Store image as byte array
        public DateTime CreatedDate { get; set; }
        public int CategoryId { get; set; }
        public int UserId { get; set; }

    }
}
