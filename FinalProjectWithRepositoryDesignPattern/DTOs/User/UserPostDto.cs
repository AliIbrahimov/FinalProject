namespace FinalProjectWithRepositoryDesignPattern.DTOs.User
{
    public class UserPostDto
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string Username { get; set; }
        public string? Image { get; set; }
        public IFormFile? FormFile { get; set; }
        public string? Phone { get; set; }
        public string? Adress { get; set; }
        public string Mail { get; set; }
    }
}
