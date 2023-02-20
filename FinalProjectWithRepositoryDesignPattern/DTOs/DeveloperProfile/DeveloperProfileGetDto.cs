using FinalProjectWithRepositoryDesignPattern.DTOs.Developer;
using FinalProjectWithRepositoryDesignPattern.DTOs.Project;

namespace FinalProjectWithRepositoryDesignPattern.DTOs.DeveloperProfile
{
    public class DeveloperProfileGetDto
    {
        public List<ProjectGetDto> Projects { get; set; }
        public DeveloperGetDto developerGet { get; set; }
    }
}
