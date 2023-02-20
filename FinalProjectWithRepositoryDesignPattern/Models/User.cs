using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProjectWithRepositoryDesignPattern.Models;

public class User
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string Username { get; set; }
    public string? Image { get; set; }
    public string? Phone { get; set; }
    public string? Adress { get; set; }
    public string Mail { get; set; }
}
