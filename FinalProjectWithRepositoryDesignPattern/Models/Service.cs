namespace FinalProjectWithRepositoryDesignPattern.Models;

public class Service
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Title { get; set; }
    public List<ServiceAction>? serviceActions { get; set; }

}
