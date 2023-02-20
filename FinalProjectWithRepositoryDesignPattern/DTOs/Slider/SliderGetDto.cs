using System.ComponentModel;

namespace FinalProjectWithRepositoryDesignPattern.DTOs.Slider;

public class SliderGetDto
{
    public int Id { get; set; }
    public string? Image { get; set; }
    public string? Title { get; set; }
    public string? Text { get; set; }
    [DefaultValue(false)]
    public bool IsActive { get; set; }
}
