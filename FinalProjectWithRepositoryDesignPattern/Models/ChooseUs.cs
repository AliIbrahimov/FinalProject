using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProjectWithRepositoryDesignPattern.Models;

public class ChooseUs
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Title { get; set; }
    public string Image { get; set; }
    [NotMapped]
    public IFormFile FormFile { get; set; }
    public List<ChooseUsActions> ChooseUsActions { get; set; }

}
