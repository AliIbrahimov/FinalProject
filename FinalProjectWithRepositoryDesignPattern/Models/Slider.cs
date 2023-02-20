using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProjectWithRepositoryDesignPattern.Models;

public class Slider
{
    public int Id { get; set; }
    public string Image { get; set; }
    public string Title { get; set; }
    public string Text { get; set; }
    [NotMapped]
    public IFormFile FormFile { get; set; }
    [DefaultValue(false)]
    public bool IsActive { get; set; }
}
