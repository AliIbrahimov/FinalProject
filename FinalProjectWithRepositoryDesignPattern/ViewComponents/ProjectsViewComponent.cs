using AutoMapper;
using FinalProjectWithRepositoryDesignPattern.DAL.Repository.Abstract;
using FinalProjectWithRepositoryDesignPattern.DTOs.ChooseUs;
using FinalProjectWithRepositoryDesignPattern.DTOs.Project;
using FinalProjectWithRepositoryDesignPattern.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectWithRepositoryDesignPattern.ViewComponents
{
    public class ProjectsViewComponent : ViewComponent
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IMapper _mapper;

        public ProjectsViewComponent(IMapper mapper, IProjectRepository projectRepository)
        {
            _mapper = mapper;
            _projectRepository = projectRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<Project> projects = await _projectRepository.GetAllAsync();
            List<ProjectGetDto> projectGets = _mapper.Map<List<ProjectGetDto>>(projects);

            projectGets = projectGets
               .OrderByDescending(d => d.CreatedDate)
               .Take(3)
               .ToList();
            return View(projectGets);
        }
    }
}
