using FinalProjectWithRepositoryDesignPattern.DTOs.Comment;

namespace FinalProjectWithRepositoryDesignPattern.DTOs.Project;

public class ProjectEditDto
{
    public ProjectGetDto getDto { get; set; }
    public ProjectPostDto postDto { get; set; }
    public CommentPostDto CommentPost { get; set; }
}

