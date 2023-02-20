using System.ComponentModel.DataAnnotations;

namespace FinalProjectWithRepositoryDesignPattern.Models;

public class Comment
{
    public int Id { get; set; }

    public string AppUserId { get; set; }
    public int ProjectId { get; set; }

    public string Message { get; set; }
    public DateTime SendedDate { get; set; }
    public bool isDeleted { get; set; }

    public AppUser AppUser { get; set; }
    public Project Project { get; set; }
    
}
