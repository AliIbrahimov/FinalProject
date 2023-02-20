using AutoMapper;
using FinalProjectWithRepositoryDesignPattern.DAL.Repository.Abstract;
using FinalProjectWithRepositoryDesignPattern.DTOs.ChooseUs;
using FinalProjectWithRepositoryDesignPattern.DTOs.Developer;
using FinalProjectWithRepositoryDesignPattern.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectWithRepositoryDesignPattern.ViewComponents
{
    public class DevelopersViewComponent : ViewComponent
    {
        private readonly IDeveloperRepository _developerRepository;
        private readonly IMapper _mapper;


        public DevelopersViewComponent(IDeveloperRepository developerRepository, IMapper mapper)
        {
            _developerRepository = developerRepository;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<Developer> developers = await _developerRepository.GetAllAsync();
            List<DeveloperGetDto> developerGets = _mapper.Map<List<DeveloperGetDto>>(developers);
            return View(developerGets);
        }
    }
}
