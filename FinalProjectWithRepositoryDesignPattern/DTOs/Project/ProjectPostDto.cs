using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FinalProjectWithRepositoryDesignPattern.DTOs.Project;

public class ProjectPostDto
{
    public string Name { get; set; }
    public string? AuthorName { get; set; }
    public string? ProjectUrl { get; set; }
    public string? Description { get; set; }

    public DateTime? CreatedDate { get; set; }
    [DefaultValue(false)]
    public bool IsDeleted { get; set; }
    public string? Image { get; set; }
    [NotMapped]
    public IFormFile? FormFile { get; set; }
    public int DeveloperId { get; set; }
    public Models.Developer Developer { get; set; }
    public List<Models.Comment>? Comments { get; set; }

}
