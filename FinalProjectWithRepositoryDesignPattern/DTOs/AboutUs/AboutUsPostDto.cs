using FinalProjectWithRepositoryDesignPattern.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProjectWithRepositoryDesignPattern.DTOs.AboutUs;

public class AboutUsPostDto
{
    public string AboutName { get; set; }
    public string AboutTitle { get; set; }
    public string Aboutdescription { get; set; }
    public string Image { get; set; }
    [NotMapped]
    public IFormFile FormFile { get; set; }
    public List<AboutAction> AboutActions { get; set; }
}
