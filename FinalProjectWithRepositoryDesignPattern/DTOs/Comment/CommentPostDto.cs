using FinalProjectWithRepositoryDesignPattern.Models;

namespace FinalProjectWithRepositoryDesignPattern.DTOs.Comment
{
    public class CommentPostDto
    {

        public string AppUserId { get; set; }
        public int ProjectId { get; set; }

        public string Message { get; set; }
        public DateTime SendedDate { get; set; }
        public bool isDeleted { get; set; }

        public AppUser AppUser { get; set; }
        public Models.Project Project { get; set; }

    }
}
