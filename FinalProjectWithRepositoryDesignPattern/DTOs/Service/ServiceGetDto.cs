using FinalProjectWithRepositoryDesignPattern.Models;

namespace FinalProjectWithRepositoryDesignPattern.DTOs.Service
{
    public class ServiceGetDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Title { get; set; }
        public List<ServiceAction>? serviceActions { get; set; }
    }
}
