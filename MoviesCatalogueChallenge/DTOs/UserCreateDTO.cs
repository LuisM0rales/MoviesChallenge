namespace MoviesCatalogueChallenge.DTOs
{
    public class UserCreateDTO
    {
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int RoleId { get; set; }
    }
}
