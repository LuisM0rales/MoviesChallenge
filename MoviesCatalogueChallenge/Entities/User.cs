using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MoviesCatalogueChallenge.Entities
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        [MaxLength(200)]
        public string Email { get; set; } = null!;
        [MaxLength(200)]
        public string Password { get; set; } = null!; // Not shown, but required for authentication
        public int RoleId { get; set; } // Foreign key for Role
        [ForeignKey("RoleId")]
        public virtual Role Role { get; set; } = null!; // Navigation property to Role
        public virtual ICollection<Rating> Ratings { get; set; } = null!;
    }
}
