using System.ComponentModel;

namespace FinalProjectWithRepositoryDesignPattern.Models;

public class Quote
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Mail { get; set; }
    public string Message { get; set; }
    [DefaultValue("false")]
    public bool? IsActive { get; set; }
    public string? AppUserId { get; set; }
    public AppUser? AppUser { get; set; }
    
}
