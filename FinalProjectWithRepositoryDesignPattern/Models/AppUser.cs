using Microsoft.AspNetCore.Identity;

namespace FinalProjectWithRepositoryDesignPattern.Models;

public class AppUser:IdentityUser
{
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public bool isDeveloper { get; set; }
    public string? ProfileImage { get; set; }
    public string? Adress { get; set; }
    public string? Position { get; set; }
    public List<Quote>? Quotes { get; set; }
    public List<Comment>? Comments { get; set; }
}
