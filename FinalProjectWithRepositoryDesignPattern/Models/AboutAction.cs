namespace FinalProjectWithRepositoryDesignPattern.Models;

public class AboutAction
{
    public int Id { get; set; }
    public string Icon { get; set; }
    public string Name { get; set; }
    public int AboutUsId { get; set; }
    public AboutUs AboutUs { get; set; }
}
