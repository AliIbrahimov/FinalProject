using System.ComponentModel.DataAnnotations.Schema;

namespace FinalProjectWithRepositoryDesignPattern.DTOs.Slider;

public class SliderPostDto
{
    public string Title { get; set; }
    public string Text { get; set; }
    public IFormFile FormFile { get; set; }
    public bool IsActive { get; set; } = false; 

}
