using FinalProjectWithRepositoryDesignPattern.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProjectWithRepositoryDesignPattern.DTOs.Developer;

public class DeveloperPostDto
{
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? Username { get; set; }

    public string? Position { get; set; }
    public string? Description { get; set; }
    public string? Phone { get; set; }
    public string? Adress { get; set; }
    public string Mail { get; set; }
    public IFormFile FormFile { get; set; }
    public List<Models.Project>? Projects { get; set; }
}
