using System.ComponentModel.DataAnnotations.Schema;
using FinalProjectWithRepositoryDesignPattern.Models;

namespace FinalProjectWithRepositoryDesignPattern.DTOs.Developer;

public class DeveloperGetDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? UserName { get; set; }
    public string? Position { get; set; }
    public string? Description { get; set; }
    public string? Image { get; set; }
    public string? Phone { get; set; }
    public string? Adress { get; set; }
    public string Mail { get; set; }
    public List<Models.Project>? Projects { get; set; }
}

